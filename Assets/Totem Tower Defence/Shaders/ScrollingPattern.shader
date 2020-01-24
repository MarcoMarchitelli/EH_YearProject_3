// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:1,cusa:True,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:True,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:True,atwp:True,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:1873,x:33229,y:32719,varname:node_1873,prsc:2|emission-1749-OUT,alpha-603-OUT;n:type:ShaderForge.SFN_Tex2d,id:4805,x:32593,y:32727,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-8674-OUT;n:type:ShaderForge.SFN_Multiply,id:1086,x:32812,y:32818,cmnt:RGB,varname:node_1086,prsc:2|A-4805-RGB,B-5983-RGB,C-5376-RGB;n:type:ShaderForge.SFN_Color,id:5983,x:32593,y:32910,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_VertexColor,id:5376,x:32593,y:33069,varname:node_5376,prsc:2;n:type:ShaderForge.SFN_Multiply,id:1749,x:33025,y:32818,cmnt:Premultiply Alpha,varname:node_1749,prsc:2|A-1086-OUT,B-603-OUT;n:type:ShaderForge.SFN_Multiply,id:603,x:32812,y:32992,cmnt:A,varname:node_603,prsc:2|A-4805-A,B-5983-A,C-5376-A;n:type:ShaderForge.SFN_TexCoord,id:618,x:31444,y:32531,varname:node_618,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Frac,id:8674,x:32362,y:32673,varname:node_8674,prsc:2|IN-3169-OUT;n:type:ShaderForge.SFN_Multiply,id:3169,x:32140,y:32673,varname:node_3169,prsc:2|A-6485-OUT,B-8009-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8009,x:31707,y:32836,ptovrint:False,ptlb:Tiles,ptin:_Tiles,varname:node_8009,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Rotator,id:7335,x:31707,y:32671,varname:node_7335,prsc:2|UVIN-618-UVOUT,PIV-7563-OUT,ANG-5628-OUT;n:type:ShaderForge.SFN_Vector2,id:7563,x:31444,y:32692,varname:node_7563,prsc:2,v1:0,v2:0;n:type:ShaderForge.SFN_Slider,id:8153,x:31046,y:32797,ptovrint:False,ptlb:Rotation Angle,ptin:_RotationAngle,varname:node_8153,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:360;n:type:ShaderForge.SFN_Add,id:6485,x:31918,y:32671,varname:node_6485,prsc:2|A-7335-UVOUT,B-7959-OUT;n:type:ShaderForge.SFN_Time,id:1415,x:31895,y:32907,varname:node_1415,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:64,x:31895,y:33064,ptovrint:False,ptlb:Scroll Speed,ptin:_ScrollSpeed,varname:node_64,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:7959,x:32081,y:32969,varname:node_7959,prsc:2|A-1415-TSL,B-64-OUT;n:type:ShaderForge.SFN_Pi,id:7689,x:31046,y:32895,varname:node_7689,prsc:2;n:type:ShaderForge.SFN_Divide,id:1455,x:31203,y:32895,varname:node_1455,prsc:2|A-7689-OUT,B-6884-OUT;n:type:ShaderForge.SFN_Vector1,id:6884,x:31013,y:33004,varname:node_6884,prsc:2,v1:180;n:type:ShaderForge.SFN_Multiply,id:5628,x:31444,y:32798,varname:node_5628,prsc:2|A-8153-OUT,B-1455-OUT;proporder:4805-5983-8009-8153-64;pass:END;sub:END;*/

Shader "Shader Forge/ScrollingPattern" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
        _Tiles ("Tiles", Float ) = 2
        _RotationAngle ("Rotation Angle", Range(0, 360)) = 0
        _ScrollSpeed ("Scroll Speed", Float ) = 1
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
        _Stencil ("Stencil ID", Float) = 0
        _StencilReadMask ("Stencil Read Mask", Float) = 255
        _StencilWriteMask ("Stencil Write Mask", Float) = 255
        _StencilComp ("Stencil Comparison", Float) = 8
        _StencilOp ("Stencil Operation", Float) = 0
        _StencilOpFail ("Stencil Fail Operation", Float) = 0
        _StencilOpZFail ("Stencil Z-Fail Operation", Float) = 0
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
            "CanUseSpriteAtlas"="True"
            "PreviewType"="Plane"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            ZWrite Off
            
            Stencil {
                Ref [_Stencil]
                ReadMask [_StencilReadMask]
                WriteMask [_StencilWriteMask]
                Comp [_StencilComp]
                Pass [_StencilOp]
                Fail [_StencilOpFail]
                ZFail [_StencilOpZFail]
            }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #pragma multi_compile _ PIXELSNAP_ON
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _Color)
                UNITY_DEFINE_INSTANCED_PROP( float, _Tiles)
                UNITY_DEFINE_INSTANCED_PROP( float, _RotationAngle)
                UNITY_DEFINE_INSTANCED_PROP( float, _ScrollSpeed)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float2 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos( v.vertex );
                #ifdef PIXELSNAP_ON
                    o.pos = UnityPixelSnap(o.pos);
                #endif
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
////// Lighting:
////// Emissive:
                float _RotationAngle_var = UNITY_ACCESS_INSTANCED_PROP( Props, _RotationAngle );
                float node_7335_ang = (_RotationAngle_var*(3.141592654/180.0));
                float node_7335_spd = 1.0;
                float node_7335_cos = cos(node_7335_spd*node_7335_ang);
                float node_7335_sin = sin(node_7335_spd*node_7335_ang);
                float2 node_7335_piv = float2(0,0);
                float2 node_7335 = (mul(i.uv0-node_7335_piv,float2x2( node_7335_cos, -node_7335_sin, node_7335_sin, node_7335_cos))+node_7335_piv);
                float4 node_1415 = _Time;
                float _ScrollSpeed_var = UNITY_ACCESS_INSTANCED_PROP( Props, _ScrollSpeed );
                float _Tiles_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Tiles );
                float2 node_8674 = frac(((node_7335+(node_1415.r*_ScrollSpeed_var))*_Tiles_var));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_8674, _MainTex));
                float4 _Color_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Color );
                float node_603 = (_MainTex_var.a*_Color_var.a*i.vertexColor.a); // A
                float3 emissive = ((_MainTex_var.rgb*_Color_var.rgb*i.vertexColor.rgb)*node_603);
                float3 finalColor = emissive;
                return fixed4(finalColor,node_603);
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
            #pragma multi_compile _ PIXELSNAP_ON
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
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityObjectToClipPos( v.vertex );
                #ifdef PIXELSNAP_ON
                    o.pos = UnityPixelSnap(o.pos);
                #endif
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
