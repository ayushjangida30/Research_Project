Shader "LlamaZOO/Granite/Terrain/Standard"
{
	Properties
	{
		_Color("Main Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}

		[Enum(Albedo (A),0,Cutout (A),1,Cutout (R),2)] _CutoutTextureSourceChannel("Coutout texture source channel", Float) = 0
		_CutoutTex("Cutout", 2D) = "white" {}
		_Cutoff("Alpha Cutoff", Range(0.0, 1.0)) = 0.5
		
		[Enum(Detail Mask (A),0,Detail Mask(R),1)] _DetailMaskSourceChannel("Detail Mask texture source channel", Float) = 0

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
		_BackfaceNormalMapScale("Scale", Float) = 1.0
		_BackfaceNormalMap("Normal Map", 2D) = "bump" {}

		///
		/// Advanced added options -------------------------------------------
		_RenderQueueOverride("Render Queue Override", Range(-1.0, 5000)) = -1
		// -----------------------------------------------------

		[HideInInspector] _Mode("__mode", Float) = 0.0
		[HideInInspector] _SrcBlend("__src", Float) = 1.0
		[HideInInspector] _DstBlend("__dst", Float) = 0.0
		[HideInInspector] _ZWrite("__zw", Float) = 1.0

		[HideInInspector]_GrIndex("GraniteIndex", Vector) = (-1.0, 0.0, 0.0, 0.0)
		[HideInInspector]_GrSTCB("Granite_stcb", Vector) = (0.0, 0.0, 1.0, 1.0)
		[HideInInspector]_GrSTCB2("Granite_stcb2", Vector) = (10.0, 0.0, 1.0, 1.0)
	}

		SubShader
		{
			Tags { "Queue" = "Geometry-100" "RenderType" = "Opaque" "Granite" = "true" }

			LOD 300

			Blend[_SrcBlend][_DstBlend]
			ZWrite[_ZWrite]

			Cull Back

			CGPROGRAM

			#pragma target 4.5 // or higher
			#pragma shader_feature GRANITE_VALID
			#pragma shader_feature GRANITE_GTS_0 GRANITE_GTS_1 GRANITE_GTS_2 GRANITE_GTS_3 GRANITE_GTS_4 GRANITE_GTS_5 GRANITE_GTS_6 GRANITE_GTS_7
			#pragma multi_compile __ GRANITE_RW_RESOLVE			
			#define GRANITE_SURFACE_SHADER 1

			#include "../Shaders/GraniteUnity.cginc"

			#pragma surface surf Standard vertex:SplatmapVert finalcolor:SplatmapFinalColor finalgbuffer:SplatmapFinalGBuffer addshadow fullforwardshadows
			#pragma instancing_options assumeuniformscaling nomatrices nolightprobe nolightmap forwardadd
			#pragma multi_compile_fog

			#pragma exclude_renderers gles d3d9
			#include "UnityPBSLighting.cginc"

			#pragma multi_compile __ _NORMALMAP

			#define TERRAIN_STANDARD_SHADER
			#define TERRAIN_INSTANCED_PERPIXEL_NORMAL
			#define TERRAIN_SURFACE_OUTPUT SurfaceOutputStandard
			#include "../Shaders/TerrainSplatmapCommon.cginc"

			half _Mode;

			sampler2D _MainTex;
			half4 _Color;

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

			half _Metallic0;
			half _Metallic1;
			half _Metallic2;
			half _Metallic3;

			half _Smoothness0;
			half _Smoothness1;
			half _Smoothness2;
			half _Smoothness3;

			DeclareGraniteLayer(0, _MainTex)

			void surf(Input IN, inout SurfaceOutputStandard o) 
			{
				///
				/// Base style orthoimagery
				UnityLookupData data = SampleGraniteLayers(IN.uv_MainTex);
				float4 albedo = ExtractGraniteLayer_MainTex(data);

				half4 color = albedo * _Color;

				half4 splat_control;
				half weight;
				fixed4 mixedDiffuse;
				half4 defaultSmoothness = half4(0, 0, 0, 0);
				SplatmapMix(IN, defaultSmoothness, splat_control, weight, mixedDiffuse, o.Normal);
				o.Albedo = color.rgb;
				o.Alpha = weight;
				o.Smoothness = mixedDiffuse.a;
				o.Metallic = dot(splat_control, half4(0, 0, 0, 0));
				
				GraniteWriteResolveOutputST(o, data, IN.screenPos);


				if (_EnableDetailMap == 1)
				{
					float detailMask = 0;
					
					if(_DetailMaskSourceChannel == 0)
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

			ENDCG

			Cull Front

			CGPROGRAM

			#pragma target 4.5
			#pragma surface surf Standard vertex:SplatmapVert addshadow fullforwardshadows
			#pragma instancing_options assumeuniformscaling nomatrices nolightprobe nolightmap forwardadd
			#pragma multi_compile_fog

			#pragma exclude_renderers gles d3d9
			#include "UnityPBSLighting.cginc"

			#pragma multi_compile __ _NORMALMAP

			#define TERRAIN_STANDARD_SHADER
			#define TERRAIN_INSTANCED_PERPIXEL_NORMAL
			#define TERRAIN_SURFACE_OUTPUT SurfaceOutputStandard
			#include "../Shaders/TerrainSplatmapCommon.cginc"

			half _Mode;

			half _CutoutTextureSourceChannel;
			sampler2D _CutoutTex;
			half _Cutoff;

			half _EnableBackfaceRendering;
			sampler2D _BackfaceTex;
			half4 _BackfaceColor;
			sampler2D _BackfaceNormalMap;
			half _BackfaceNormalMapScale;

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
					float3 backfaceNormal = UnpackScaleNormal(tex2D(_BackfaceNormalMap, IN.uv_BackfaceTex), _BackfaceNormalMapScale);
					backfaceNormal = normalize(backfaceNormal.xyz);
					o.Normal = normalize(o.Normal + backfaceNormal);

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

	Dependency "AddPassShader" = "Hidden/TerrainEngine/Splatmap/Standard-AddPass"
	Dependency "BaseMapShader" = "Hidden/LlamaZOO/TerrainEngine/Splatmap/Standard-Base"
	Dependency "BaseMapGenShader" = "Hidden/TerrainEngine/Splatmap/Standard-BaseGen"

	Fallback Off
	CustomEditor "GraniteTerrainShaderGUI"
}
