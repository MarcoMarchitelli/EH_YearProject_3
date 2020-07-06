namespace Deirin.Utilities {
    using UnityEngine;
    using UnityEngine.Events;

    public class Condition_Int : MonoBehaviour {
        public enum ComparisonType { Equal, NotEqual, Greater, Less, GreaterOrEqual, LessOrEqual }

        [Header("Parameters")]
        public int firstValue;
        public int secondValue;
        public ComparisonType comparisonType;

        [Header("Events")]
        public UnityEvent True, False;

        public void CompareTo () {
            switch ( comparisonType ) {
                case ComparisonType.Equal:
                if ( firstValue == secondValue )
                    True.Invoke();
                else
                    False.Invoke();
                break;
                case ComparisonType.NotEqual:
                if ( firstValue != secondValue )
                    True.Invoke();
                else
                    False.Invoke();
                break;
                case ComparisonType.Greater:
                if ( firstValue > secondValue )
                    True.Invoke();
                else
                    False.Invoke();
                break;
                case ComparisonType.Less:
                if ( firstValue < secondValue )
                    True.Invoke();
                else
                    False.Invoke();
                break;
                case ComparisonType.GreaterOrEqual:
                if ( firstValue >= secondValue )
                    True.Invoke();
                else
                    False.Invoke();
                break;
                case ComparisonType.LessOrEqual:
                if ( firstValue <= secondValue )
                    True.Invoke();
                else
                    False.Invoke();
                break;
            }
        }

        public void SetFirstValue ( int value ) {
            firstValue = value;
        }

        public void SetSecondValue ( int value ) {
            secondValue = value;
        }
    }
}