namespace Deirin.EB {
    using UnityEngine;
    using Deirin.Utilities;

    public class EntityToTransform : BaseBehaviour {
        [Header("Parameters")]
        public BaseEntity entity;

        [Header("Events")]
        public UnityEvent_Transform OnCast;

        #region API
        public void SetEntity ( BaseEntity entity ) {
            this.entity = entity;
        }

        public void Cast () {
            if ( !entity ) {
#if UNITY_EDITOR
                Debug.LogError( Entity.name + "'s EntityToTransform is trying to cast a null Entity!" );
#endif
                return;
            }
            OnCast.Invoke( entity.transform );
        }
        #endregion
    }
}