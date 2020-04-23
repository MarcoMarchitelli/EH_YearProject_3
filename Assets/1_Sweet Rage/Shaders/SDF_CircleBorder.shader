Shader "Deirin/SDF_CircleBorder"
{
    Properties
    {
		_Color ( "Tint", Color ) = ( 1,1,1,1 )
        _Radius ( "Radius", Range( 0,1 ) ) = .4
		_Thickness ( "Thickness", Range( 0,1 ) ) = .5
		_SmoothstepMin ( "Smoothstep Min", Range( -1, 1 ) ) = -1
		_SmoothstepMax ( "Smoothstep Max", Range( -1, 1 ) ) = 1
    }
    SubShader
    {
        Tags { "QUEUE"="Transparent" "RenderType"="Transparent" }
        LOD 100

		Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            //// make fog work
            //#pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
                /*UNITY_FOG_COORDS(1)*/
            };

            fixed4 _Color;
            float _Radius;
			float _Thickness;
			float _SmoothstepMin;
			float _SmoothstepMax;

            v2f vert ( appdata v ) {
                v2f o;
                o.vertex = UnityObjectToClipPos( v.vertex );
                o.uv = v.uv;
                /*UNITY_TRANSFER_FOG(o,o.vertex);*/
                return o;
            }

            fixed4 frag ( v2f i ) : SV_Target {
                i.uv -= .5;

                float d = length( i.uv ) - _Radius;
                d = abs( d ) - _Thickness;
                d = 1 - smoothstep( _SmoothstepMin, _SmoothstepMax, d );

                fixed4 color = fixed4( _Color.xyz, _Color.w * d );

                //// apply fog
                //UNITY_APPLY_FOG(i.fogCoord, color);

                return color;
            }
            ENDCG
        }
    }
}
