// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:33635,y:32811,varname:node_9361,prsc:2|emission-5085-OUT,olwid-4581-OUT,olcol-7832-RGB;n:type:ShaderForge.SFN_LightAttenuation,id:8068,x:32555,y:33190,varname:node_8068,prsc:2;n:type:ShaderForge.SFN_LightColor,id:3406,x:32555,y:32859,varname:node_3406,prsc:2;n:type:ShaderForge.SFN_LightVector,id:6869,x:30854,y:32584,varname:node_6869,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:9684,x:30854,y:32712,prsc:2,pt:True;n:type:ShaderForge.SFN_Dot,id:7782,x:31056,y:32645,cmnt:Lambert,varname:node_7782,prsc:2,dt:0|A-6869-OUT,B-9684-OUT;n:type:ShaderForge.SFN_Tex2d,id:851,x:32556,y:32692,ptovrint:False,ptlb:Lighting Palette,ptin:_LightingPalette,varname:node_851,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:ea46c2aecae226b4f91fb02bb2a75859,ntxv:0,isnm:False|UVIN-9916-OUT;n:type:ShaderForge.SFN_Color,id:5927,x:32467,y:32458,ptovrint:False,ptlb:Tint,ptin:_Tint,varname:node_5927,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:5085,x:33145,y:32873,cmnt:Attenuate and Color,varname:node_5085,prsc:2|A-8820-OUT,B-1478-OUT,C-5861-OUT,D-8305-OUT;n:type:ShaderForge.SFN_Slider,id:4581,x:33112,y:33134,ptovrint:False,ptlb:Outline Width,ptin:_OutlineWidth,varname:node_4581,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.02854701,max:1;n:type:ShaderForge.SFN_Append,id:9916,x:31784,y:32744,varname:node_9916,prsc:2|A-7468-OUT,B-1975-OUT;n:type:ShaderForge.SFN_Vector1,id:1975,x:31429,y:32835,varname:node_1975,prsc:2,v1:0;n:type:ShaderForge.SFN_OneMinus,id:7468,x:31429,y:32645,varname:node_7468,prsc:2|IN-427-OUT;n:type:ShaderForge.SFN_RemapRange,id:427,x:31245,y:32645,varname:node_427,prsc:2,frmn:-1,frmx:1,tomn:0.01,tomx:0.99|IN-7782-OUT;n:type:ShaderForge.SFN_Slider,id:3455,x:32148,y:32611,ptovrint:False,ptlb:Lighting Palette Intensity,ptin:_LightingPaletteIntensity,varname:node_3455,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:8820,x:32776,y:32423,varname:node_8820,prsc:2|A-2865-OUT,B-5927-RGB;n:type:ShaderForge.SFN_Add,id:1478,x:32776,y:32599,varname:node_1478,prsc:2|A-851-RGB,B-3455-OUT;n:type:ShaderForge.SFN_Slider,id:6007,x:32398,y:33370,ptovrint:False,ptlb:Light Attenuation Intensity,ptin:_LightAttenuationIntensity,varname:node_6007,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Slider,id:654,x:32398,y:33014,ptovrint:False,ptlb:Light Color Intensity,ptin:_LightColorIntensity,varname:_LightAttenuationIntensity_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Lerp,id:5861,x:32782,y:32891,varname:node_5861,prsc:2|A-6989-OUT,B-3406-RGB,T-654-OUT;n:type:ShaderForge.SFN_Vector1,id:6989,x:32555,y:33097,varname:node_6989,prsc:2,v1:1;n:type:ShaderForge.SFN_Lerp,id:8305,x:32782,y:33117,varname:node_8305,prsc:2|A-6989-OUT,B-8068-OUT,T-6007-OUT;n:type:ShaderForge.SFN_Color,id:7832,x:33269,y:33245,ptovrint:False,ptlb:Outline Color,ptin:_OutlineColor,varname:node_7832,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_TexCoord,id:6369,x:30694,y:31701,varname:node_6369,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Add,id:9151,x:31360,y:32011,varname:node_9151,prsc:2|A-9371-OUT,B-2448-OUT;n:type:ShaderForge.SFN_Append,id:9658,x:31592,y:32098,varname:node_9658,prsc:2|A-9151-OUT,B-5242-OUT;n:type:ShaderForge.SFN_Time,id:9,x:30868,y:32079,varname:node_9,prsc:2;n:type:ShaderForge.SFN_Multiply,id:2448,x:31070,y:32023,varname:node_2448,prsc:2|A-4382-X,B-9-T;n:type:ShaderForge.SFN_Multiply,id:6646,x:31070,y:32179,varname:node_6646,prsc:2|A-9-T,B-4382-Y;n:type:ShaderForge.SFN_Add,id:5242,x:31360,y:32169,varname:node_5242,prsc:2|A-4662-OUT,B-6646-OUT;n:type:ShaderForge.SFN_Vector4Property,id:4382,x:30694,y:32079,ptovrint:False,ptlb:Scroll,ptin:_Scroll,varname:node_4382,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0,v2:0,v3:0,v4:0;n:type:ShaderForge.SFN_Vector4Property,id:2550,x:30694,y:31884,ptovrint:False,ptlb:Stretch,ptin:_Stretch,varname:_Scroll_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0,v2:0,v3:0,v4:0;n:type:ShaderForge.SFN_Multiply,id:9371,x:31070,y:31720,varname:node_9371,prsc:2|A-6369-U,B-2550-X;n:type:ShaderForge.SFN_Multiply,id:4662,x:31070,y:31875,varname:node_4662,prsc:2|A-6369-V,B-2550-Y;n:type:ShaderForge.SFN_Lerp,id:2865,x:32467,y:32274,varname:node_2865,prsc:2|A-7424-RGB,B-3183-RGB,T-9152-OUT;n:type:ShaderForge.SFN_Color,id:7424,x:32149,y:31904,ptovrint:False,ptlb:Color A,ptin:_ColorA,varname:node_7424,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Color,id:3183,x:32149,y:32085,ptovrint:False,ptlb:Color B,ptin:_ColorB,varname:_ColorA_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Tex2d,id:3821,x:31799,y:32098,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:node_3821,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-9658-OUT;n:type:ShaderForge.SFN_Smoothstep,id:9152,x:32078,y:32262,varname:node_9152,prsc:2|A-7106-X,B-7106-Y,V-3821-RGB;n:type:ShaderForge.SFN_Vector4Property,id:7106,x:31755,y:32329,ptovrint:False,ptlb:Smoothstep,ptin:_Smoothstep,varname:node_7106,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0,v2:0,v3:0,v4:0;proporder:851-5927-4581-3455-6007-654-7832-4382-2550-7424-3183-3821-7106;pass:END;sub:END;*/

Shader "Shader Forge/Toon_Waterfall" {
    Properties {
        _LightingPalette ("Lighting Palette", 2D) = "white" {}
        _Tint ("Tint", Color) = (1,1,1,1)
        _OutlineWidth ("Outline Width", Range(0, 1)) = 0.02854701
        _LightingPaletteIntensity ("Lighting Palette Intensity", Range(-1, 1)) = 0
        _LightAttenuationIntensity ("Light Attenuation Intensity", Range(0, 1)) = 1
        _LightColorIntensity ("Light Color Intensity", Range(0, 1)) = 0
        _OutlineColor ("Outline Color", Color) = (0,0,0,1)
        _Scroll ("Scroll", Vector) = (0,0,0,0)
        _Stretch ("Stretch", Vector) = (0,0,0,0)
        _ColorA ("Color A", Color) = (0.5,0.5,0.5,1)
        _ColorB ("Color B", Color) = (0.5,0.5,0.5,1)
        _MainTex ("MainTex", 2D) = "white" {}
        _Smoothstep ("Smoothstep", Vector) = (0,0,0,0)
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "Outline"
            Tags {
            }
            Cull Front
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma target 3.0
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _OutlineWidth)
                UNITY_DEFINE_INSTANCED_PROP( float4, _OutlineColor)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                UNITY_FOG_COORDS(0)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                float _OutlineWidth_var = UNITY_ACCESS_INSTANCED_PROP( Props, _OutlineWidth );
                o.pos = UnityObjectToClipPos( float4(v.vertex.xyz + v.normal*_OutlineWidth_var,1) );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                float4 _OutlineColor_var = UNITY_ACCESS_INSTANCED_PROP( Props, _OutlineColor );
                return fixed4(_OutlineColor_var.rgb,0);
            }
            ENDCG
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
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma target 3.0
            uniform sampler2D _LightingPalette; uniform float4 _LightingPalette_ST;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _Tint)
                UNITY_DEFINE_INSTANCED_PROP( float, _LightingPaletteIntensity)
                UNITY_DEFINE_INSTANCED_PROP( float, _LightAttenuationIntensity)
                UNITY_DEFINE_INSTANCED_PROP( float, _LightColorIntensity)
                UNITY_DEFINE_INSTANCED_PROP( float4, _Scroll)
                UNITY_DEFINE_INSTANCED_PROP( float4, _Stretch)
                UNITY_DEFINE_INSTANCED_PROP( float4, _ColorA)
                UNITY_DEFINE_INSTANCED_PROP( float4, _ColorB)
                UNITY_DEFINE_INSTANCED_PROP( float4, _Smoothstep)
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
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
////// Emissive:
                float4 _ColorA_var = UNITY_ACCESS_INSTANCED_PROP( Props, _ColorA );
                float4 _ColorB_var = UNITY_ACCESS_INSTANCED_PROP( Props, _ColorB );
                float4 _Smoothstep_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Smoothstep );
                float4 _Stretch_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Stretch );
                float4 _Scroll_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Scroll );
                float4 node_9 = _Time;
                float2 node_9658 = float2(((i.uv0.r*_Stretch_var.r)+(_Scroll_var.r*node_9.g)),((i.uv0.g*_Stretch_var.g)+(node_9.g*_Scroll_var.g)));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_9658, _MainTex));
                float4 _Tint_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Tint );
                float2 node_9916 = float2((1.0 - (dot(lightDirection,normalDirection)*0.49+0.5)),0.0);
                float4 _LightingPalette_var = tex2D(_LightingPalette,TRANSFORM_TEX(node_9916, _LightingPalette));
                float _LightingPaletteIntensity_var = UNITY_ACCESS_INSTANCED_PROP( Props, _LightingPaletteIntensity );
                float node_6989 = 1.0;
                float _LightColorIntensity_var = UNITY_ACCESS_INSTANCED_PROP( Props, _LightColorIntensity );
                float _LightAttenuationIntensity_var = UNITY_ACCESS_INSTANCED_PROP( Props, _LightAttenuationIntensity );
                float3 emissive = ((lerp(_ColorA_var.rgb,_ColorB_var.rgb,smoothstep( float3(_Smoothstep_var.r,_Smoothstep_var.r,_Smoothstep_var.r), float3(_Smoothstep_var.g,_Smoothstep_var.g,_Smoothstep_var.g), _MainTex_var.rgb ))*_Tint_var.rgb)*(_LightingPalette_var.rgb+_LightingPaletteIntensity_var)*lerp(float3(node_6989,node_6989,node_6989),_LightColor0.rgb,_LightColorIntensity_var)*lerp(node_6989,attenuation,_LightAttenuationIntensity_var));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma target 3.0
            uniform sampler2D _LightingPalette; uniform float4 _LightingPalette_ST;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _Tint)
                UNITY_DEFINE_INSTANCED_PROP( float, _LightingPaletteIntensity)
                UNITY_DEFINE_INSTANCED_PROP( float, _LightAttenuationIntensity)
                UNITY_DEFINE_INSTANCED_PROP( float, _LightColorIntensity)
                UNITY_DEFINE_INSTANCED_PROP( float4, _Scroll)
                UNITY_DEFINE_INSTANCED_PROP( float4, _Stretch)
                UNITY_DEFINE_INSTANCED_PROP( float4, _ColorA)
                UNITY_DEFINE_INSTANCED_PROP( float4, _ColorB)
                UNITY_DEFINE_INSTANCED_PROP( float4, _Smoothstep)
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
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 finalColor = 0;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}