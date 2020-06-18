// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32556,y:32648,varname:node_3138,prsc:2|emission-3662-OUT,alpha-2031-B;n:type:ShaderForge.SFN_Color,id:7241,x:31576,y:32480,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Tex2d,id:2031,x:31514,y:33085,ptovrint:False,ptlb:Alpha,ptin:_Alpha,varname:node_2031,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:0d9c7afd57518d24a81e0b9bc28d4c85,ntxv:0,isnm:False|UVIN-1679-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:9169,x:31671,y:32685,ptovrint:False,ptlb:node_9169,ptin:_node_9169,varname:node_9169,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:29f6c6973db33ef4a87eccafeddf07e7,ntxv:0,isnm:False|UVIN-3832-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:3832,x:31210,y:32734,varname:node_3832,prsc:2,uv:1,uaff:False;n:type:ShaderForge.SFN_TexCoord,id:1679,x:31046,y:33130,varname:node_1679,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Lerp,id:3662,x:32071,y:32521,varname:node_3662,prsc:2|A-7241-RGB,B-9169-RGB,T-7241-A;n:type:ShaderForge.SFN_Blend,id:3867,x:31855,y:32868,varname:node_3867,prsc:2,blmd:10,clmp:True|SRC-2031-B,DST-2031-B;proporder:7241-2031-9169;pass:END;sub:END;*/

Shader "Shader Forge/Toon_Path" {
    Properties {
        _Color ("Color", Color) = (1,1,1,1)
        _Alpha ("Alpha", 2D) = "white" {}
        _node_9169 ("node_9169", 2D) = "white" {}
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
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma target 3.0
            uniform sampler2D _Alpha; uniform float4 _Alpha_ST;
            uniform sampler2D _node_9169; uniform float4 _node_9169_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _Color)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
////// Lighting:
////// Emissive:
                float4 _Color_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Color );
                float4 _node_9169_var = tex2D(_node_9169,TRANSFORM_TEX(i.uv1, _node_9169));
                float3 emissive = lerp(_Color_var.rgb,_node_9169_var.rgb,_Color_var.a);
                float3 finalColor = emissive;
                float4 _Alpha_var = tex2D(_Alpha,TRANSFORM_TEX(i.uv0, _Alpha));
                return fixed4(finalColor,_Alpha_var.b);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
