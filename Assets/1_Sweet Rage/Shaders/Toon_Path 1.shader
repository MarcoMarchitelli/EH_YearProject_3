// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32292,y:32580,varname:node_3138,prsc:2|emission-3494-OUT,alpha-9455-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:31603,y:32790,ptovrint:False,ptlb:_Tint,ptin:__Tint,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Tex2d,id:9169,x:31603,y:32572,ptovrint:False,ptlb:_MainTex,ptin:__MainTex,varname:node_9169,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:29f6c6973db33ef4a87eccafeddf07e7,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:9920,x:31914,y:32622,varname:node_9920,prsc:2|A-9169-RGB,B-7241-RGB;n:type:ShaderForge.SFN_Multiply,id:9455,x:31865,y:32814,varname:node_9455,prsc:2|A-9169-A,B-7241-A;n:type:ShaderForge.SFN_Multiply,id:3494,x:32101,y:32646,varname:node_3494,prsc:2|A-9920-OUT,B-9455-OUT;proporder:7241-9169;pass:END;sub:END;*/

Shader "Shader Forge/Toon_jelly_2" {
    Properties {
        __Tint ("_Tint", Color) = (1,1,1,1)
        __MainTex ("_MainTex", 2D) = "white" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma target 3.0
            uniform sampler2D __MainTex; uniform float4 __MainTex_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, __Tint)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
////// Lighting:
////// Emissive:
                float4 __MainTex_var = tex2D(__MainTex,TRANSFORM_TEX(i.uv0, __MainTex));
                float4 __Tint_var = UNITY_ACCESS_INSTANCED_PROP( Props, __Tint );
                float node_9455 = (__MainTex_var.a*__Tint_var.a);
                float3 emissive = ((__MainTex_var.rgb*__Tint_var.rgb)*node_9455);
                float3 finalColor = emissive;
                return fixed4(finalColor,node_9455);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
