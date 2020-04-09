﻿Shader "Custom/Toon_VertexColor_Outline" {
	Properties{
		_ShadingPalette("Shading Palette", 2D) = "white" {}
		_Tint("Tint", Color) = (1, 1, 1, 1)
		_LightColorIntensity("Light Color Intensity", Range(0,1)) = 0

		_OutlineColor("Outline Color", Color) = (0, 0, 0, 1)
		_OutlineWidth("Outline Width", Range(0, 400)) = 0.03
		_DistanceInfluence("Distance Influence", Range(0,1)) = 0
	}

		Subshader{

			//Tags {
			//	"RenderType" = "Opaque"
			//}

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
					float4 vertex : POSITION;
					float3 normal : NORMAL;
					float4 vertexColor : COLOR;
				};

				struct v2f {
					float4 vertex : SV_POSITION;
					float3 worldNormal : NORMAL;
					float4 vertexColor : COLOR;
					LIGHTING_COORDS(0,1)
				};

				sampler2D _ShadingPalette;
				fixed4 _Tint;
				float _Glossiness;
				float _Metallic;
				float _LightColorIntensity;

				float map(float s, float a1, float a2, float b1, float b2)
				{
					return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
				}

				v2f vertexShader(vertexInput IN) {
					v2f OUT;
					OUT.vertex = UnityObjectToClipPos(IN.vertex);
					OUT.worldNormal = UnityObjectToWorldNormal(IN.normal);
					OUT.vertexColor = IN.vertexColor;
					//TRANSFER_VERTEX_TO_FRAGMENT(OUT);
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
					//float shadow = SHADOW_ATTENUATION(IN);

					//color
					fixed4 color = IN.vertexColor;
					color *= _Tint;
					color *= lerp(1, _LightColor0, _LightColorIntensity);
					color *= shadingColor;
					//color *= shadow;

					return saturate(color);
				}

				ENDCG
			}

			UsePass "Legacy Shaders/VertexLit/SHADOWCASTER"

			Pass {

				Cull Front

				CGPROGRAM

				#pragma vertex VertexProgram
				#pragma fragment FragmentProgram

				half _OutlineWidth;
				float _DistanceInfluence;

				float4 VertexProgram(float4 position : POSITION, float3 normal : NORMAL) : SV_POSITION {
					float4 clipPosition = UnityObjectToClipPos(position);
					float3 clipNormal = mul((float3x3) UNITY_MATRIX_VP, mul((float3x3) UNITY_MATRIX_M, normal));
					float distanceInfluence = lerp(1, clipPosition.w, _DistanceInfluence);
					float2 offset = normalize(clipNormal.xy) / _ScreenParams.xy * _OutlineWidth * distanceInfluence * 2;
					clipPosition.xy += offset;
					return clipPosition;
				}

				half4 _OutlineColor;

				half4 FragmentProgram() : SV_TARGET {
					return _OutlineColor;
				}

				ENDCG

			}
		}
}