Shader "LlamaZOO/Intersection Highlight Advanced"
{
	Properties
	{
		[PerRendererData] _Color("Color", Color) = (1,1,1,1)
		[PerRendererData] _Alpha("Alpha", float) = 0.5
	}

		SubShader
	{
		Tags{ "Queue" = "Transparent+100" "RenderType" = "Transparent" }
		Lighting Off

		///
		/// First Pass
		Pass
		{
			ZTest GEqual
			ZWrite Off
			Cull Front

			Stencil
			{
				Ref 1
				Comp always
				Pass incrSat
			}

			ColorMask 0
		}

		///
		/// Second Pass
		Pass
		{
			ZTest GEqual
			ZWrite Off
			Cull Back

			Stencil
			{
				Ref 1
				Comp always
				Pass decrSat
			}

			ColorMask 0
		}

		///
		/// Third Pass
		Pass
		{
			Stencil
			{
				Ref 1
				Comp Equal
				Pass zero
				Fail zero
			}

			ZTest GEqual
			ZWrite Off
			Cull Front
			Blend SrcAlpha OneMinusSrcAlpha

			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				
				float4 vertex : SV_POSITION;
			};

			fixed4 _Color;
			fixed _Alpha;
			

			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				fixed4 col = _Color;
				col.a = _Alpha;
				/// Max alpha comes from colour value
				// col.a = clamp(col.a, .45 * _Color.a, _Color.a);

				return col;
			}

			ENDCG
		}
	}
}