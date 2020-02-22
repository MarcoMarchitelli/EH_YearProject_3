// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33427,y:32744,varname:node_3138,prsc:2|emission-4955-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:32876,y:32994,ptovrint:False,ptlb:Tint,ptin:_Tint,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Tex2d,id:1462,x:32467,y:32609,ptovrint:False,ptlb:Noise,ptin:_Noise,varname:node_1462,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:823e7c28cc03ddd419c3cb88304fd935,ntxv:0,isnm:False|UVIN-4648-UVOUT;n:type:ShaderForge.SFN_Normalize,id:7942,x:32667,y:32609,varname:node_7942,prsc:2|IN-1462-RGB;n:type:ShaderForge.SFN_Dot,id:7141,x:32875,y:32690,varname:node_7141,prsc:2,dt:0|A-7942-OUT,B-861-OUT;n:type:ShaderForge.SFN_Multiply,id:4955,x:33121,y:32827,varname:node_4955,prsc:2|A-7141-OUT,B-7241-RGB;n:type:ShaderForge.SFN_ViewVector,id:861,x:32667,y:32782,varname:node_861,prsc:2;n:type:ShaderForge.SFN_UVTile,id:4648,x:32291,y:32609,varname:node_4648,prsc:2|WDT-2801-OUT,HGT-2994-OUT,TILE-7118-OUT;n:type:ShaderForge.SFN_Vector1,id:9758,x:32068,y:32571,varname:node_9758,prsc:2,v1:20;n:type:ShaderForge.SFN_Slider,id:2801,x:31911,y:32484,ptovrint:False,ptlb:Tiling,ptin:_Tiling,varname:node_2801,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1794872,max:1;n:type:ShaderForge.SFN_Vector1,id:7118,x:32068,y:32717,varname:node_7118,prsc:2,v1:0;n:type:ShaderForge.SFN_Slider,id:2994,x:31975,y:32548,ptovrint:False,ptlb:Tiling_copy,ptin:_Tiling_copy,varname:_Tiling_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1794872,max:1;proporder:7241-1462-2801-2994;pass:END;sub:END;*/

Shader "Shader Forge/Sparkles" {
    Properties {
        _Tint ("Tint", Color) = (1,1,1,1)
        _Noise ("Noise", 2D) = "white" {}
        _Tiling ("Tiling", Range(0, 1)) = 0.1794872
        _Tiling_copy ("Tiling_copy", Range(0, 1)) = 0.1794872
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
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma target 3.0
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _Tint)
                UNITY_DEFINE_INSTANCED_PROP( float, _Tiling)
                UNITY_DEFINE_INSTANCED_PROP( float, _Tiling_copy)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
////// Lighting:
////// Emissive:
                float _Tiling_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Tiling );
                float _Tiling_copy_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Tiling_copy );
                float node_7118 = 0.0;
                float2 node_4648_tc_rcp = float2(1.0,1.0)/float2( _Tiling_var, _Tiling_copy_var );
                float node_4648_ty = floor(node_7118 * node_4648_tc_rcp.x);
                float node_4648_tx = node_7118 - _Tiling_var * node_4648_ty;
                float2 node_4648 = (i.uv0 + float2(node_4648_tx, node_4648_ty)) * node_4648_tc_rcp;
                float4 _Noise_var = tex2D(_Noise,TRANSFORM_TEX(node_4648, _Noise));
                float4 _Tint_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Tint );
                float3 emissive = (dot(normalize(_Noise_var.rgb),viewDirection)*_Tint_var.rgb);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
