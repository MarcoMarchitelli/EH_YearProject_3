namespace Deirin.Utilities {
    using System.Xml.Schema;
    using UnityEngine;

    public static class Math {
        public static float Remap ( this float value, float oldMin, float oldMax, float newMin, float newMax ) {
            float percent = Mathf.InverseLerp( oldMin, oldMax, value );
            return Mathf.Lerp( newMin, newMax, percent );
        }

        public static Color Remap ( this float value, float oldMin, float oldMax, Color newMin, Color newMax ) {
            float percent = Mathf.InverseLerp( oldMin, oldMax, value );
            return Color.Lerp( newMin, newMax, percent );
        }

        public static float Clamp01 ( this ref float value ) {
            value = Mathf.Clamp01( value );
            return value;
        }
    }
}