Shader "JL/Component/Bar/Overview" {
    Properties {
        [PerRendererData] _Color("Color", Color) = (0, 0, 0, 1)
        [PerRendererData] _Alpha("Alpha", float) = 0
    }

    SubShader {
        Tags {
            "Queue" = "Transparent"
            "RenderType" = "Opaque"
        }
        LOD 100

        Offset -1, -1

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

            v2f vert(appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;

                return o;
            }

            fixed4 frag(v2f i) : SV_TARGET {
                fixed4 col = fixed4(_Color.rgb, 1);

                return col;
            }

            ENDCG
        }
    }
}
