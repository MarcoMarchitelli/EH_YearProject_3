namespace Deirin.EB {
    using UnityEngine;

    public class OverlapDamageDealer : BaseBehaviour {
        public enum GetComponentMode { self, parent, children }

        [Header("Parameters")]
        public float damage;
        public float radius;
        public GetComponentMode getComponentMode;

        private Collider[] hitObjs;
        private DamageReceiver damageReceiver;

        public void UpdateOverlap () {
            hitObjs = Physics.OverlapSphere( transform.position, radius );

            CheckObjects();
        }

        private void CheckObjects () {
            switch ( getComponentMode ) {
                case GetComponentMode.self:
                for ( int i = 0; i < hitObjs.Length; i++ ) {
                    if ( hitObjs[i].TryGetComponent( out damageReceiver ) ) {
                        damageReceiver.Damage( damage );
                    }
                }
                break;
                case GetComponentMode.parent:
                for ( int i = 0; i < hitObjs.Length; i++ ) {
                    damageReceiver = hitObjs[i].GetComponentInParent<DamageReceiver>();
                    if ( damageReceiver ) {
                        damageReceiver.Damage( damage );
                    }
                }
                break;
                case GetComponentMode.children:
                for ( int i = 0; i < hitObjs.Length; i++ ) {
                    damageReceiver = hitObjs[i].GetComponentInChildren<DamageReceiver>();
                    if ( damageReceiver ) {
                        damageReceiver.Damage( damage );
                    }
                }
                break;
            }
        }
    }
}