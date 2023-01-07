Shader "JL/Component/Bar/Detailed/Opaque" {
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

        Offset -3, -3

        Pass {
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
                fixed4 col = _Color * i.diff;

                return fixed4(col.xyz, 1);
            }

            ENDCG
        }
    }
}
