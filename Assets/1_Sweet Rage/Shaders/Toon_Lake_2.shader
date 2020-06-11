// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0,5,fgcg:0,5,fgcb:0,5,fgca:1,fgde:0,01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:33004,y:32457,varname:node_2865,prsc:2|diff-5119-OUT,emission-5119-OUT;n:type:ShaderForge.SFN_Multiply,id:6343,x:31818,y:32808,varname:node_6343,prsc:2|A-7736-RGB,B-6665-RGB;n:type:ShaderForge.SFN_Color,id:6665,x:31625,y:32901,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,5019608,c2:0,5019608,c3:0,5019608,c4:1;n:type:ShaderForge.SFN_Tex2d,id:7736,x:31625,y:32716,ptovrint:True,ptlb:Base Color,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_DepthBlend,id:4297,x:32354,y:32339,varname:node_4297,prsc:2|DIST-9095-OUT;n:type:ShaderForge.SFN_Slider,id:9095,x:31822,y:32323,ptovrint:False,ptlb:node_9095,ptin:_node_9095,varname:node_9095,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:108,094,max:200;n:type:ShaderForge.SFN_Lerp,id:5119,x:32654,y:32393,varname:node_5119,prsc:2|A-1075-RGB,B-9933-RGB,T-4297-OUT;n:type:ShaderForge.SFN_Color,id:1075,x:32354,y:32180,ptovrint:False,ptlb:node_1075,ptin:_node_1075,varname:node_1075,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,1367925,c3:0,1367925,c4:1;n:type:ShaderForge.SFN_Color,id:9933,x:32354,y:32497,ptovrint:False,ptlb:node_1075_copy,ptin:_node_1075_copy,varname:_node_1075_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,1372549,c2:0,2116941,c3:1,c4:1;n:type:ShaderForge.SFN_ScreenPos,id:3383,x:32002,y:32663,varname:node_3383,prsc:2,sctp:0;n:type:ShaderForge.SFN_ComponentMask,id:5771,x:32207,y:32663,varname:node_5771,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-3383-UVOUT;n:type:ShaderForge.SFN_Subtract,id:8256,x:32271,y:32815,varname:node_8256,prsc:2|A-5771-OUT,B-9095-OUT;proporder:6665-7736-9095-1075-9933;pass:END;sub:END;*/

Shader "Shader Forge/Toon_Lake_2" {
    Properties {
        _Color ("Color", Color) = (0,5019608,0,5019608,0,5019608,1)
        _MainTex ("Base Color", 2D) = "white" {}
        _node_9095 ("node_9095", Range(0, 200)) = 108,094
        _node_1075 ("node_1075", Color) = (1,0,1367925,0,1367925,1)
        _node_1075_copy ("node_1075_copy", Color) = (0,1372549,0,2116941,1,1)
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define _GLOSSYENV 1
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma target 3.0
            uniform sampler2D _CameraDepthTexture;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _node_9095)
                UNITY_DEFINE_INSTANCED_PROP( float4, _node_1075)
                UNITY_DEFINE_INSTANCED_PROP( float4, _node_1075_copy)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 projPos : TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
////// Lighting:
////// Emissive:
                float4 _node_1075_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_1075 );
                float4 _node_1075_copy_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_1075_copy );
                float _node_9095_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_9095 );
                float3 node_5119 = lerp(_node_1075_var.rgb,_node_1075_copy_var.rgb,saturate((sceneZ-partZ)/_node_9095_var));
                float3 emissive = node_5119;
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #define _GLOSSYENV 1
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma target 3.0
            uniform sampler2D _CameraDepthTexture;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _node_9095)
                UNITY_DEFINE_INSTANCED_PROP( float4, _node_1075)
                UNITY_DEFINE_INSTANCED_PROP( float4, _node_1075_copy)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 projPos : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                UNITY_SETUP_INSTANCE_ID( i );
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                float4 _node_1075_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_1075 );
                float4 _node_1075_copy_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_1075_copy );
                float _node_9095_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_9095 );
                float3 node_5119 = lerp(_node_1075_var.rgb,_node_1075_copy_var.rgb,saturate((sceneZ-partZ)/_node_9095_var));
                o.Emission = node_5119;
                
                float3 diffColor = float3(0,0,0);
                o.Albedo = diffColor;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
