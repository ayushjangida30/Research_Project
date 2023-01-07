Shader "Hidden/LlamaZOO/TerrainEngine/Splatmap/Standard-Base" 
{
    Properties 
	{
        _MainTex ("Base (RGB) Smoothness (A)", 2D) = "white" {}
        _MetallicTex ("Metallic (R)", 2D) = "white" {}

        // used in fallback on old cards
        _Color ("Main Color", Color) = (1,1,1,1)

		[Enum(Albedo(A),0,Cutout(A),1,Cutout(R),2)] _CutoutTextureSourceChannel("Coutout texture source channel", Float) = 0
		_CutoutTex("Cutout", 2D) = "white" {}
		_Cutoff("Alpha Cutoff", Range(0.0, 1.0)) = 0.5

		[Enum(Detail Mask(A),0,Detail Mask(R),1)] _DetailMaskSourceChannel("Detail Mask texture source channel", Float) = 0

		[Toggle(_DETAIL_MAP)] _EnableDetailMap("Enable First Detail", Float) = 0.0
		_DetailMask("Detail Mask", 2D) = "white" {}

		_DetailAlbedoMap("Detail Albedo x2", 2D) = "white" {}
		_DetailColor("Detail Color", Color) = (1,1,1,1)
		_DetailNormalMapScale("Scale", Float) = 1.0
		_DetailNormalMap("Normal Map", 2D) = "bump" {}

		[Toggle(_SECOND_DETAIL_MAP)] _EnableSecondDetailMap("Enable Second Detail", Float) = 0.0
		_SecondDetailMask("Second Detail Mask", 2D) = "white" {}

		_SecondDetailAlbedoMap("Detail Albedo x2", 2D) = "white" {}
		_SecondDetailColor("Second Detail Color", Color) = (1,1,1,1)
		_SecondDetailNormalMapScale("Scale", Float) = 1.0
		_SecondDetailNormalMap("Normal Map", 2D) = "bump" {}

		[Toggle(_BACKFACE_RENDERING)] _EnableBackfaceRendering("Enable Backface", Float) = 0.0
		_BackfaceTex("Underground (RGB)", 2D) = "white" {}
		_BackfaceColor("Backface Color", Color) = (1,1,1,1)

		[HideInInspector] _Mode("__mode", Float) = 0.0
    }

    SubShader 
	{
        Tags 
		{
            "RenderType" = "Opaque"
            "Queue" = "Geometry-100"
        }
        LOD 300

		Cull Back

        CGPROGRAM
        #pragma surface surf Standard vertex:SplatmapVert addshadow fullforwardshadows
        #pragma instancing_options assumeuniformscaling nomatrices nolightprobe nolightmap forwardadd
        #pragma target 4.5

        #pragma exclude_renderers gles

        #define TERRAIN_BASE_PASS
        #define TERRAIN_INSTANCED_PERPIXEL_NORMAL
		#include "../Shaders/TerrainSplatmapCommon.cginc"
        #include "UnityPBSLighting.cginc"
		
        sampler2D _MainTex;
        sampler2D _MetallicTex;

		half _Mode;

		half _CutoutTextureSourceChannel;
		sampler2D _CutoutTex;
		half _Cutoff;

		half _DetailMaskSourceChannel;

		half _EnableDetailMap;
		sampler2D _DetailMask;
		sampler2D _DetailAlbedoMap;
		half4 _DetailColor;
		sampler2D _DetailNormalMap;
		half _DetailNormalMapScale;

		half _EnableSecondDetailMap;
		sampler2D _SecondDetailMask;
		sampler2D _SecondDetailAlbedoMap;
		half4 _SecondDetailColor;
		sampler2D _SecondDetailNormalMap;
		half _SecondDetailNormalMapScale;

        void surf (Input IN, inout SurfaceOutputStandard o) 
		{
            half4 c = tex2D (_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;
            o.Alpha = 1;
            o.Smoothness = c.a;
            o.Metallic = tex2D (_MetallicTex, IN.tc.xy).r;

            #if defined(INSTANCING_ON) && defined(SHADER_TARGET_SURFACE_ANALYSIS) && defined(TERRAIN_INSTANCED_PERPIXEL_NORMAL)
                o.Normal = float3(0, 0, 1); // make sure that surface shader compiler realizes we write to normal, as UNITY_INSTANCING_ENABLED is not defined for SHADER_TARGET_SURFACE_ANALYSIS.
            #endif

            #if defined(UNITY_INSTANCING_ENABLED) && !defined(SHADER_API_D3D11_9X) && defined(TERRAIN_INSTANCED_PERPIXEL_NORMAL)
                o.Normal = normalize(tex2D(_TerrainNormalmapTexture, IN.tc.zw).xyz * 2 - 1).xzy;
            #endif

			if (_EnableDetailMap == 1)
			{
				float detailMask = 0;

				if (_DetailMaskSourceChannel == 0)
					detailMask = (tex2D(_DetailMask, IN.uv_DetailMask)).a;
				else
					detailMask = (tex2D(_DetailMask, IN.uv_DetailMask)).r;

				float3 detailAlbedo = (tex2D(_DetailAlbedoMap, IN.uv_DetailAlbedoMap)).rgb * _DetailColor;
				o.Albedo = lerp(o.Albedo, detailAlbedo, detailMask);

				float3 detailNormal = UnpackScaleNormal(tex2D(_DetailNormalMap, IN.uv_DetailAlbedoMap), _DetailNormalMapScale);
				detailNormal = normalize(detailNormal.xyz);
				detailNormal = normalize(o.Normal + detailNormal);
				o.Normal = lerp(o.Normal, detailNormal, detailMask);
			}

			if (_EnableSecondDetailMap == 1)
			{
				float secondDetailMask = 0;

				if (_DetailMaskSourceChannel == 0)
					secondDetailMask = (tex2D(_SecondDetailMask, IN.uv_SecondDetailMask)).a;
				else
					secondDetailMask = (tex2D(_SecondDetailMask, IN.uv_SecondDetailMask)).r;

				float3 secondDetailAlbedo = (tex2D(_SecondDetailAlbedoMap, IN.uv_SecondDetailAlbedoMap)).rgb * _SecondDetailColor;
				o.Albedo += secondDetailAlbedo * secondDetailMask;;

				float3 secondDetailNormal = UnpackScaleNormal(tex2D(_SecondDetailNormalMap, IN.uv_SecondDetailAlbedoMap), _SecondDetailNormalMapScale);
				secondDetailNormal = normalize(secondDetailNormal.xyz);
				secondDetailNormal = normalize(o.Normal + secondDetailNormal);
				o.Normal = lerp(o.Normal, secondDetailNormal, secondDetailMask);
			}

			if (_Mode == 1)
			{
				///
				/// Cutout according to alpha map
				if (_CutoutTextureSourceChannel == 0)
				{
					half cutoutValue = c.a;
					clip(cutoutValue - _Cutoff);
				}
				else if (_CutoutTextureSourceChannel == 1)
				{
					half cutoutValue = tex2D(_CutoutTex, IN.uv_CutoutTex).a;
					clip(cutoutValue - _Cutoff);
				}
				else
				{
					half cutoutValue = tex2D(_CutoutTex, IN.uv_CutoutTex).r;
					clip(cutoutValue - _Cutoff);
				}
			}
        }

        ENDCG

		Cull Front

		CGPROGRAM
		#pragma surface surf Standard vertex:SplatmapVert addshadow fullforwardshadows
		#pragma instancing_options assumeuniformscaling nomatrices nolightprobe nolightmap forwardadd
		#pragma target 4.5

		#pragma exclude_renderers gles d3d9

		#define TERRAIN_BASE_PASS
		#define TERRAIN_INSTANCED_PERPIXEL_NORMAL
		#include "../Shaders/TerrainSplatmapCommon.cginc"
		#include "UnityPBSLighting.cginc"

		half _Mode;

		half _CutoutTextureSourceChannel;
		sampler2D _CutoutTex;
		half _Cutoff;

		half _EnableBackfaceRendering;
		sampler2D _BackfaceTex;
		half4 _BackfaceColor;

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			if (_EnableBackfaceRendering == 1)
			{
				float4 albedo = (tex2D(_BackfaceTex, IN.uv_BackfaceTex) * _BackfaceColor);
				o.Albedo = albedo.rgb;

#if defined(INSTANCING_ON) && defined(SHADER_TARGET_SURFACE_ANALYSIS) && defined(TERRAIN_INSTANCED_PERPIXEL_NORMAL)
				o.Normal = float3(0, 0, 1); // make sure that surface shader compiler realizes we write to normal, as UNITY_INSTANCING_ENABLED is not defined for SHADER_TARGET_SURFACE_ANALYSIS.
#endif

#if defined(UNITY_INSTANCING_ENABLED) && !defined(SHADER_API_D3D11_9X) && defined(TERRAIN_INSTANCED_PERPIXEL_NORMAL)
				o.Normal = normalize(tex2D(_TerrainNormalmapTexture, IN.tc.zw).xyz * 2 - 1).xzy;
#endif
				if (_Mode == 1)
				{
					///
					/// Cutout according to alpha map
					if (_CutoutTextureSourceChannel == 0)
					{
						half cutoutValue = albedo.a;
						clip(cutoutValue - _Cutoff);
					}
					else if (_CutoutTextureSourceChannel == 1)
					{
						half cutoutValue = tex2D(_CutoutTex, IN.uv_CutoutTex).a;
						clip(cutoutValue - _Cutoff);
					}
					else
					{
						half cutoutValue = tex2D(_CutoutTex, IN.uv_CutoutTex).r;
						clip(cutoutValue - _Cutoff);
					}
				}
			}
			else
			{
				discard;
			}
		}

		ENDCG

        UsePass "Hidden/Nature/Terrain/Utilities/PICKING"
        UsePass "Hidden/Nature/Terrain/Utilities/SELECTION"
    }

    FallBack Off
}
