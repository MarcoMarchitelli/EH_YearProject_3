Shader "Custom/Toon_Texture" {
	Properties{
		_MainTex("Main Texture",2D) = "white" {}
		_Tint("Tint", Color) = (1, 1, 1, 1)

		_LambertStep("Lambert Step", Range(0,1)) = 0
		_ShadingIntesity("Shading Intensity", Range(0,1)) = 0
		_LightColorIntensity("Light Color Intensity", Range(0,1)) = 0
	}

	Subshader{

		Tags {
			"RenderType" = "Opaque"
		}

		Pass {
			Tags {
				"LightMode" = "ForwardBase"
				"PassFlags" = "OnlyDirectional"
			}

			CGPROGRAM

			#pragma vertex vertexShader
			#pragma fragment fragmentShader
			#pragma multi_compile_fwdbase

			#include "UnityCG.cginc"
			#include "Lighting.cginc"
			#include "AutoLight.cginc"

			struct vertexInput {
				float4 pos : POSITION;
				float3 normal : NORMAL;
				float2 uv : TEXCOORD0;
			};

			struct v2f {
				LIGHTING_COORDS(1,2)
				float4 pos : SV_POSITION;
				float3 worldNormal : NORMAL;
				float2 uv : TEXCOORD0;
			};

			sampler2D _MainTex;
			fixed4 _Tint;
			float _Glossiness;
			float _Metallic;
			float _LightColorIntensity;
			float _ShadingIntesity;
			float _LambertStep;

			float map(float s, float a1, float a2, float b1, float b2)
			{
				return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
			}

			float4 UnityBlendOverlay(float4 Base, float4 Blend, float Opacity)
			{
				float4 result1 = 1.0 - 2.0 * (1.0 - Base) * (1.0 - Blend);
				float4 result2 = 2.0 * Base * Blend;
				float4 zeroOrOne = step(Base, 0.5);
				float4 Out = result2 * zeroOrOne + (1 - zeroOrOne) * result1;
				Out = lerp(Base, Out, Opacity);
				return Out;
			}

			v2f vertexShader(vertexInput IN) {
				v2f OUT;
				OUT.worldNormal = UnityObjectToWorldNormal(IN.normal);
				OUT.pos = UnityObjectToClipPos(IN.pos);
				OUT.uv = IN.uv;
				TRANSFER_VERTEX_TO_FRAGMENT(OUT);
				return OUT;
			}

			fixed4 fragmentShader(v2f IN) : SV_Target {
				//lambert
				float3 normal = normalize( IN.worldNormal );
				float lambert = dot( _WorldSpaceLightPos0, normal );
				lambert = map( lambert, -1, 1, 0.01, 0.99 );
				lambert = step( lambert, _LambertStep );
				lambert = 1 - lambert;

				//light attenuation
				float shadow = SHADOW_ATTENUATION( IN );

				//color
				fixed4 color = tex2D( _MainTex, IN.uv );
				color *= _Tint;
				color *= lerp( 1, _LightColor0, _LightColorIntensity );

				float darkness = min( shadow, lambert );

				if ( darkness <= 0 )
					color = UnityBlendOverlay( color, darkness, _ShadingIntesity);

				return saturate( color );
			}

			ENDCG
		}

		UsePass "Legacy Shaders/VertexLit/SHADOWCASTER"
	}
}