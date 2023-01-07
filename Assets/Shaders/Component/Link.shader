Shader "JL/Component/Link" {
    Properties {
        [PerRendererData] _Color("Color", Color) = (0, 0, 0, 1)
        [PerRendererData] _Alpha("Alpha", float) = 0

        [PerRendererData] _OutlineColor("OutlineColor", Color) = (0, 0, 0, 1)
        [PerRendererData] _OutlineWidth("OutlineWidth", float) = 0
    }

    SubShader {
        Tags {
            "Queue" = "Transparent+300"
            "RenderType" = "Transparent"
        }
        LOD 100

        //ZTest Off
        Blend SrcAlpha OneMinusSrcAlpha

        Offset 0, 0

        Pass {
            Stencil {
                Ref 128
                Comp Always
                Pass Replace
                Fail Keep
            }

            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct v2f {
                float4 vertex : SV_POSITION;

                fixed4 diff : COLOR0;
            };

            fixed4 _Color;
            fixed _Alpha;

            fixed4 _OutlineColor;
            fixed _OutlineWidth;

            v2f vert(appdata_base v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);

                half3 worldNormal = UnityObjectToWorldNormal(v.normal);
                half3 p = normalize(_WorldSpaceCameraPos - mul(unity_ObjectToWorld, v.vertex));
                half nl = max(0, dot(worldNormal, p));
                o.diff = nl * fixed4(1,1,1,1);

                return o;
            }

            fixed4 frag(v2f i) : SV_TARGET {
                fixed4 c = _Color * i.diff;

                return fixed4(c.xyz, 1);
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

            fixed4 _Color;
            fixed _Alpha;

            fixed4 _OutlineColor;
            fixed _OutlineWidth;

            v2f vert(appdata v) {
                v2f o;

                float4 clipVertex = UnityObjectToClipPos(v.vertex);
                float2 clipNormal = normalize(TransformViewToProjection(mul((float3x3)UNITY_MATRIX_IT_MV, v.normal)));

                float2 offset = clipNormal.xy / _ScreenParams.xy * _OutlineWidth * clipVertex.w * 2;

                clipVertex.xy += offset;

                o.vertex = clipVertex;
                o.uv = v.uv;

                return o;
            }

            fixed4 frag(v2f i) : SV_TARGET {
                fixed4 col = _OutlineColor;

                return col;
            }

            ENDCG
        }
    }
}
