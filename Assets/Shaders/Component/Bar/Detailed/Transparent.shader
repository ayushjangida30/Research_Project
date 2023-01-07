Shader "JL/Component/Bar/Detailed/Transparent" {
    Properties {
        [PerRendererData] _Color("Color", Color) = (0, 0, 0, 1)
        [PerRendererData] _Alpha("Alpha", float) = 0

        [PerRendererData] _OutlineColor("OutlineColor", Color) = (0, 0, 0, 1)
        [PerRendererData] _OutlineWidth("OutlineWidth", float) = 0
    }

    SubShader {
        Tags {
            "Queue" = "Transparent"
            "RenderType" = "Transparent"
        }
        LOD 100

        ZTest Off
        Blend SrcAlpha OneMinusSrcAlpha

        Offset -2, -2

        Pass {
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
                fixed4 col = fixed4(_Color.rgb, _Alpha);

                return col;
            }

            ENDCG
        }
    }
}
