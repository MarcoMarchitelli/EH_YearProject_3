namespace SweetRage {
    using Deirin.Utilities;
    using DG.Tweening;
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;

    public class GateLifePercentUI : MonoBehaviour {
        [Header("References")]
        public Transform endGateTransform;

        [Header("Parameters")]
        public FallSequence[] sequences;

        private bool gateOpen;
        private Tween gateUIOpen, gateUIClose;
        
        private void Awake () {
            gateUIOpen = endGateTransform.DOBlendableLocalMoveBy( Vector3.up * -70, 1 );
            gateUIOpen.SetUpdate( true );
            gateUIOpen.SetAutoKill( false );
            gateUIOpen.onComplete += GateOpenHandler;

            gateUIClose = endGateTransform.DOBlendableLocalMoveBy( Vector3.up * 70, 1 );
            gateUIClose.SetUpdate( true );
            gateUIClose.SetAutoKill( false );
            gateUIClose.onPlay += GateCloseHandler;

            foreach ( FallSequence sequence in sequences ) {
                sequence.Setup();
                sequence.sequence.onComplete += SequenceCompletionHandler;
            }
        }

        private void SequenceCompletionHandler () {
            bool allEnded = true;

            foreach ( FallSequence s in sequences ) {
                if ( s.started == true && s.ended == false ) {
                    allEnded = false;
                    break;
                }
            }

            if ( allEnded )
                gateUIClose.PlayForward();
        }

        private void GateOpenHandler () => gateOpen = true;

        private void GateCloseHandler () => gateOpen = false;

        public void SetPercent ( float percent ) {
            percent.Clamp01();

            if ( gateOpen )
                foreach ( FallSequence s in sequences ) {
                    if ( s.started == false && percent < s.healthBarPercent )
                        s.sequence.PlayForward();
                }
            else {
                foreach ( FallSequence s in sequences ) {
                    if ( s.started == false && percent < s.healthBarPercent )
                        s.sequence.PlayForward();
                }
                gateUIOpen.PlayForward();
            }
        }
    }

    [System.Serializable]
    public class FallSequence {
        [Header("Refs")]
        public Image image;
        [Header("Params")]
        [Range( 0, 1 )] public float healthBarPercent;
        [Range( -360, 360 )] public float minTiltAngle, maxTiltAngle;
        public float minFallAmount, maxFallAmount;
        public float shakeDuration;
        public float rotateDuration;
        public float fallDuration;
        public float fadeDuration;

        [HideInInspector] public Sequence sequence;
        [HideInInspector] public bool started, ended;

        public void Setup () {
            sequence = DOTween.Sequence();
            Vector3 targetEulers = new Vector3( 0,0,UnityEngine.Random.Range(minTiltAngle, maxTiltAngle) );

            sequence.Append( image.transform.DOShakeRotation( shakeDuration, new Vector3( 0, 0, 30 ) ) );
            sequence.Append( image.transform.DOLocalRotate( targetEulers, rotateDuration ).SetRelative() );
            sequence.Append( image.transform.DOLocalMoveY( UnityEngine.Random.Range( minFallAmount, maxFallAmount ), fallDuration ).SetRelative().SetEase( Ease.InCubic ) );
            sequence.Join( image.DOFade( 0, fadeDuration ).SetEase( Ease.InCubic ) );

            sequence.SetUpdate( true );

            sequence.onPlay += PlayHandler;
            sequence.onComplete += CompleteHandler;
        }

        private void PlayHandler () => started = true;

        private void CompleteHandler () => ended = true;
    }
}