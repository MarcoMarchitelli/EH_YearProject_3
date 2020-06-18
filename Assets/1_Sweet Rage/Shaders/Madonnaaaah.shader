// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32737,y:32577,varname:node_3138,prsc:2|emission-7504-RGB,voffset-7042-OUT;n:type:ShaderForge.SFN_Time,id:8592,x:31357,y:32962,varname:node_8592,prsc:2;n:type:ShaderForge.SFN_Multiply,id:5310,x:31665,y:32847,varname:node_5310,prsc:2|A-2830-OUT,B-8592-TSL;n:type:ShaderForge.SFN_Slider,id:2830,x:31357,y:32799,ptovrint:False,ptlb:Speed,ptin:_Speed,varname:node_2830,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:100;n:type:ShaderForge.SFN_Sin,id:1015,x:32256,y:32945,varname:node_1015,prsc:2|IN-9453-OUT;n:type:ShaderForge.SFN_Multiply,id:7042,x:32498,y:32945,varname:node_7042,prsc:2|A-1015-OUT,B-5538-XYZ;n:type:ShaderForge.SFN_Vector4Property,id:5538,x:32256,y:33110,ptovrint:False,ptlb:Offset Strength,ptin:_OffsetStrength,varname:node_5538,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0,v2:0,v3:0,v4:0;n:type:ShaderForge.SFN_Tex2d,id:7504,x:32128,y:32573,ptovrint:False,ptlb:no,ptin:_no,varname:node_7504,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_ObjectPosition,id:4328,x:31432,y:33171,varname:node_4328,prsc:2;n:type:ShaderForge.SFN_Add,id:9453,x:31918,y:32888,varname:node_9453,prsc:2|A-5310-OUT,B-7868-OUT;n:type:ShaderForge.SFN_Multiply,id:7868,x:31588,y:33117,varname:node_7868,prsc:2|A-4328-X,B-4328-Z;proporder:2830-5538-7504;pass:END;sub:END;*/

Shader "Shader Forge/Toon_floating" {
    Properties {
        _Speed ("Speed", Range(0, 100)) = 0
        _OffsetStrength ("Offset Strength", Vector) = (0,0,0,0)
        _no ("no", 2D) = "white" {}
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
            uniform sampler2D _no; uniform float4 _no_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _Speed)
                UNITY_DEFINE_INSTANCED_PROP( float4, _OffsetStrength)
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
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                float _Speed_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Speed );
                float4 node_8592 = _Time;
                float4 _OffsetStrength_var = UNITY_ACCESS_INSTANCED_PROP( Props, _OffsetStrength );
                v.vertex.xyz += (sin(((_Speed_var*node_8592.r)+(objPos.r*objPos.b)))*_OffsetStrength_var.rgb);
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
////// Lighting:
////// Emissive:
                float4 _no_var = tex2D(_no,TRANSFORM_TEX(i.uv0, _no));
                float3 emissive = _no_var.rgb;
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
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma target 3.0
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _Speed)
                UNITY_DEFINE_INSTANCED_PROP( float4, _OffsetStrength)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                float _Speed_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Speed );
                float4 node_8592 = _Time;
                float4 _OffsetStrength_var = UNITY_ACCESS_INSTANCED_PROP( Props, _OffsetStrength );
                v.vertex.xyz += (sin(((_Speed_var*node_8592.r)+(objPos.r*objPos.b)))*_OffsetStrength_var.rgb);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
