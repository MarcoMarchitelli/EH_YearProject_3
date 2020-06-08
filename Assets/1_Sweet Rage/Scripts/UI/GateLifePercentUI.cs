namespace SweetRage {
    using Deirin.Utilities;
    using UnityEngine;
    using UnityEngine.Events;

    public class GateLifePercentUI : MonoBehaviour {
        [Header("Parameters")]
        [Range(0,1)] public float star3Percent;
        [Range(0,1)] public float star2Percent;
        [Range(0,1)] public float star1Percent;

        [Header("Events")]
        public UnityEvent On3StarLoss;
        public UnityEvent On2StarLoss;
        public UnityEvent On1StarLoss;

        private bool called3, called2, called1;

        public void SetPercent ( float percent ) {
            percent.Clamp01();

            if ( called3 == false && percent < star3Percent && percent > star2Percent ) {
                On3StarLoss.Invoke();
                called3 = true;
            }
            else if ( called2 == false && percent < star2Percent && percent > star1Percent ) {
                On2StarLoss.Invoke();
                called2 = true;
            }
            else if ( called1 == false && percent < star1Percent ) {
                On1StarLoss.Invoke();
                called1 = true;
            }
        }
    }
}