namespace Deirin.EB {
    using UnityEngine;

    public class MaterialPropertyBlockSetter : BaseBehaviour {
        [Header("Refs")]
        public Renderer[] targetRenderers;

        [Header("Params")]
        public MaterialParameter[] parameters;

        public void SetMPB () {
            MaterialPropertyBlock mpb = new MaterialPropertyBlock();
            for ( int i = 0; i < parameters.Length; i++ ) {
                switch ( parameters[i].type ) {
                    case MaterialParameter.Type.Color:
                    mpb.SetColor( name, parameters[i].colorValue );
                    break;
                    case MaterialParameter.Type.Float:
                    mpb.SetFloat( name, parameters[i].floatValue );
                    break;
                    case MaterialParameter.Type.Int:
                    mpb.SetInt( name, parameters[i].intValue );
                    break;
                    case MaterialParameter.Type.Vector4:
                    mpb.SetVector( name, parameters[i].vector4Value );
                    break;
                }
            }
            for ( int i = 0; i < targetRenderers.Length; i++ ) {
                targetRenderers[i].SetPropertyBlock( mpb );
            }
        }

        //HACK: hard coding _Color for now :(((((
        public void SetColor ( Color color ) {
            MaterialPropertyBlock mpb = new MaterialPropertyBlock();
            mpb.SetColor( "_Color", color );
            for ( int i = 0; i < targetRenderers.Length; i++ ) {
                targetRenderers[i].SetPropertyBlock( mpb );
            }
        }
    }

    [System.Serializable]
    public class MaterialParameter {
        public enum Type { Color, Float, Int, Vector4 }
        public Type type;
        public string name;
        public Color colorValue;
        public float floatValue;
        public int intValue;
        public Vector4 vector4Value;
    }
}