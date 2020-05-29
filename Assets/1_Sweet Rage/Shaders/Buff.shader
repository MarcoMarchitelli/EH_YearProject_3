// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32969,y:32533,varname:node_3138,prsc:2|emission-3812-OUT,alpha-4507-OUT,voffset-1549-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:32095,y:32381,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.07843138,c2:0.3921569,c3:0.7843137,c4:1;n:type:ShaderForge.SFN_Tex2d,id:9094,x:31529,y:32883,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:node_9094,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-381-UVOUT;n:type:ShaderForge.SFN_Multiply,id:4507,x:32640,y:32727,varname:node_4507,prsc:2|A-7241-A,B-5781-OUT;n:type:ShaderForge.SFN_Panner,id:381,x:31311,y:32883,varname:node_381,prsc:2,spu:0,spv:1|UVIN-5964-UVOUT,DIST-4216-OUT;n:type:ShaderForge.SFN_TexCoord,id:5964,x:31425,y:32542,varname:node_5964,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Slider,id:6721,x:30734,y:32920,ptovrint:False,ptlb:Pan Speed,ptin:_PanSpeed,varname:node_6721,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-100,cur:0,max:100;n:type:ShaderForge.SFN_Time,id:765,x:30891,y:33035,varname:node_765,prsc:2;n:type:ShaderForge.SFN_Multiply,id:4216,x:31102,y:32980,varname:node_4216,prsc:2|A-6721-OUT,B-765-TSL;n:type:ShaderForge.SFN_Slider,id:6680,x:31711,y:33065,ptovrint:False,ptlb:Vertical Displacement Strength,ptin:_VerticalDisplacementStrength,varname:node_6680,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:4.230769,max:15;n:type:ShaderForge.SFN_Multiply,id:1549,x:32538,y:32975,varname:node_1549,prsc:2|A-6197-OUT,B-6680-OUT,C-7733-OUT;n:type:ShaderForge.SFN_NormalVector,id:7733,x:31868,y:33153,prsc:2,pt:False;n:type:ShaderForge.SFN_Length,id:1429,x:31854,y:32544,varname:node_1429,prsc:2|IN-6247-OUT;n:type:ShaderForge.SFN_RemapRange,id:6247,x:31656,y:32544,varname:node_6247,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-5964-UVOUT;n:type:ShaderForge.SFN_OneMinus,id:5781,x:32095,y:32589,varname:node_5781,prsc:2|IN-1429-OUT;n:type:ShaderForge.SFN_Multiply,id:3812,x:32640,y:32520,varname:node_3812,prsc:2|A-7241-RGB,B-5781-OUT;n:type:ShaderForge.SFN_Slider,id:3074,x:31841,y:32832,ptovrint:False,ptlb:Base,ptin:_Base,varname:node_3074,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0,max:1;n:type:ShaderForge.SFN_Min,id:6197,x:32294,y:32683,varname:node_6197,prsc:2|A-5781-OUT,B-3074-OUT;proporder:7241-9094-6721-6680-3074;pass:END;sub:END;*/

Shader "Shader Forge/Buff" {
    Properties {
        _Color ("Color", Color) = (0.07843138,0.3921569,0.7843137,1)
        _MainTex ("MainTex", 2D) = "white" {}
        _PanSpeed ("Pan Speed", Range(-100, 100)) = 0
        _VerticalDisplacementStrength ("Vertical Displacement Strength", Range(0, 15)) = 4.230769
        _Base ("Base", Range(-1, 1)) = 0
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
            Blend One OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma target 3.0
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _Color)
                UNITY_DEFINE_INSTANCED_PROP( float, _VerticalDisplacementStrength)
                UNITY_DEFINE_INSTANCED_PROP( float, _Base)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float2 uv0 : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float node_5781 = (1.0 - length((o.uv0*2.0+-1.0)));
                float _Base_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Base );
                float _VerticalDisplacementStrength_var = UNITY_ACCESS_INSTANCED_PROP( Props, _VerticalDisplacementStrength );
                v.vertex.xyz += (min(node_5781,_Base_var)*_VerticalDisplacementStrength_var*v.normal);
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
////// Lighting:
////// Emissive:
                float4 _Color_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Color );
                float node_5781 = (1.0 - length((i.uv0*2.0+-1.0)));
                float3 emissive = (_Color_var.rgb*node_5781);
                float3 finalColor = emissive;
                return fixed4(finalColor,(_Color_var.a*node_5781));
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
                UNITY_DEFINE_INSTANCED_PROP( float, _VerticalDisplacementStrength)
                UNITY_DEFINE_INSTANCED_PROP( float, _Base)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float2 uv0 : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float node_5781 = (1.0 - length((o.uv0*2.0+-1.0)));
                float _Base_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Base );
                float _VerticalDisplacementStrength_var = UNITY_ACCESS_INSTANCED_PROP( Props, _VerticalDisplacementStrength );
                v.vertex.xyz += (min(node_5781,_Base_var)*_VerticalDisplacementStrength_var*v.normal);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
