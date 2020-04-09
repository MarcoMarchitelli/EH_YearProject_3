namespace Deirin.EB {
    using UnityEngine;
    using Deirin.Utilities;

    public class OverlapDamageDealer : BaseBehaviour {
        public enum GetComponentMode { self, parent, children }

        [Header("Parameters")]
        public float damage;
        public float radius;
        public GetComponentMode getComponentMode;

        [Header("Events")]
        public UnityEvent_Entity OnEntityHit;

        private Collider[] hitObjs;
        private BaseEntity tempEntity;
        private DamageReceiver tempDamageReceiver;

        public void UpdateOverlap () {
            hitObjs = Physics.OverlapSphere( transform.position, radius );

            CheckObjects();
        }

        private void CheckObjects () {
            switch ( getComponentMode ) {
                case GetComponentMode.self:
                for ( int i = 0; i < hitObjs.Length; i++ ) {
                    if ( hitObjs[i].TryGetComponent( out tempEntity ) ) {
                        OnEntityHit.Invoke( tempEntity );
                        if ( tempEntity.TryGetBehaviour( out tempDamageReceiver ) ) {
                            tempDamageReceiver.Damage( damage );
                        }
                    }
                }
                break;
                case GetComponentMode.parent:
                for ( int i = 0; i < hitObjs.Length; i++ ) {
                    tempEntity = hitObjs[i].GetComponentInParent<BaseEntity>();
                    if ( tempEntity ) {
                        OnEntityHit.Invoke( tempEntity );
                        if ( tempEntity.TryGetBehaviour( out tempDamageReceiver ) ) {
                            tempDamageReceiver.Damage( damage );
                        }
                    }
                }
                break;
                case GetComponentMode.children:
                for ( int i = 0; i < hitObjs.Length; i++ ) {
                    tempEntity = hitObjs[i].GetComponentInChildren<BaseEntity>();
                    if ( tempEntity ) {
                        OnEntityHit.Invoke( tempEntity );
                        if ( tempEntity.TryGetBehaviour( out tempDamageReceiver ) ) {
                            tempDamageReceiver.Damage( damage );
                        }
                    }
                }
                break;
            }
        }
    }
}