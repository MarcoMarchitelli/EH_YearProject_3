// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0,5,fgcg:0,5,fgcb:0,5,fgca:1,fgde:0,01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33066,y:32646,varname:node_3138,prsc:2|emission-8848-RGB,voffset-3963-OUT;n:type:ShaderForge.SFN_Time,id:8046,x:31810,y:32998,varname:node_8046,prsc:2;n:type:ShaderForge.SFN_Sin,id:2286,x:32088,y:33030,varname:node_2286,prsc:2|IN-8046-T;n:type:ShaderForge.SFN_FragmentPosition,id:9963,x:32066,y:32768,varname:node_9963,prsc:2;n:type:ShaderForge.SFN_Multiply,id:509,x:32313,y:32945,varname:node_509,prsc:2|A-9963-Y,B-2286-OUT;n:type:ShaderForge.SFN_Append,id:3963,x:32644,y:32854,varname:node_3963,prsc:2|A-9963-X,B-2345-OUT,C-9963-Z;n:type:ShaderForge.SFN_Add,id:2345,x:32294,y:33094,varname:node_2345,prsc:2|A-9963-Y,B-2286-OUT;n:type:ShaderForge.SFN_Tex2d,id:8848,x:32545,y:32555,ptovrint:False,ptlb:node_8848,ptin:_node_8848,varname:node_8848,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:29f6c6973db33ef4a87eccafeddf07e7,ntxv:0,isnm:False;proporder:8848;pass:END;sub:END;*/

Shader "Shader Forge/cartman" {
    Properties {
        _node_8848 ("node_8848", 2D) = "white" {}
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
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma target 3.0
            uniform sampler2D _node_8848; uniform float4 _node_8848_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                float4 node_8046 = _Time;
                float node_2286 = sin(node_8046.g);
                v.vertex.xyz += float3(mul(unity_ObjectToWorld, v.vertex).r,(mul(unity_ObjectToWorld, v.vertex).g+node_2286),mul(unity_ObjectToWorld, v.vertex).b);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 _node_8848_var = tex2D(_node_8848,TRANSFORM_TEX(i.uv0, _node_8848));
                float3 emissive = _node_8848_var.rgb;
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Back
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma target 3.0
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float4 posWorld : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                float4 node_8046 = _Time;
                float node_2286 = sin(node_8046.g);
                v.vertex.xyz += float3(mul(unity_ObjectToWorld, v.vertex).r,(mul(unity_ObjectToWorld, v.vertex).g+node_2286),mul(unity_ObjectToWorld, v.vertex).b);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
