Shader "JL/Component/Bar/Detailed/Outline" {
    Properties {
        _Color("Color", Color) = (0, 0, 0, 1)
        _Alpha("Alpha", float) = 1

        _OutlineColor("OutlineColor", Color) = (0, 0, 0, 1)
        _OutlineWidth("OutlineWidth", float) = 0.1
    }

    SubShader {
        Tags {
            "Queue" = "Transparent+1000"
            "RenderType" = "Transparent"
        }
        LOD 100

        ZTest Off
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

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
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
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;

                return o;
            }

            fixed4 frag(v2f i) : SV_TARGET {
                fixed4 col = 0;

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

            fixed4 _Color;
            fixed _Alpha;

            fixed4 _OutlineColor;
            fixed _OutlineWidth;

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

                return col;
            }

            ENDCG
        }
    }
}
