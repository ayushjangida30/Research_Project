// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/NewUnlitShader"
{

    Properties
	{
		[PerRendererData] _Color("Color", Color) = (1,1,1,1)
		[PerRendererData] _Alpha("Alpha", float) = 0.5
		[PerRendererData] _OutlineColor("OutlineColor", Color) = (0, 0, 0, 1)
        [PerRendererData] _OutlineWidth("OutlineWidth", float) = 0.1
	}


    SubShader
    {
		Tags{"Queue" = "Transparent+200" "RenderType" = "Transprent" }
        LOD 100
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            Stencil {
				Ref 128
				Comp always
			}
			ZTest On
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct v2f
            {
                float4 vertex : SV_POSITION;

                fixed4 diff : COLOR0;
            };

            fixed4 _Color;
			fixed _Alpha;


            v2f vert (appdata_base v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                UNITY_TRANSFER_FOG(o,o.vertex);

                half3 worldNormal = UnityObjectToWorldNormal(v.normal);
                half3 p = normalize(_WorldSpaceCameraPos - mul(unity_ObjectToWorld, v.vertex));
                half nl = max(0, dot(worldNormal, p));
                o.diff = nl * fixed4(1,1,1,1);

                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = _Color * i.diff;
				col.a = _Alpha;
                //col.a = 1;
				/// Max alpha comes from colour value
				//col.a = clamp(col.a, .45 * _Color.a, _Color.a);

				return col;
            }
            ENDCG
        }

		        Pass {
            Stencil {
                Ref 128
                Comp NotEqual
                Pass Zero
                Fail Zero
            }

            Cull Front

            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;

                float4 normal : NORMAL;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            fixed4 _OutlineColor;
            fixed _OutlineWidth;
			fixed _Alpha;

            v2f vert(appdata v) {
                v2f o;

                float4 clipVertex = UnityObjectToClipPos(v.vertex);
                float2 clipNormal = normalize(TransformViewToProjection(mul((float3x3)UNITY_MATRIX_IT_MV, v.normal)));

                float2 offset = clipNormal.xy / _ScreenParams.xy * 1 * clipVertex.w * 2;

                clipVertex.xy += offset;

                o.vertex = clipVertex;
                o.uv = v.uv;

                return o;
            }

            fixed4 frag(v2f i) : SV_TARGET {
                fixed4 col = _OutlineColor;
				col.a = _Alpha;

                return col;
            }

            ENDCG
        }

    }
}
