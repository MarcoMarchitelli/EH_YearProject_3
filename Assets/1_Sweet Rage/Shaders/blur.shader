// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33815,y:32723,varname:node_3138,prsc:2|custl-8051-OUT;n:type:ShaderForge.SFN_ScreenPos,id:4509,x:32528,y:32467,varname:node_4509,prsc:2,sctp:2;n:type:ShaderForge.SFN_SceneColor,id:1842,x:32616,y:33066,varname:node_1842,prsc:2|UVIN-3656-OUT;n:type:ShaderForge.SFN_Set,id:7881,x:32705,y:32467,varname:__screen_pos,prsc:2|IN-4509-UVOUT;n:type:ShaderForge.SFN_Get,id:7204,x:32100,y:34180,varname:node_7204,prsc:2|IN-7881-OUT;n:type:ShaderForge.SFN_Slider,id:5517,x:31896,y:32521,ptovrint:False,ptlb:offset,ptin:_offset,varname:node_5517,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:0.05;n:type:ShaderForge.SFN_Set,id:7891,x:32242,y:32513,varname:__offset,prsc:2|IN-5517-OUT;n:type:ShaderForge.SFN_Get,id:3183,x:32119,y:34265,varname:node_3183,prsc:2|IN-7891-OUT;n:type:ShaderForge.SFN_Add,id:5567,x:32319,y:34265,varname:node_5567,prsc:2|A-7204-OUT,B-3183-OUT;n:type:ShaderForge.SFN_Set,id:4842,x:32705,y:32536,varname:u,prsc:2|IN-4509-U;n:type:ShaderForge.SFN_Set,id:8864,x:32705,y:32590,varname:v,prsc:2|IN-4509-V;n:type:ShaderForge.SFN_Get,id:3507,x:32028,y:33042,varname:node_3507,prsc:2|IN-4842-OUT;n:type:ShaderForge.SFN_Get,id:1140,x:32039,y:33096,varname:node_1140,prsc:2|IN-7891-OUT;n:type:ShaderForge.SFN_Add,id:2254,x:32226,y:33042,varname:node_2254,prsc:2|A-3507-OUT,B-1140-OUT;n:type:ShaderForge.SFN_Append,id:3656,x:32386,y:33042,varname:node_3656,prsc:2|A-3488-OUT,B-2254-OUT;n:type:ShaderForge.SFN_Get,id:3488,x:32067,y:33203,varname:node_3488,prsc:2|IN-8864-OUT;n:type:ShaderForge.SFN_Get,id:3062,x:32020,y:33327,varname:node_3062,prsc:2|IN-8864-OUT;n:type:ShaderForge.SFN_Get,id:7288,x:32031,y:33381,varname:node_7288,prsc:2|IN-7891-OUT;n:type:ShaderForge.SFN_Add,id:2567,x:32218,y:33327,varname:node_2567,prsc:2|A-3062-OUT,B-7288-OUT;n:type:ShaderForge.SFN_Append,id:2822,x:32381,y:33327,varname:node_2822,prsc:2|A-8859-OUT,B-2567-OUT;n:type:ShaderForge.SFN_Get,id:8859,x:32059,y:33488,varname:node_8859,prsc:2|IN-4842-OUT;n:type:ShaderForge.SFN_SceneColor,id:3163,x:32632,y:33346,varname:node_3163,prsc:2|UVIN-2822-OUT;n:type:ShaderForge.SFN_Add,id:3492,x:32872,y:33004,varname:node_3492,prsc:2|A-6547-RGB,B-1842-RGB,C-3163-RGB,D-7773-RGB,E-6414-RGB;n:type:ShaderForge.SFN_Divide,id:8051,x:33450,y:33049,varname:node_8051,prsc:2|A-7918-OUT,B-7192-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7192,x:33194,y:33092,ptovrint:False,ptlb:node_7192,ptin:_node_7192,varname:node_7192,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:5;n:type:ShaderForge.SFN_Get,id:3894,x:32432,y:32820,varname:node_3894,prsc:2|IN-7881-OUT;n:type:ShaderForge.SFN_SceneColor,id:6547,x:32663,y:32765,varname:node_6547,prsc:2|UVIN-3894-OUT;n:type:ShaderForge.SFN_SceneColor,id:7773,x:32629,y:33639,varname:node_7773,prsc:2|UVIN-4710-OUT;n:type:ShaderForge.SFN_Get,id:3686,x:32041,y:33615,varname:node_3686,prsc:2|IN-4842-OUT;n:type:ShaderForge.SFN_Get,id:2527,x:32052,y:33669,varname:node_2527,prsc:2|IN-7891-OUT;n:type:ShaderForge.SFN_Append,id:4710,x:32399,y:33615,varname:node_4710,prsc:2|A-5991-OUT,B-606-OUT;n:type:ShaderForge.SFN_Get,id:606,x:32080,y:33776,varname:node_606,prsc:2|IN-8864-OUT;n:type:ShaderForge.SFN_Get,id:1354,x:32033,y:33900,varname:node_1354,prsc:2|IN-8864-OUT;n:type:ShaderForge.SFN_Get,id:7968,x:32044,y:33954,varname:node_7968,prsc:2|IN-7891-OUT;n:type:ShaderForge.SFN_Append,id:2679,x:32396,y:33919,varname:node_2679,prsc:2|A-294-OUT,B-2333-OUT;n:type:ShaderForge.SFN_Get,id:2333,x:32072,y:34061,varname:node_2333,prsc:2|IN-4842-OUT;n:type:ShaderForge.SFN_SceneColor,id:6414,x:32645,y:33919,varname:node_6414,prsc:2|UVIN-2679-OUT;n:type:ShaderForge.SFN_Subtract,id:5991,x:32205,y:33633,varname:node_5991,prsc:2|A-3686-OUT,B-2527-OUT;n:type:ShaderForge.SFN_Subtract,id:294,x:32228,y:33900,varname:node_294,prsc:2|A-1354-OUT,B-7968-OUT;n:type:ShaderForge.SFN_SceneColor,id:1692,x:32669,y:34169,varname:node_1692,prsc:2|UVIN-5567-OUT;n:type:ShaderForge.SFN_Add,id:6310,x:32941,y:34180,varname:node_6310,prsc:2|A-1692-RGB,B-1848-RGB,C-1703-RGB,D-8136-RGB;n:type:ShaderForge.SFN_Subtract,id:4328,x:32356,y:34457,varname:node_4328,prsc:2|A-7204-OUT,B-3183-OUT;n:type:ShaderForge.SFN_SceneColor,id:1848,x:32658,y:34361,varname:node_1848,prsc:2|UVIN-4328-OUT;n:type:ShaderForge.SFN_Get,id:1780,x:32074,y:34582,varname:node_1780,prsc:2|IN-4842-OUT;n:type:ShaderForge.SFN_Get,id:6093,x:32074,y:34687,varname:node_6093,prsc:2|IN-7891-OUT;n:type:ShaderForge.SFN_Add,id:1114,x:32330,y:34611,varname:node_1114,prsc:2|A-1780-OUT,B-6093-OUT;n:type:ShaderForge.SFN_Subtract,id:6467,x:32330,y:34791,varname:node_6467,prsc:2|A-8184-OUT,B-6093-OUT;n:type:ShaderForge.SFN_Get,id:8184,x:32074,y:34791,varname:node_8184,prsc:2|IN-8864-OUT;n:type:ShaderForge.SFN_Append,id:8008,x:32566,y:34611,varname:node_8008,prsc:2|A-1114-OUT,B-6467-OUT;n:type:ShaderForge.SFN_SceneColor,id:1703,x:32747,y:34637,varname:node_1703,prsc:2|UVIN-8008-OUT;n:type:ShaderForge.SFN_Get,id:808,x:32089,y:34956,varname:node_808,prsc:2|IN-8864-OUT;n:type:ShaderForge.SFN_Get,id:1046,x:32089,y:35061,varname:node_1046,prsc:2|IN-7891-OUT;n:type:ShaderForge.SFN_Add,id:6760,x:32345,y:34985,varname:node_6760,prsc:2|A-808-OUT,B-1046-OUT;n:type:ShaderForge.SFN_Subtract,id:4224,x:32345,y:35165,varname:node_4224,prsc:2|A-3602-OUT,B-1046-OUT;n:type:ShaderForge.SFN_Get,id:3602,x:32089,y:35165,varname:node_3602,prsc:2|IN-4842-OUT;n:type:ShaderForge.SFN_Append,id:1811,x:32581,y:34985,varname:node_1811,prsc:2|A-6760-OUT,B-4224-OUT;n:type:ShaderForge.SFN_SceneColor,id:8136,x:32746,y:34985,varname:node_8136,prsc:2|UVIN-1811-OUT;n:type:ShaderForge.SFN_Add,id:7918,x:33190,y:33390,varname:node_7918,prsc:2|A-3492-OUT,B-6310-OUT;proporder:5517-7192;pass:END;sub:END;*/

Shader "Shader Forge/blur" {
    Properties {
        _offset ("offset", Range(0, 0.05)) = 0
        _node_7192 ("node_7192", Float ) = 5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        GrabPass{ }
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
            uniform sampler2D _GrabTexture;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _offset)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_7192)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 projPos : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.pos = UnityObjectToClipPos( v.vertex );
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                float2 sceneUVs = (i.projPos.xy / i.projPos.w);
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
////// Lighting:
                float2 __screen_pos = sceneUVs.rg;
                float v = sceneUVs.g;
                float u = sceneUVs.r;
                float _offset_var = UNITY_ACCESS_INSTANCED_PROP( Props, _offset );
                float __offset = _offset_var;
                float node_3686 = u;
                float node_2527 = __offset;
                float node_1354 = v;
                float node_7968 = __offset;
                float2 node_7204 = __screen_pos;
                float node_3183 = __offset;
                float node_6093 = __offset;
                float node_1046 = __offset;
                float _node_7192_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_7192 );
                float3 finalColor = (((tex2D( _GrabTexture, __screen_pos).rgb+tex2D( _GrabTexture, float2(v,(u+__offset))).rgb+tex2D( _GrabTexture, float2(u,(v+__offset))).rgb+tex2D( _GrabTexture, float2((node_3686-node_2527),v)).rgb+tex2D( _GrabTexture, float2((node_1354-node_7968),u)).rgb)+(tex2D( _GrabTexture, (node_7204+node_3183)).rgb+tex2D( _GrabTexture, (node_7204-node_3183)).rgb+tex2D( _GrabTexture, float2((u+node_6093),(v-node_6093))).rgb+tex2D( _GrabTexture, float2((v+node_1046),(u-node_1046))).rgb))/_node_7192_var);
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
