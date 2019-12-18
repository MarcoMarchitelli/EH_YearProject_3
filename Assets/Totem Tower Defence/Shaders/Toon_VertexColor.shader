// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:33528,y:32813,varname:node_9361,prsc:2|emission-5085-OUT,olwid-4581-OUT,olcol-8762-RGB;n:type:ShaderForge.SFN_LightAttenuation,id:8068,x:32555,y:33130,varname:node_8068,prsc:2;n:type:ShaderForge.SFN_LightColor,id:3406,x:32555,y:32859,varname:node_3406,prsc:2;n:type:ShaderForge.SFN_LightVector,id:6869,x:32130,y:32551,varname:node_6869,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:9684,x:32130,y:32679,prsc:2,pt:True;n:type:ShaderForge.SFN_Dot,id:7782,x:32337,y:32619,cmnt:Lambert,varname:node_7782,prsc:2,dt:1|A-6869-OUT,B-9684-OUT;n:type:ShaderForge.SFN_Tex2d,id:851,x:32352,y:32244,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:node_851,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:5927,x:32352,y:32429,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_5927,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:5085,x:33150,y:32908,cmnt:Attenuate and Color,varname:node_5085,prsc:2|A-544-OUT,B-8521-OUT,C-3905-OUT,D-5546-OUT,E-8078-OUT;n:type:ShaderForge.SFN_AmbientLight,id:7528,x:32555,y:33348,varname:node_7528,prsc:2;n:type:ShaderForge.SFN_Multiply,id:544,x:32550,y:32343,cmnt:Diffuse Color,varname:node_544,prsc:2|A-851-RGB,B-5927-RGB;n:type:ShaderForge.SFN_Slider,id:5872,x:32130,y:32873,ptovrint:False,ptlb:Diffuse Step,ptin:_DiffuseStep,varname:node_5872,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5201484,max:1;n:type:ShaderForge.SFN_Step,id:8521,x:32555,y:32688,varname:node_8521,prsc:2|A-5872-OUT,B-7782-OUT;n:type:ShaderForge.SFN_Slider,id:4581,x:33112,y:33134,ptovrint:False,ptlb:Outline Width,ptin:_OutlineWidth,varname:node_4581,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.02,max:1;n:type:ShaderForge.SFN_Color,id:8762,x:33269,y:33233,ptovrint:False,ptlb:Outline Color,ptin:_OutlineColor,varname:node_8762,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_ToggleProperty,id:4945,x:32555,y:33034,ptovrint:False,ptlb:Light Color,ptin:_LightColor,varname:node_4945,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False;n:type:ShaderForge.SFN_ToggleProperty,id:1914,x:32555,y:33503,ptovrint:False,ptlb:Ambient Light,ptin:_AmbientLight,varname:node_1914,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False;n:type:ShaderForge.SFN_ToggleProperty,id:821,x:32555,y:33286,ptovrint:False,ptlb:Light Attenuatioin,ptin:_LightAttenuatioin,varname:node_821,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False;n:type:ShaderForge.SFN_If,id:8078,x:32814,y:33374,varname:node_8078,prsc:2|A-1914-OUT,B-5021-OUT,GT-7528-RGB,EQ-7528-RGB,LT-5021-OUT;n:type:ShaderForge.SFN_Vector1,id:5021,x:32555,y:33591,varname:node_5021,prsc:2,v1:1;n:type:ShaderForge.SFN_If,id:5546,x:32817,y:33202,varname:node_5546,prsc:2|A-821-OUT,B-5021-OUT,GT-8068-OUT,EQ-8068-OUT,LT-5021-OUT;n:type:ShaderForge.SFN_If,id:3905,x:32817,y:33021,varname:node_3905,prsc:2|A-4945-OUT,B-5021-OUT,GT-3406-RGB,EQ-3406-RGB,LT-5021-OUT;proporder:851-5927-5872-4581-8762-1914-821-4945;pass:END;sub:END;*/

Shader "Shader Forge/Toon" {
    Properties {
        _Diffuse ("Diffuse", 2D) = "white" {}
        _Color ("Color", Color) = (0.5,0.5,0.5,1)
        _DiffuseStep ("Diffuse Step", Range(0, 1)) = 0.5201484
        _OutlineWidth ("Outline Width", Range(0, 1)) = 0.02
        _OutlineColor ("Outline Color", Color) = (0.5,0.5,0.5,1)
        [MaterialToggle] _AmbientLight ("Ambient Light", Float ) = 0
        [MaterialToggle] _LightAttenuatioin ("Light Attenuatioin", Float ) = 0
        [MaterialToggle] _LightColor ("Light Color", Float ) = 0
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
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _Color)
                UNITY_DEFINE_INSTANCED_PROP( float, _DiffuseStep)
                UNITY_DEFINE_INSTANCED_PROP( fixed, _LightColor)
                UNITY_DEFINE_INSTANCED_PROP( fixed, _AmbientLight)
                UNITY_DEFINE_INSTANCED_PROP( fixed, _LightAttenuatioin)
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
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float4 _Color_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Color );
                float _DiffuseStep_var = UNITY_ACCESS_INSTANCED_PROP( Props, _DiffuseStep );
                float _LightColor_var = UNITY_ACCESS_INSTANCED_PROP( Props, _LightColor );
                float node_5021 = 1.0;
                float node_3905_if_leA = step(_LightColor_var,node_5021);
                float node_3905_if_leB = step(node_5021,_LightColor_var);
                float _LightAttenuatioin_var = UNITY_ACCESS_INSTANCED_PROP( Props, _LightAttenuatioin );
                float node_5546_if_leA = step(_LightAttenuatioin_var,node_5021);
                float node_5546_if_leB = step(node_5021,_LightAttenuatioin_var);
                float _AmbientLight_var = UNITY_ACCESS_INSTANCED_PROP( Props, _AmbientLight );
                float node_8078_if_leA = step(_AmbientLight_var,node_5021);
                float node_8078_if_leB = step(node_5021,_AmbientLight_var);
                float3 emissive = ((_Diffuse_var.rgb*_Color_var.rgb)*step(_DiffuseStep_var,max(0,dot(lightDirection,normalDirection)))*lerp((node_3905_if_leA*node_5021)+(node_3905_if_leB*_LightColor0.rgb),_LightColor0.rgb,node_3905_if_leA*node_3905_if_leB)*lerp((node_5546_if_leA*node_5021)+(node_5546_if_leB*attenuation),attenuation,node_5546_if_leA*node_5546_if_leB)*lerp((node_8078_if_leA*node_5021)+(node_8078_if_leB*UNITY_LIGHTMODEL_AMBIENT.rgb),UNITY_LIGHTMODEL_AMBIENT.rgb,node_8078_if_leA*node_8078_if_leB));
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
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _Color)
                UNITY_DEFINE_INSTANCED_PROP( float, _DiffuseStep)
                UNITY_DEFINE_INSTANCED_PROP( fixed, _LightColor)
                UNITY_DEFINE_INSTANCED_PROP( fixed, _AmbientLight)
                UNITY_DEFINE_INSTANCED_PROP( fixed, _LightAttenuatioin)
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
