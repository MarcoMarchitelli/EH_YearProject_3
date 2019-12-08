namespace Deirin.Utilities {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public static class Vector3Extentions {
        public static Vector3 Mul ( this Vector3 a, Vector3 b ) {
            return new Vector3( a.x * b.x, a.y * b.y, a.z * b.z );
        }
    }
}