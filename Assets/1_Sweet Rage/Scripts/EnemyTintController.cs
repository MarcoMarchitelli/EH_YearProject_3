namespace SweetRage {
    using UnityEngine;

    public class EnemyTintController : MonoBehaviour {
        public SkinnedMeshRenderer smr;
        public Color color;

        private int tintID;

        private void Awake () {
            tintID = Shader.PropertyToID( "_Tint" );
        }

        public void SetColor () {
            foreach ( var mat in smr.materials ) {
                mat.SetColor( tintID, color );
            }
        }
    } 
}