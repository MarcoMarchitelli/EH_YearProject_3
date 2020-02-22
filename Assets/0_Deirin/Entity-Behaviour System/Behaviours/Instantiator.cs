namespace Deirin.EB {
    using UnityEngine;
    using UnityEngine.Events;

    public class Instantiator : BaseBehaviour {
        [Header("Prefab")]
        public GameObject objPrefab;

        [Header("Params")]
        public Transform referenceTransform;
        public bool setAsParent;
        public bool usePosition;
        public Vector3 position;
        public bool useRotation;
        public Vector3 rotationEulers;

        [Header("Events")]
        public UnityEvent OnInstantiate;

        public void InstantiateObject () {
            GameObject obj = Instantiate( objPrefab, usePosition ? referenceTransform.position : position, Quaternion.Euler( useRotation ? referenceTransform.localEulerAngles : rotationEulers ) );
            if ( setAsParent && referenceTransform != null )
                obj.transform.SetParent( referenceTransform );
            OnInstantiate.Invoke();
        }
    }
}