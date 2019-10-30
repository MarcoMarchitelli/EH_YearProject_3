namespace TotemTD {
    using UnityEngine;

    [RequireComponent( typeof( Collider ) )]
    public class Cell : MonoBehaviour {
        public bool unplaceable;
        public bool empty = true;
    }
}