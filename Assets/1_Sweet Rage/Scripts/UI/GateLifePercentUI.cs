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
        public float gateOpeningDuration = 1f;
        public FallSequence[] sequences;

        private bool gateOpen, opening, closing;
        private float timer;
        private Vector3 startPos, endPos;
        private System.Action OnGateOpen;

        private void Awake () {
            endPos = endGateTransform.position + Vector3.up * -145;
            startPos = endPos + Vector3.up * 70;

            foreach ( FallSequence sequence in sequences ) {
                sequence.Setup();
                sequence.sequence.onComplete += SequenceCompletionHandler;
            }
        }

        private void Update () {
            if ( opening ) {
                timer += Time.deltaTime;
                float percent = timer / gateOpeningDuration;
                endGateTransform.position = Vector3.Lerp( startPos, endPos, percent.Clamp01() );
                if ( percent == 1 ) {
                    timer = 0;
                    gateOpen = true;
                    opening = false;
                    OnGateOpen?.Invoke();
                }
            }
            else if ( closing ) {
                timer += Time.deltaTime;
                float percent = timer / gateOpeningDuration;
                endGateTransform.position = Vector3.Lerp( endPos, startPos, percent.Clamp01() );
                if ( percent == 1 ) {
                    timer = 0;
                    gateOpen = false;
                    closing = false;
                }
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

            if ( allEnded ) {
                opening = false;
                closing = true;
            }
        }

        public void SetPercent ( float percent ) {
            percent.Clamp01();

            if ( gateOpen )
                foreach ( FallSequence s in sequences ) {
                    if ( s.started == false && percent <= s.healthBarPercent )
                        s.sequence.PlayForward();
                }
            else {
                foreach ( FallSequence s in sequences ) {
                    if ( s.started == false && percent <= s.healthBarPercent )
                        OnGateOpen += s.sequence.PlayForward;
                }
                opening = true;
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
            Vector3 targetEulers = new Vector3( 0, 0, UnityEngine.Random.Range( minTiltAngle, maxTiltAngle ) );

            sequence.Append( image.transform.DOShakePosition( .8f, new Vector3( 5, 5, 0 ) ) );
            sequence.Join( image.transform.DOShakeRotation( .8f, new Vector3( 0, 0, 10 ) ) );
            sequence.Append( image.transform.DOLocalRotate( targetEulers, rotateDuration ).SetRelative() );
            sequence.Append(
                image.transform.DOLocalMoveY( UnityEngine.Random.Range( minFallAmount, maxFallAmount ), fallDuration )
                .SetRelative()
                .SetEase( Ease.InCubic )
            );
            sequence.Join( image.DOFade( 0, fadeDuration ).SetEase( Ease.InCubic ) );

            sequence.SetUpdate( true );

            sequence.onPlay += PlayHandler;
            sequence.onComplete += CompleteHandler;
        }

        private void PlayHandler () => started = true;

        private void CompleteHandler () => ended = true;
    }
}