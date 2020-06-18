// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32766,y:32684,varname:node_3138,prsc:2|emission-4340-RGB,alpha-4340-A;n:type:ShaderForge.SFN_Color,id:7241,x:31812,y:32451,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.07843138,c2:0.3921569,c3:0.7843137,c4:1;n:type:ShaderForge.SFN_Tex2d,id:4340,x:31985,y:32854,ptovrint:False,ptlb:node_4340,ptin:_node_4340,varname:node_4340,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:effc41dfc28636944bbbda2591d49b56,ntxv:0,isnm:False|UVIN-9108-UVOUT;n:type:ShaderForge.SFN_Time,id:8046,x:31251,y:32747,varname:node_8046,prsc:2;n:type:ShaderForge.SFN_Panner,id:9108,x:31751,y:32682,varname:node_9108,prsc:2,spu:0,spv:0.05|UVIN-4969-UVOUT,DIST-2286-OUT;n:type:ShaderForge.SFN_TexCoord,id:4969,x:31496,y:32497,varname:node_4969,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Sin,id:2286,x:31427,y:32766,varname:node_2286,prsc:2|IN-8046-T;n:type:ShaderForge.SFN_Multiply,id:7362,x:31844,y:32901,varname:node_7362,prsc:2;n:type:ShaderForge.SFN_ConstantClamp,id:3252,x:31624,y:32891,varname:node_3252,prsc:2,min:0,max:0.2|IN-2286-OUT;proporder:7241-4340;pass:END;sub:END;*/

Shader "Shader Forge/cartman" {
    Properties {
        _Color ("Color", Color) = (0.07843138,0.3921569,0.7843137,1)
        _node_4340 ("node_4340", 2D) = "white" {}
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
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma target 3.0
            uniform sampler2D _node_4340; uniform float4 _node_4340_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 node_8046 = _Time;
                float node_2286 = sin(node_8046.g);
                float2 node_9108 = (i.uv0+node_2286*float2(0,0.05));
                float4 _node_4340_var = tex2D(_node_4340,TRANSFORM_TEX(node_9108, _node_4340));
                float3 emissive = _node_4340_var.rgb;
                float3 finalColor = emissive;
                return fixed4(finalColor,_node_4340_var.a);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
