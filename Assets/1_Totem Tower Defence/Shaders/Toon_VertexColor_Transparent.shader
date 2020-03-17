// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:33635,y:32811,varname:node_9361,prsc:2|emission-5233-OUT,alpha-3607-OUT,olwid-4581-OUT,olcol-7832-RGB;n:type:ShaderForge.SFN_LightAttenuation,id:8068,x:32555,y:33190,varname:node_8068,prsc:2;n:type:ShaderForge.SFN_LightColor,id:3406,x:32555,y:32859,varname:node_3406,prsc:2;n:type:ShaderForge.SFN_LightVector,id:6869,x:31373,y:32581,varname:node_6869,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:9684,x:31373,y:32709,prsc:2,pt:True;n:type:ShaderForge.SFN_Dot,id:7782,x:31575,y:32642,cmnt:Lambert,varname:node_7782,prsc:2,dt:0|A-6869-OUT,B-9684-OUT;n:type:ShaderForge.SFN_Tex2d,id:851,x:32556,y:32692,ptovrint:False,ptlb:Palette,ptin:_Palette,varname:node_851,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:ea46c2aecae226b4f91fb02bb2a75859,ntxv:0,isnm:False|UVIN-9916-OUT;n:type:ShaderForge.SFN_Color,id:5927,x:32467,y:32458,ptovrint:False,ptlb:Tint,ptin:_Tint,varname:node_5927,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:5085,x:33145,y:32873,cmnt:Attenuate and Color,varname:node_5085,prsc:2|A-8820-OUT,B-1478-OUT,C-5861-OUT,D-8305-OUT;n:type:ShaderForge.SFN_Slider,id:4581,x:33112,y:33134,ptovrint:False,ptlb:Outline Width,ptin:_OutlineWidth,varname:node_4581,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.02854701,max:1;n:type:ShaderForge.SFN_Append,id:9916,x:32305,y:32741,varname:node_9916,prsc:2|A-7468-OUT,B-1975-OUT;n:type:ShaderForge.SFN_Vector1,id:1975,x:31948,y:32832,varname:node_1975,prsc:2,v1:0;n:type:ShaderForge.SFN_OneMinus,id:7468,x:31948,y:32642,varname:node_7468,prsc:2|IN-427-OUT;n:type:ShaderForge.SFN_RemapRange,id:427,x:31764,y:32642,varname:node_427,prsc:2,frmn:-1,frmx:1,tomn:0.01,tomx:0.99|IN-7782-OUT;n:type:ShaderForge.SFN_Slider,id:3455,x:32148,y:32568,ptovrint:False,ptlb:Palette Intensity,ptin:_PaletteIntensity,varname:node_3455,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:8820,x:32776,y:32423,varname:node_8820,prsc:2|A-3329-RGB,B-5927-RGB;n:type:ShaderForge.SFN_Add,id:1478,x:32776,y:32599,varname:node_1478,prsc:2|A-851-RGB,B-3455-OUT;n:type:ShaderForge.SFN_VertexColor,id:3329,x:32467,y:32285,varname:node_3329,prsc:2;n:type:ShaderForge.SFN_Slider,id:6007,x:32398,y:33370,ptovrint:False,ptlb:Light Attenuation Intensity,ptin:_LightAttenuationIntensity,varname:node_6007,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Slider,id:654,x:32398,y:33014,ptovrint:False,ptlb:Light Color Intensity,ptin:_LightColorIntensity,varname:_LightAttenuationIntensity_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Lerp,id:5861,x:32782,y:32891,varname:node_5861,prsc:2|A-6989-OUT,B-3406-RGB,T-654-OUT;n:type:ShaderForge.SFN_Vector1,id:6989,x:32555,y:33097,varname:node_6989,prsc:2,v1:1;n:type:ShaderForge.SFN_Lerp,id:8305,x:32782,y:33117,varname:node_8305,prsc:2|A-6989-OUT,B-8068-OUT,T-6007-OUT;n:type:ShaderForge.SFN_Color,id:7832,x:33269,y:33245,ptovrint:False,ptlb:Outline Color,ptin:_OutlineColor,varname:node_7832,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Multiply,id:3607,x:33145,y:32656,varname:node_3607,prsc:2|A-3329-A,B-5927-A,C-851-A;n:type:ShaderForge.SFN_Multiply,id:5233,x:33401,y:32739,varname:node_5233,prsc:2|A-3607-OUT,B-5085-OUT;proporder:851-5927-4581-3455-6007-654-7832;pass:END;sub:END;*/

Shader "Shader Forge/Toon_VertexColor_Transparent" {
    Properties {
        _Palette ("Palette", 2D) = "white" {}
        _Tint ("Tint", Color) = (1,1,1,1)
        _OutlineWidth ("Outline Width", Range(0, 1)) = 0.02854701
        _PaletteIntensity ("Palette Intensity", Range(-1, 1)) = 0
        _LightAttenuationIntensity ("Light Attenuation Intensity", Range(0, 1)) = 1
        _LightColorIntensity ("Light Color Intensity", Range(0, 1)) = 0
        _OutlineColor ("Outline Color", Color) = (0,0,0,1)
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
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
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma target 3.0
            uniform sampler2D _Palette; uniform float4 _Palette_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _Tint)
                UNITY_DEFINE_INSTANCED_PROP( float, _PaletteIntensity)
                UNITY_DEFINE_INSTANCED_PROP( float, _LightAttenuationIntensity)
                UNITY_DEFINE_INSTANCED_PROP( float, _LightColorIntensity)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(2)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = 1;
////// Emissive:
                float4 _Tint_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Tint );
                float2 node_9916 = float2((1.0 - (dot(lightDirection,normalDirection)*0.49+0.5)),0.0);
                float4 _Palette_var = tex2D(_Palette,TRANSFORM_TEX(node_9916, _Palette));
                float node_3607 = (i.vertexColor.a*_Tint_var.a*_Palette_var.a);
                float _PaletteIntensity_var = UNITY_ACCESS_INSTANCED_PROP( Props, _PaletteIntensity );
                float node_6989 = 1.0;
                float _LightColorIntensity_var = UNITY_ACCESS_INSTANCED_PROP( Props, _LightColorIntensity );
                float _LightAttenuationIntensity_var = UNITY_ACCESS_INSTANCED_PROP( Props, _LightAttenuationIntensity );
                float3 emissive = (node_3607*((i.vertexColor.rgb*_Tint_var.rgb)*(_Palette_var.rgb+_PaletteIntensity_var)*lerp(float3(node_6989,node_6989,node_6989),_LightColor0.rgb,_LightColorIntensity_var)*lerp(node_6989,attenuation,_LightAttenuationIntensity_var)));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,node_3607);
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
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdadd
            #pragma multi_compile_fog
            #pragma target 3.0
            uniform sampler2D _Palette; uniform float4 _Palette_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _Tint)
                UNITY_DEFINE_INSTANCED_PROP( float, _PaletteIntensity)
                UNITY_DEFINE_INSTANCED_PROP( float, _LightAttenuationIntensity)
                UNITY_DEFINE_INSTANCED_PROP( float, _LightColorIntensity)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                float4 vertexColor : COLOR;
                LIGHTING_COORDS(2,3)
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.vertexColor = v.vertexColor;
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
                float4 _Tint_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Tint );
                float2 node_9916 = float2((1.0 - (dot(lightDirection,normalDirection)*0.49+0.5)),0.0);
                float4 _Palette_var = tex2D(_Palette,TRANSFORM_TEX(node_9916, _Palette));
                float node_3607 = (i.vertexColor.a*_Tint_var.a*_Palette_var.a);
                fixed4 finalRGBA = fixed4(finalColor * node_3607,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
