// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:34831,y:32473,varname:node_9361,prsc:2|emission-982-RGB,voffset-756-OUT;n:type:ShaderForge.SFN_LightAttenuation,id:8068,x:32555,y:33190,varname:node_8068,prsc:2;n:type:ShaderForge.SFN_LightColor,id:3406,x:32555,y:32859,varname:node_3406,prsc:2;n:type:ShaderForge.SFN_LightVector,id:6869,x:30854,y:32584,varname:node_6869,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:9684,x:30854,y:32712,prsc:2,pt:True;n:type:ShaderForge.SFN_Dot,id:7782,x:31056,y:32645,cmnt:Lambert,varname:node_7782,prsc:2,dt:0|A-6869-OUT,B-9684-OUT;n:type:ShaderForge.SFN_Tex2d,id:851,x:32556,y:32692,ptovrint:False,ptlb:Lighting Palette,ptin:_LightingPalette,varname:node_851,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-9916-OUT;n:type:ShaderForge.SFN_Color,id:5927,x:32148,y:32402,ptovrint:False,ptlb:Tint,ptin:_Tint,varname:node_5927,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:5085,x:33145,y:32873,cmnt:Attenuate and Color,varname:node_5085,prsc:2|A-8820-OUT,B-1478-OUT,C-5861-OUT,D-8305-OUT;n:type:ShaderForge.SFN_Slider,id:4581,x:33112,y:33134,ptovrint:False,ptlb:Outline Width,ptin:_OutlineWidth,varname:node_4581,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1216387,max:1;n:type:ShaderForge.SFN_Append,id:9916,x:31784,y:32744,varname:node_9916,prsc:2|A-7468-OUT,B-1975-OUT;n:type:ShaderForge.SFN_Vector1,id:1975,x:31429,y:32835,varname:node_1975,prsc:2,v1:0;n:type:ShaderForge.SFN_OneMinus,id:7468,x:31429,y:32645,varname:node_7468,prsc:2|IN-427-OUT;n:type:ShaderForge.SFN_RemapRange,id:427,x:31245,y:32645,varname:node_427,prsc:2,frmn:-1,frmx:1,tomn:0.01,tomx:0.99|IN-7782-OUT;n:type:ShaderForge.SFN_Slider,id:3455,x:32148,y:32611,ptovrint:False,ptlb:Lighting Palette Intensity,ptin:_LightingPaletteIntensity,varname:node_3455,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:8820,x:32776,y:32423,varname:node_8820,prsc:2|A-3821-RGB,B-5927-RGB;n:type:ShaderForge.SFN_Add,id:1478,x:32776,y:32599,varname:node_1478,prsc:2|A-851-RGB,B-3455-OUT;n:type:ShaderForge.SFN_Slider,id:6007,x:32398,y:33370,ptovrint:False,ptlb:Light Attenuation Intensity,ptin:_LightAttenuationIntensity,varname:node_6007,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Slider,id:654,x:32398,y:33014,ptovrint:False,ptlb:Light Color Intensity,ptin:_LightColorIntensity,varname:_LightAttenuationIntensity_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Lerp,id:5861,x:32782,y:32891,varname:node_5861,prsc:2|A-6989-OUT,B-3406-RGB,T-654-OUT;n:type:ShaderForge.SFN_Vector1,id:6989,x:32555,y:33097,varname:node_6989,prsc:2,v1:1;n:type:ShaderForge.SFN_Lerp,id:8305,x:32782,y:33117,varname:node_8305,prsc:2|A-6989-OUT,B-8068-OUT,T-6007-OUT;n:type:ShaderForge.SFN_Color,id:7832,x:33269,y:33245,ptovrint:False,ptlb:Outline Color,ptin:_OutlineColor,varname:node_7832,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_TexCoord,id:6369,x:30694,y:31701,varname:node_6369,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Add,id:9151,x:31360,y:32011,varname:node_9151,prsc:2|A-9371-OUT,B-2448-OUT;n:type:ShaderForge.SFN_Append,id:9658,x:31592,y:32098,varname:node_9658,prsc:2|A-9151-OUT,B-5242-OUT;n:type:ShaderForge.SFN_Time,id:9,x:30838,y:32179,varname:node_9,prsc:2;n:type:ShaderForge.SFN_Multiply,id:2448,x:31070,y:32023,varname:node_2448,prsc:2|A-4382-X,B-9-T;n:type:ShaderForge.SFN_Multiply,id:6646,x:31070,y:32179,varname:node_6646,prsc:2|A-9-T,B-4382-Y;n:type:ShaderForge.SFN_Add,id:5242,x:31360,y:32169,varname:node_5242,prsc:2|A-4662-OUT,B-6646-OUT;n:type:ShaderForge.SFN_Vector4Property,id:4382,x:30694,y:32079,ptovrint:False,ptlb:Scroll,ptin:_Scroll,varname:node_4382,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0,v2:0,v3:0,v4:0;n:type:ShaderForge.SFN_Vector4Property,id:2550,x:30694,y:31884,ptovrint:False,ptlb:Stretch,ptin:_Stretch,varname:_Scroll_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0,v2:0,v3:0,v4:0;n:type:ShaderForge.SFN_Multiply,id:9371,x:31070,y:31720,varname:node_9371,prsc:2|A-6369-U,B-2550-X;n:type:ShaderForge.SFN_Multiply,id:4662,x:31070,y:31875,varname:node_4662,prsc:2|A-6369-V,B-2550-Y;n:type:ShaderForge.SFN_Tex2d,id:3821,x:31799,y:32098,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:node_3821,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-9658-OUT;n:type:ShaderForge.SFN_Slider,id:3373,x:32509,y:31706,ptovrint:False,ptlb:speed,ptin:_speed,varname:node_3373,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Multiply,id:756,x:33912,y:31926,varname:node_756,prsc:2|A-3288-RGB,B-8618-OUT,C-1147-OUT;n:type:ShaderForge.SFN_NormalVector,id:8618,x:33134,y:31872,prsc:2,pt:False;n:type:ShaderForge.SFN_Slider,id:1147,x:33125,y:32073,ptovrint:False,ptlb:heigth_noise,ptin:_heigth_noise,varname:node_1147,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2,max:2;n:type:ShaderForge.SFN_Tex2d,id:3288,x:33734,y:31472,varname:node_3288,prsc:2,tex:56557ffeaec2d31438982279b99fdfa1,ntxv:0,isnm:False|UVIN-2308-UVOUT,TEX-8657-TEX;n:type:ShaderForge.SFN_Panner,id:2308,x:33087,y:31351,varname:node_2308,prsc:2,spu:0,spv:1|UVIN-2417-UVOUT,DIST-372-OUT;n:type:ShaderForge.SFN_Multiply,id:372,x:32868,y:31565,varname:node_372,prsc:2|A-3169-TSL,B-3373-OUT;n:type:ShaderForge.SFN_TexCoord,id:2417,x:32767,y:31240,varname:node_2417,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Time,id:3169,x:32537,y:31455,varname:node_3169,prsc:2;n:type:ShaderForge.SFN_Tex2dAsset,id:8657,x:33511,y:31600,ptovrint:False,ptlb:node_8657,ptin:_node_8657,varname:node_8657,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:56557ffeaec2d31438982279b99fdfa1,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:982,x:33767,y:32153,ptovrint:False,ptlb:node_4630_copy,ptin:_node_4630_copy,varname:_node_4630_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;proporder:851-5927-4581-3455-6007-654-7832-4382-2550-3821-3373-1147-8657-982;pass:END;sub:END;*/

Shader "Shader Forge/Toon_Lake" {
    Properties {
        _LightingPalette ("Lighting Palette", 2D) = "white" {}
        _Tint ("Tint", Color) = (1,1,1,1)
        _OutlineWidth ("Outline Width", Range(0, 1)) = 0.1216387
        _LightingPaletteIntensity ("Lighting Palette Intensity", Range(-1, 1)) = 0
        _LightAttenuationIntensity ("Light Attenuation Intensity", Range(0, 1)) = 1
        _LightColorIntensity ("Light Color Intensity", Range(0, 1)) = 0
        _OutlineColor ("Outline Color", Color) = (0,0,0,1)
        _Scroll ("Scroll", Vector) = (0,0,0,0)
        _Stretch ("Stretch", Vector) = (0,0,0,0)
        _MainTex ("MainTex", 2D) = "white" {}
        _speed ("speed", Range(0, 1)) = 1
        _heigth_noise ("heigth_noise", Range(0, 2)) = 2
        _node_8657 ("node_8657", 2D) = "white" {}
        _node_4630_copy ("node_4630_copy", Color) = (1,0,0,1)
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
            #pragma multi_compile_fog
            #pragma target 3.0
            uniform sampler2D _node_8657; uniform float4 _node_8657_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _speed)
                UNITY_DEFINE_INSTANCED_PROP( float, _heigth_noise)
                UNITY_DEFINE_INSTANCED_PROP( float4, _node_4630_copy)
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
                UNITY_FOG_COORDS(2)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_3169 = _Time;
                float _speed_var = UNITY_ACCESS_INSTANCED_PROP( Props, _speed );
                float2 node_2308 = (o.uv0+(node_3169.r*_speed_var)*float2(0,1));
                float4 node_3288 = tex2Dlod(_node_8657,float4(TRANSFORM_TEX(node_2308, _node_8657),0.0,0));
                float _heigth_noise_var = UNITY_ACCESS_INSTANCED_PROP( Props, _heigth_noise );
                v.vertex.xyz += (node_3288.rgb*v.normal*_heigth_noise_var);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
////// Lighting:
////// Emissive:
                float4 _node_4630_copy_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_4630_copy );
                float3 emissive = _node_4630_copy_var.rgb;
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
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
            #pragma multi_compile_fog
            #pragma target 3.0
            uniform sampler2D _node_8657; uniform float4 _node_8657_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _speed)
                UNITY_DEFINE_INSTANCED_PROP( float, _heigth_noise)
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
                float4 node_3169 = _Time;
                float _speed_var = UNITY_ACCESS_INSTANCED_PROP( Props, _speed );
                float2 node_2308 = (o.uv0+(node_3169.r*_speed_var)*float2(0,1));
                float4 node_3288 = tex2Dlod(_node_8657,float4(TRANSFORM_TEX(node_2308, _node_8657),0.0,0));
                float _heigth_noise_var = UNITY_ACCESS_INSTANCED_PROP( Props, _heigth_noise );
                v.vertex.xyz += (node_3288.rgb*v.normal*_heigth_noise_var);
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
