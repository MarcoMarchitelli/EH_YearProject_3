// Upgrade NOTE: replaced '_Projector' with 'unity_Projector'
// Upgrade NOTE: replaced '_ProjectorClip' with 'unity_ProjectorClip'

Shader "Deirin/Projector_SDF" {
	Properties {
		_Color ("Main Color", Color) = (1,1,1,1)
		_Radius ("Radius", Range(0,1)) = .5
		_Thickness("Thickness", Range(0,1)) = .5
		_Smoothstep("Smoothstep", Vector) = (0,0.1,0,0)
		//_ShadowTex ("Cookie", 2D) = "" {}
		//_FalloffTex ("FallOff", 2D) = "" {}
	}
	
	Subshader {
		Tags {"Queue"="Transparent"}
		Pass {
			ZWrite Off
			//ColorMask RGB
			Blend SrcAlpha OneMinusSrcAlpha
			//Offset -1, -1
	
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			//#pragma multi_compile_fog
			#include "UnityCG.cginc"
			
			struct v2f {
				float4 uvShadow : TEXCOORD0;
				float4 uvFalloff : TEXCOORD1;
				//UNITY_FOG_COORDS(2)
				float4 pos : SV_POSITION;
			};
			
			float4x4 unity_Projector;
			float4x4 unity_ProjectorClip;
			float _Radius;
			float _Thickness;
			float2 _Smoothstep;
			
			v2f vert (float4 vertex : POSITION)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(vertex);
				o.uvShadow = mul (unity_Projector, vertex);
				o.uvFalloff = mul (unity_ProjectorClip, vertex);
				//UNITY_TRANSFER_FOG(o,o.pos);
				return o;
			}
			
			fixed4 _Color;
			sampler2D _ShadowTex;
			sampler2D _FalloffTex;
			
			fixed4 frag(v2f i) : SV_Target
			{
				float2 uv = UNITY_PROJ_COORD(i.uvShadow - .5f);

				float d = length(uv) - _Radius;
				d = abs(d) - _Thickness;
				d = smoothstep(_Smoothstep.x, _Smoothstep.y, d);
				d = 1 - d;

				fixed4 color = fixed4(_Color.rgb, _Color.a * d);

				return color;
			}
			ENDCG
		}
	}
}
