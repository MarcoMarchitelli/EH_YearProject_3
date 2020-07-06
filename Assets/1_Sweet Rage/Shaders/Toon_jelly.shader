// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0,5,fgcg:0,5,fgcb:0,5,fgca:1,fgde:0,01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33190,y:32692,varname:node_3138,prsc:2|emission-7241-RGB,alpha-1739-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:32079,y:32926,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,07843138,c2:0,3921569,c3:0,7843137,c4:1;n:type:ShaderForge.SFN_Fresnel,id:8717,x:31722,y:32619,varname:node_8717,prsc:2|EXP-3637-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3637,x:31531,y:32691,ptovrint:False,ptlb:fresnel,ptin:_fresnel,varname:node_6356,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_OneMinus,id:9348,x:32304,y:32678,varname:node_9348,prsc:2|IN-3752-OUT;n:type:ShaderForge.SFN_Blend,id:4290,x:31936,y:32495,varname:node_4290,prsc:2,blmd:20,clmp:True|SRC-9639-OUT,DST-8717-OUT;n:type:ShaderForge.SFN_Slider,id:9639,x:31583,y:32465,ptovrint:False,ptlb:node_4152,ptin:_node_4152,varname:node_4152,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,4539576,max:1;n:type:ShaderForge.SFN_Blend,id:3408,x:31936,y:32345,varname:node_3408,prsc:2,blmd:13,clmp:True|SRC-9639-OUT,DST-8717-OUT;n:type:ShaderForge.SFN_Blend,id:3752,x:32155,y:32412,varname:node_3752,prsc:2,blmd:8,clmp:True|SRC-3408-OUT,DST-4290-OUT;n:type:ShaderForge.SFN_ObjectPosition,id:6391,x:31565,y:32305,varname:node_6391,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:152,x:32455,y:33086,ptovrint:False,ptlb:node_152,ptin:_node_152,varname:node_152,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0,5;n:type:ShaderForge.SFN_Add,id:1541,x:32732,y:32906,varname:node_1541,prsc:2|A-9348-OUT,B-152-OUT;n:type:ShaderForge.SFN_Blend,id:1739,x:32725,y:33055,varname:node_1739,prsc:2,blmd:5,clmp:True|SRC-9348-OUT,DST-152-OUT;n:type:ShaderForge.SFN_Subtract,id:3017,x:32944,y:33096,varname:node_3017,prsc:2|A-1739-OUT,B-5791-OUT;n:type:ShaderForge.SFN_Slider,id:5791,x:32478,y:33265,ptovrint:False,ptlb:node_5791,ptin:_node_5791,varname:node_5791,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,09191477,max:1;proporder:7241-3637-9639-152-5791;pass:END;sub:END;*/

Shader "Shader Forge/Toon_jelly" {
    Properties {
        _Color ("Color", Color) = (0,07843138,0,3921569,0,7843137,1)
        _fresnel ("fresnel", Float ) = 1
        _node_4152 ("node_4152", Range(0, 1)) = 0,4539576
        _node_152 ("node_152", Float ) = 0,5
        _node_5791 ("node_5791", Range(0, 1)) = 0,09191477
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
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _Color)
                UNITY_DEFINE_INSTANCED_PROP( float, _fresnel)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_4152)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_152)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
////// Lighting:
////// Emissive:
                float4 _Color_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Color );
                float3 emissive = _Color_var.rgb;
                float3 finalColor = emissive;
                float _node_4152_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_4152 );
                float _fresnel_var = UNITY_ACCESS_INSTANCED_PROP( Props, _fresnel );
                float node_8717 = pow(1.0-max(0,dot(normalDirection, viewDirection)),_fresnel_var);
                float node_9348 = (1.0 - saturate((saturate(( _node_4152_var > 0.5 ? (node_8717/((1.0-_node_4152_var)*2.0)) : (1.0-(((1.0-node_8717)*0.5)/_node_4152_var))))+saturate((node_8717/_node_4152_var)))));
                float _node_152_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_152 );
                float node_1739 = saturate(max(node_9348,_node_152_var));
                return fixed4(finalColor,node_1739);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
