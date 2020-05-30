// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32456,y:32385,varname:node_3138,prsc:2|emission-3812-OUT,alpha-4507-OUT,voffset-1549-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:31767,y:32175,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.07843138,c2:0.3921569,c3:0.7843137,c4:1;n:type:ShaderForge.SFN_Tex2d,id:9094,x:31728,y:32671,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:node_9094,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-2711-OUT;n:type:ShaderForge.SFN_Multiply,id:4507,x:32110,y:32602,varname:node_4507,prsc:2|A-7241-A,B-5781-OUT,C-9094-R;n:type:ShaderForge.SFN_TexCoord,id:5964,x:30560,y:32652,varname:node_5964,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Slider,id:6721,x:30587,y:32217,ptovrint:False,ptlb:Pan Speed,ptin:_PanSpeed,varname:node_6721,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-100,cur:0,max:100;n:type:ShaderForge.SFN_Slider,id:6680,x:31649,y:32928,ptovrint:False,ptlb:Vertical Displacement Strength,ptin:_VerticalDisplacementStrength,varname:node_6680,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-15,cur:-15,max:15;n:type:ShaderForge.SFN_Multiply,id:1549,x:32110,y:32830,varname:node_1549,prsc:2|A-6197-OUT,B-6680-OUT,C-7733-OUT;n:type:ShaderForge.SFN_NormalVector,id:7733,x:31806,y:33016,prsc:2,pt:False;n:type:ShaderForge.SFN_Length,id:1429,x:30988,y:32501,varname:node_1429,prsc:2|IN-6247-OUT;n:type:ShaderForge.SFN_RemapRange,id:6247,x:30776,y:32652,varname:node_6247,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-5964-UVOUT;n:type:ShaderForge.SFN_OneMinus,id:5781,x:31178,y:32501,varname:node_5781,prsc:2|IN-1429-OUT;n:type:ShaderForge.SFN_Multiply,id:3812,x:32110,y:32461,varname:node_3812,prsc:2|A-7241-RGB,B-5781-OUT,C-9094-RGB;n:type:ShaderForge.SFN_Slider,id:3074,x:31306,y:32250,ptovrint:False,ptlb:Base,ptin:_Base,varname:node_3074,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0.07738319,max:1;n:type:ShaderForge.SFN_Min,id:6197,x:31705,y:32392,varname:node_6197,prsc:2|A-3074-OUT,B-5781-OUT;n:type:ShaderForge.SFN_Append,id:2711,x:31548,y:32671,varname:node_2711,prsc:2|A-7973-OUT,B-5368-OUT;n:type:ShaderForge.SFN_ArcTan2,id:7973,x:31178,y:32659,varname:node_7973,prsc:2,attp:2|A-8918-G,B-8918-R;n:type:ShaderForge.SFN_ComponentMask,id:8918,x:30988,y:32659,varname:node_8918,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-6247-OUT;n:type:ShaderForge.SFN_Time,id:6780,x:30744,y:32352,varname:node_6780,prsc:2;n:type:ShaderForge.SFN_Multiply,id:1924,x:30988,y:32329,varname:node_1924,prsc:2|A-6721-OUT,B-6780-TSL;n:type:ShaderForge.SFN_Add,id:2161,x:31407,y:32820,varname:node_2161,prsc:2;n:type:ShaderForge.SFN_Add,id:5368,x:31364,y:32548,varname:node_5368,prsc:2|A-1924-OUT,B-5781-OUT;proporder:7241-9094-6721-6680-3074;pass:END;sub:END;*/

Shader "Shader Forge/Buff" {
    Properties {
        _Color ("Color", Color) = (0.07843138,0.3921569,0.7843137,1)
        _MainTex ("MainTex", 2D) = "white" {}
        _PanSpeed ("Pan Speed", Range(-100, 100)) = 0
        _VerticalDisplacementStrength ("Vertical Displacement Strength", Range(-15, 15)) = -15
        _Base ("Base", Range(-1, 1)) = 0.07738319
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
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _Color)
                UNITY_DEFINE_INSTANCED_PROP( float, _PanSpeed)
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
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float _Base_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Base );
                float2 node_6247 = (o.uv0*2.0+-1.0);
                float node_5781 = (1.0 - length(node_6247));
                float _VerticalDisplacementStrength_var = UNITY_ACCESS_INSTANCED_PROP( Props, _VerticalDisplacementStrength );
                v.vertex.xyz += (min(_Base_var,node_5781)*_VerticalDisplacementStrength_var*v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
////// Lighting:
////// Emissive:
                float4 _Color_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Color );
                float2 node_6247 = (i.uv0*2.0+-1.0);
                float node_5781 = (1.0 - length(node_6247));
                float2 node_8918 = node_6247.rg;
                float _PanSpeed_var = UNITY_ACCESS_INSTANCED_PROP( Props, _PanSpeed );
                float4 node_6780 = _Time;
                float2 node_2711 = float2(((atan2(node_8918.g,node_8918.r)/6.28318530718)+0.5),((_PanSpeed_var*node_6780.r)+node_5781));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_2711, _MainTex));
                float3 emissive = (_Color_var.rgb*node_5781*_MainTex_var.rgb);
                float3 finalColor = emissive;
                return fixed4(finalColor,(_Color_var.a*node_5781*_MainTex_var.r));
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Off
            
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
                float4 posWorld : TEXCOORD2;
                float3 normalDir : TEXCOORD3;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float _Base_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Base );
                float2 node_6247 = (o.uv0*2.0+-1.0);
                float node_5781 = (1.0 - length(node_6247));
                float _VerticalDisplacementStrength_var = UNITY_ACCESS_INSTANCED_PROP( Props, _VerticalDisplacementStrength );
                v.vertex.xyz += (min(_Base_var,node_5781)*_VerticalDisplacementStrength_var*v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
