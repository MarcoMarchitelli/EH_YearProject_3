Shader "Custom/Toon_VertexColor" {
	Properties{
		_ShadingPalette("Shading Palette", 2D) = "white" {}
		_ShadingIntesity("Shading Palette Intensity", Range(0,1)) = 0
		_Tint("Tint", Color) = (1, 1, 1, 1)

		_LightColorIntensity("Light Color Intensity", Range(0,1)) = 0
		_ShadowIntesity("Shadow Intesity", Range(0,1)) = 0
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
					float4 vertexColor : COLOR;
					float2 uv : TEXCOORD0;
				};

				struct v2f {
					float4 pos : SV_POSITION;
					float3 worldNormal : NORMAL;
					float4 vertexColor : COLOR;
					float2 uv : TEXCOORD0;
					LIGHTING_COORDS(1,2)
				};

				sampler2D _ShadingPalette;
				fixed4 _Tint;
				float _Glossiness;
				float _Metallic;
				float _LightColorIntensity;
				float _ShadowIntesity;
				float _ShadingIntesity;
				
				float map( float s, float a1, float a2, float b1, float b2 )
				{
					return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
				}

				v2f vertexShader( vertexInput IN ) {
					v2f OUT;
					OUT.worldNormal = UnityObjectToWorldNormal( IN.normal );
					OUT.pos = UnityObjectToClipPos( IN.pos );
					OUT.uv = IN.uv;					
					TRANSFER_VERTEX_TO_FRAGMENT(OUT);
					return OUT;
				}

				fixed4 fragmentShader(v2f IN) : SV_Target {
					//lambert
					float3 normal = normalize(IN.worldNormal);
					float lambert = dot(_WorldSpaceLightPos0, normal);
					lambert = map(lambert, -1, 1, 0.01, 0.99);

					//texture sampling order (left to right)
					lambert = 1 - lambert;

					//shading UV
					float2 shadingUV = float2(lambert, 0);
					fixed4 shadingColor = tex2D(_ShadingPalette, shadingUV);

					//light attenuation
					float shadow = SHADOW_ATTENUATION(IN);

					//color
					fixed4 color = IN.vertexColor;

					color *= _Tint;
					color *= lerp(1, _LightColor0, _LightColorIntensity);
					color *= lerp(1, shadingColor, _ShadingIntesity);
					color *= lerp(1, shadow, _ShadowIntesity);

					return saturate( color );
				}

				ENDCG
			}

			UsePass "Legacy Shaders/VertexLit/SHADOWCASTER"
		}
}