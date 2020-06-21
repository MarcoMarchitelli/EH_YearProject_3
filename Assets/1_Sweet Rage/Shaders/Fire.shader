// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:34553,y:32863,varname:node_3138,prsc:2|emission-8209-OUT,voffset-7208-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:33561,y:32962,ptovrint:False,ptlb:TintA,ptin:_TintA,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.07843138,c2:0.3921569,c3:0.7843137,c4:1;n:type:ShaderForge.SFN_Tex2d,id:4153,x:33692,y:32637,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:node_4153,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_VertexColor,id:6488,x:33692,y:32830,varname:node_6488,prsc:2;n:type:ShaderForge.SFN_Multiply,id:8209,x:34251,y:32983,varname:node_8209,prsc:2|A-4153-RGB,B-6488-RGB,C-8802-OUT;n:type:ShaderForge.SFN_TexCoord,id:1885,x:32844,y:33114,varname:node_1885,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Add,id:3739,x:33107,y:33217,varname:node_3739,prsc:2|A-1885-V,B-8963-OUT;n:type:ShaderForge.SFN_Slider,id:5168,x:32479,y:33296,ptovrint:False,ptlb:Scroll Speed,ptin:_ScrollSpeed,varname:node_5168,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.3850937,max:50;n:type:ShaderForge.SFN_Time,id:776,x:32636,y:33403,varname:node_776,prsc:2;n:type:ShaderForge.SFN_Multiply,id:8963,x:32844,y:33334,varname:node_8963,prsc:2|A-5168-OUT,B-776-TSL;n:type:ShaderForge.SFN_Multiply,id:4536,x:33368,y:33341,varname:node_4536,prsc:2|A-3739-OUT,B-8505-OUT,C-3953-OUT;n:type:ShaderForge.SFN_Tau,id:8505,x:33140,y:33354,varname:node_8505,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:3953,x:33107,y:33505,ptovrint:False,ptlb:Sine Cycles,ptin:_SineCycles,varname:node_3953,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2.5;n:type:ShaderForge.SFN_Sin,id:2783,x:33561,y:33341,varname:node_2783,prsc:2|IN-4536-OUT;n:type:ShaderForge.SFN_NormalVector,id:7449,x:33768,y:33520,prsc:2,pt:False;n:type:ShaderForge.SFN_RemapRange,id:6948,x:33768,y:33341,varname:node_6948,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-2783-OUT;n:type:ShaderForge.SFN_Multiply,id:7208,x:34010,y:33493,varname:node_7208,prsc:2|A-6948-OUT,B-7449-OUT,C-6703-OUT;n:type:ShaderForge.SFN_Slider,id:6703,x:33611,y:33709,ptovrint:False,ptlb:Dipsplacement Strength,ptin:_DipsplacementStrength,varname:node_6703,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2348132,max:1;n:type:ShaderForge.SFN_Color,id:3224,x:33561,y:33146,ptovrint:False,ptlb:TintB,ptin:_TintB,varname:_TintA_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.07843138,c2:0.3921569,c3:0.7843137,c4:1;n:type:ShaderForge.SFN_Lerp,id:8802,x:34015,y:33084,varname:node_8802,prsc:2|A-7241-RGB,B-3224-RGB,T-6948-OUT;proporder:4153-7241-3224-5168-3953-6703;pass:END;sub:END;*/

Shader "Shader Forge/Fire" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _TintA ("TintA", Color) = (0.07843138,0.3921569,0.7843137,1)
        _TintB ("TintB", Color) = (0.07843138,0.3921569,0.7843137,1)
        _ScrollSpeed ("Scroll Speed", Range(0, 50)) = 0.3850937
        _SineCycles ("Sine Cycles", Float ) = 2.5
        _DipsplacementStrength ("Dipsplacement Strength", Range(0, 1)) = 0.2348132
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
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _TintA)
                UNITY_DEFINE_INSTANCED_PROP( float, _ScrollSpeed)
                UNITY_DEFINE_INSTANCED_PROP( float, _SineCycles)
                UNITY_DEFINE_INSTANCED_PROP( float, _DipsplacementStrength)
                UNITY_DEFINE_INSTANCED_PROP( float4, _TintB)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float2 uv0 : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float _ScrollSpeed_var = UNITY_ACCESS_INSTANCED_PROP( Props, _ScrollSpeed );
                float4 node_776 = _Time;
                float _SineCycles_var = UNITY_ACCESS_INSTANCED_PROP( Props, _SineCycles );
                float node_6948 = (sin(((o.uv0.g+(_ScrollSpeed_var*node_776.r))*6.28318530718*_SineCycles_var))*0.5+0.5);
                float _DipsplacementStrength_var = UNITY_ACCESS_INSTANCED_PROP( Props, _DipsplacementStrength );
                v.vertex.xyz += (node_6948*v.normal*_DipsplacementStrength_var);
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
////// Lighting:
////// Emissive:
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float4 _TintA_var = UNITY_ACCESS_INSTANCED_PROP( Props, _TintA );
                float4 _TintB_var = UNITY_ACCESS_INSTANCED_PROP( Props, _TintB );
                float _ScrollSpeed_var = UNITY_ACCESS_INSTANCED_PROP( Props, _ScrollSpeed );
                float4 node_776 = _Time;
                float _SineCycles_var = UNITY_ACCESS_INSTANCED_PROP( Props, _SineCycles );
                float node_6948 = (sin(((i.uv0.g+(_ScrollSpeed_var*node_776.r))*6.28318530718*_SineCycles_var))*0.5+0.5);
                float3 emissive = (_MainTex_var.rgb*i.vertexColor.rgb*lerp(_TintA_var.rgb,_TintB_var.rgb,node_6948));
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
                UNITY_DEFINE_INSTANCED_PROP( float, _ScrollSpeed)
                UNITY_DEFINE_INSTANCED_PROP( float, _SineCycles)
                UNITY_DEFINE_INSTANCED_PROP( float, _DipsplacementStrength)
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
                float _ScrollSpeed_var = UNITY_ACCESS_INSTANCED_PROP( Props, _ScrollSpeed );
                float4 node_776 = _Time;
                float _SineCycles_var = UNITY_ACCESS_INSTANCED_PROP( Props, _SineCycles );
                float node_6948 = (sin(((o.uv0.g+(_ScrollSpeed_var*node_776.r))*6.28318530718*_SineCycles_var))*0.5+0.5);
                float _DipsplacementStrength_var = UNITY_ACCESS_INSTANCED_PROP( Props, _DipsplacementStrength );
                v.vertex.xyz += (node_6948*v.normal*_DipsplacementStrength_var);
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
