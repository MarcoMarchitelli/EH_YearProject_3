Shader "Unlit/SDF_QuadBorder"
{
    Properties
    {
		_Color ( "Tint", Color ) = (1,1,1,1)
		_SizeX ("x", Range(0,1)) = .4
		_SizeY ("y", Range(0,1)) = .4
		_Thickness("Thickness", Range(0,1)) = .5
		_SmoothstepMin("Smoothstep Min", Range(-1,1) )= -1
		_SmoothstepMax("Smoothstep Max", Range(-1,1) )= 1
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" }
        LOD 100

		Blend One OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

			float sdBox( in float2 p, in float2 b )
			{
			    float2 d = abs(p)-b;
			    return length( max( d, float2( 0,0 ) ) ) + min( max( d.x,d.y ), 0.0 );
			}

			fixed4 _Color;
			float _SizeX;
			float _SizeY;
			float _Thickness;
			float _SmoothstepMin;
			float _SmoothstepMax;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
				i.uv -= .5;
				float d = sdBox(i.uv, float2(_SizeX, _SizeY) );
				d = abs(d) - _Thickness;
				float4 col = 1-smoothstep(_SmoothstepMin,_SmoothstepMax,d);
				col *= _Color;
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
