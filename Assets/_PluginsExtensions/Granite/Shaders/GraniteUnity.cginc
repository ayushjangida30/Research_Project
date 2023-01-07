#ifndef GRANITE_UNITY_INCLUDED
#define GRANITE_UNITY_INCLUDED
//
// We have to do some hacks here to support legacy surface shaders. This is how Unity seems to work
// - Preprocess the legacy surface shaders in some sort of DX9 mode: SHADER_TARGET < 35 and SHADER_API_D3D9 will be set. 
//        this preprocess uses the CG compler UNITY_COMPILER_CG will thus be set.
// - Then compile the result of this preprocessing using the modern HLSL compiler. During this second compile
//      SHADER_API_D3D11 and SHADER_TARGET >= 35 will be set. Compiler will also be UNITY_COMPILER_HLSL.
//
// Or solution is kindof a hack
//      - When we detect the CG compliler we play nice and give it DX9 code. This will not run correctly! its only just to pass the 
//          surface shader preprocess step.
//
//      - When we later detect the modern hlsl compiler we use the modern dx11 granite code. If we see this modern compiler AND it
//          tries to compile to something lower than 3.5 we generate this error here. That way CG passes this error check but the HLSL 
//          compiler doesn't
//
// Update 13/10/2017: It seems Unity has fixed the CG / dummy dx9 compiler stage as of 2017.2.0b8, as SHADER_TARGET now holds the 
// correct value as given in the shader's #pragma target <value>. See https://unity3d.com/unity/beta/unity2017.2.0b8.
// (SHADER_TARGET was simply undefined in the CG compiler step).This means we can simplify the checks: whatever compile stage we are in,
// everything below the shader target threshold (45 at time of writing) is rejected. 
//
#if SHADER_TARGET < 45
#error Shader model 4.0 and lower is not supported by Granite anymore. Please update your shader's '#pragma target' to 4.5.
#endif

// UNITY_COMPILER_CG is now also defined when compiling for PS4
#if defined(UNITY_COMPILER_CG) && !SHADER_API_PSSL
#define GRANITE_SM3_MODE
#endif


#if defined(GRANITE_SM3_MODE)|| defined(SHADER_API_MOBILE)
// Internal note: To make a really working 3.0 version you will have to modify the native plugin to generate DX9 style float translation tables.
// this shader code itself still hadles 3.0 correctly but I can't run properly without proper translation tables.
// Note that float-based translation tables have known precision issues on AMD hardware.
// This 3.0 path is here used so we can work with surface shaders (see docs above)
// Mobile: We always generate float translation tables
#define GRA_HLSL_3 1
#define GRA_FORCE_SM3 1
#else
#define GRA_HLSL_5 1
#endif

#if SHADER_API_D3D9 || SHADER_API_PSSL
#define GRA_BGRA 1
#elif SHADER_API_D3D11
#define GRA_BGRA 0
#endif

#define GRA_ROW_MAJOR 1
#define GRA_DEBUG 0
#define GRA_DEBUG_TILES 0
#define GRA_TEXTURE_ARRAY_SUPPORT 0

#define GRA_NO_UNORM

// This include is needed for the UnpackScaleNormal function used by DeclareGraniteLayer__
#include "UnityStandardUtils.cginc"
#include "UnityPBSLighting.cginc"
#include "Assets/GraniteSDK/Shaders/GraniteShaderLib.cginc"
#include "Assets/GraniteSDK/Shaders/GraniteShaderConfig.cginc"

#define GR_JOIN2(base, idx) base##_##idx
#define GR_JOIN(a,b) GR_JOIN2(a,b)

float4 _GrSTCB;
float4 _GrSTCB2 = float4(10, 0, 0, 0);
float4 _GrIndex;

// For some reason the default unity defines seem to prefer separate sampler/tex invalid even if the "pragma target 2.0" is there
// so we just use our own versions which actually use the old-school "sampler2D" in the non hlsl 5 case
#if GRA_HLSL_5 == 1
#define GRANITE_DECLARE_TEX2D_NOSAMPLER(texName) UNITY_DECLARE_TEX2D_NOSAMPLER(texName)
#define GRANITE_DECLARE_TEX2D(texName) UNITY_DECLARE_TEX2D(texName)
#define GRANITE_DECLARE_TEX2D_FLOAT_NOSAMPLER(texName) GRANITE_DECLARE_TEX2D_NOSAMPLER(texName)
#define GRANITE_DECLARE_TEX2D_FLOAT(texName) GRANITE_DECLARE_TEX2D(texName)
#define GRANITE_SAMPLE_TEX2D(texName,texcoord) UNITY_SAMPLE_TEX2D(texName,texcoord)
#else
#define GRANITE_DECLARE_TEX2D_NOSAMPLER(texName) sampler2D texName
#define GRANITE_DECLARE_TEX2D(texName) sampler2D texName
#define GRANITE_DECLARE_TEX2D_FLOAT_NOSAMPLER(texName) sampler2D_float texName
#define GRANITE_DECLARE_TEX2D_FLOAT(texName) sampler2D_float texName
#define GRANITE_SAMPLE_TEX2D(texName,texcoord) tex2D(texName,texcoord)
#endif

GRANITE_DECLARE_TEX2D(_ResolveTex);


// RWTextures need SM 4.5. The prepass compiler of the surface shaders doesn't support RWTextures so make sure it's disabled in that case.
#if SHADER_TARGET >= 45 && !defined(GRANITE_SM3_MODE)
#define GRANITE_RWTEXTURE_AVAILABLE
#endif

// Check if we need to enable the magic Android workaround for the standard shaders
#if GRANITE_VALID && defined(SHADER_API_GLES3) && defined(GRANITE_RWTEXTURE_AVAILABLE) && defined(UNITY_STANDARD_INPUT_INCLUDED) && !defined(GRANITE_RW_RESOLVE)
#define GRANITE_WITH_ANDROID_WORKAROUND
#endif

#if GRANITE_VALID && defined(GRANITE_RWTEXTURE_AVAILABLE)
// The RWTexture is abused on GLES3 to fix a mysterious shader error with the standard shader
#if defined(GRANITE_RW_RESOLVE) || defined(GRANITE_WITH_ANDROID_WORKAROUND)
// PS4 sets the RWTexture at 1 index below where you would expect it
#if SHADER_API_PSSL
RWTexture2D<float4> _ResolveTexRW : register(u6);
#else
RWTexture2D<float4> _ResolveTexRW : register(u7);
#endif
#endif
#endif


#define FIXUP_NAME(base, idx) base##_##idx
#define FIXUP_DEFINE(base, idx) base##_##idx

//
// the _FIRST defines declare a sampler and a texture, the rest only textures but no sampler
//
#define DEFINE_GRANITE_TEXTURE(idx)	\
	float4x4 GR_JOIN(GraniteParameters,idx); \
	float4x4 GR_JOIN(GraniteParameters2,idx); \
	float4x4 GR_JOIN(GraniteVirtualParameters,idx); \
	float4x4 GR_JOIN(GraniteVirtualParameters2,idx); \
	GRANITE_DECLARE_TEX2D_FLOAT_NOSAMPLER(GR_JOIN(GraniteTrans,idx));

#define DEFINE_GRANITE_TEXTURE_FIRST(idx)	\
	float4x4 GR_JOIN(GraniteParameters,idx); \
	float4x4 GR_JOIN(GraniteParameters2,idx); \
	float4x4 GR_JOIN(GraniteVirtualParameters,idx); \
	float4x4 GR_JOIN(GraniteVirtualParameters2,idx); \
	GRANITE_DECLARE_TEX2D_FLOAT(GR_JOIN(GraniteTrans,idx));

#define DEFINE_GRANITE_CACHE_TEXTURE(idx)	\
	GRANITE_DECLARE_TEX2D_NOSAMPLER(GR_JOIN(GraniteCache,idx));

#define DEFINE_GRANITE_CACHE_TEXTURE_FIRST(idx)	\
	GRANITE_DECLARE_TEX2D(GR_JOIN(GraniteCache,idx));

// Cache samplers and textures
DEFINE_GRANITE_CACHE_TEXTURE_FIRST(0)
DEFINE_GRANITE_CACHE_TEXTURE_FIRST(1)
DEFINE_GRANITE_CACHE_TEXTURE_FIRST(2)
DEFINE_GRANITE_CACHE_TEXTURE_FIRST(3)

// Translation table samplers and textures
DEFINE_GRANITE_TEXTURE_FIRST(0)
DEFINE_GRANITE_TEXTURE(1)
DEFINE_GRANITE_TEXTURE(2)
DEFINE_GRANITE_TEXTURE(3)
DEFINE_GRANITE_TEXTURE(4)
DEFINE_GRANITE_TEXTURE(5)
DEFINE_GRANITE_TEXTURE(6)
DEFINE_GRANITE_TEXTURE(7)

// Getter for textures and samplers
#define GET_TEXTURE(tex) tex
#define GET_SAMPLER(tex) sampler##tex

// Make the correctly typed texture opjects to pass into granite.
// FIXME: these are defining sclope blocks {} so make sure to use them in the
// right way, e.g not adding ";" behind them.
#if GRA_HLSL_5 == 1
#define RETURN_GRANITE_TRANS_TEX( name ) { GraniteTranslationTexture grtt##name; grtt##name.Sampler = GET_SAMPLER(GraniteTrans_0); grtt##name.Texture = GET_TEXTURE(name); return grtt##name; }
#define RETURN_GRANITE_CACHE_TEX( name ) { GraniteCacheTexture grct##name; grct##name.Sampler = GET_SAMPLER(name); grct##name.Texture = GET_TEXTURE(name); return grct##name; }
#define DECLARE_GRANITE_CACHE_TEX( variableName, layer ) GraniteCacheTexture variableName; variableName.Sampler = GET_SAMPLER(GraniteCache_##layer); variableName.Texture = GET_TEXTURE(GraniteCache_##layer);
#define graniteTransTexObject GraniteTranslationTexture
#define graniteCacheTexObject GraniteCacheTexture
#define GRA_LOOKUP Granite_Lookup_Dynamic_Anisotropic
#else
#define RETURN_GRANITE_TRANS_TEX( name ) { return name; }
#define RETURN_GRANITE_CACHE_TEX( name ) { return name; }
#define DECLARE_GRANITE_CACHE_TEX( variableName, layer ) sampler2D variableName = GraniteCache_##layer
#define graniteTransTexObject sampler2D
#define graniteCacheTexObject sampler2D
#define GRA_LOOKUP Granite_Lookup_Dynamic_Linear
#endif

	/**
		Get the translation table for the currently active GTS file
	*/
	graniteTransTexObject GetGraniteTranslationTable()
{
#if GR_JOIN(GRANITE_GTS,0)
	RETURN_GRANITE_TRANS_TEX(GR_JOIN(GraniteTrans, 0));
#endif

#if GR_JOIN(GRANITE_GTS,1)
	RETURN_GRANITE_TRANS_TEX(GR_JOIN(GraniteTrans, 1));
#endif

#if GR_JOIN(GRANITE_GTS,2)
	RETURN_GRANITE_TRANS_TEX(GR_JOIN(GraniteTrans, 2));
#endif

#if GR_JOIN(GRANITE_GTS,3)
	RETURN_GRANITE_TRANS_TEX(GR_JOIN(GraniteTrans, 3));
#endif

#if GR_JOIN(GRANITE_GTS,4)
	RETURN_GRANITE_TRANS_TEX(GR_JOIN(GraniteTrans, 4));
#endif

#if GR_JOIN(GRANITE_GTS,5)
	RETURN_GRANITE_TRANS_TEX(GR_JOIN(GraniteTrans, 5));
#endif

#if GR_JOIN(GRANITE_GTS,6)
	RETURN_GRANITE_TRANS_TEX(GR_JOIN(GraniteTrans, 6));
#endif

#if GR_JOIN(GRANITE_GTS,7)
	RETURN_GRANITE_TRANS_TEX(GR_JOIN(GraniteTrans, 7));
#endif

	//return _ResolveTex;
	RETURN_GRANITE_TRANS_TEX(_ResolveTex);
}

/**
	Get the granite parameters for the currently active GTS file
*/
float4x4 _GetGraniteParameters()
{
#if GR_JOIN(GRANITE_GTS,0)
	return GR_JOIN(GraniteParameters, 0);
#endif

#if GR_JOIN(GRANITE_GTS,1)
	return GR_JOIN(GraniteParameters, 1);
#endif

#if GR_JOIN(GRANITE_GTS,2)
	return GR_JOIN(GraniteParameters, 2);
#endif

#if GR_JOIN(GRANITE_GTS,3)
	return GR_JOIN(GraniteParameters, 3);
#endif

#if GR_JOIN(GRANITE_GTS,4)
	return GR_JOIN(GraniteParameters, 4);
#endif

#if GR_JOIN(GRANITE_GTS,5)
	return GR_JOIN(GraniteParameters, 5);
#endif

#if GR_JOIN(GRANITE_GTS,6)
	return GR_JOIN(GraniteParameters, 6);
#endif

#if GR_JOIN(GRANITE_GTS,7)
	return GR_JOIN(GraniteParameters, 7);
#endif

	float4x4 dummy = { 1,0,0,0,	0,1,0,0,	0,0,1,0,	0,0,0,1 };
	return dummy;
}

/**
	Get the granite parameters 2 for the currently active GTS file
*/
float4x4 _GetGraniteParameters2()
{
#if GR_JOIN(GRANITE_GTS,0)
	return GR_JOIN(GraniteParameters2, 0);
#endif

#if GR_JOIN(GRANITE_GTS,1)
	return GR_JOIN(GraniteParameters2, 1);
#endif

#if GR_JOIN(GRANITE_GTS,2)
	return GR_JOIN(GraniteParameters2, 2);
#endif

#if GR_JOIN(GRANITE_GTS,3)
	return GR_JOIN(GraniteParameters2, 3);
#endif

#if GR_JOIN(GRANITE_GTS,4)
	return GR_JOIN(GraniteParameters2, 4);
#endif

#if GR_JOIN(GRANITE_GTS,5)
	return GR_JOIN(GraniteParameters2, 5);
#endif

#if GR_JOIN(GRANITE_GTS,6)
	return GR_JOIN(GraniteParameters2, 6);
#endif

#if GR_JOIN(GRANITE_GTS,7)
	return GR_JOIN(GraniteParameters2, 7);
#endif

	float4x4 dummy = { 1,0,0,0,	0,1,0,0,	0,0,1,0,	0,0,0,1 };
	return dummy;
}

/**
	Get the granite parameters (virtual for resolver) for the currently active GTS file
*/
float4x4 _GetGraniteParametersVirtual()
{
	int idx = (int)_GrIndex.x;
	if (idx == 0) return GraniteVirtualParameters_0;
	if (idx == 1) return GraniteVirtualParameters_1;
	if (idx == 2) return GraniteVirtualParameters_2;
	if (idx == 3) return GraniteVirtualParameters_3;
	if (idx == 4) return GraniteVirtualParameters_4;
	if (idx == 5) return GraniteVirtualParameters_5;
	if (idx == 6) return GraniteVirtualParameters_6;
	if (idx == 7) return GraniteVirtualParameters_7;

	float4x4 dummy = { 1,0,0,0,	0,1,0,0,	0,0,1,0,	0,0,0,1 };
	return dummy;
}

/**
	Get the granite parameters 2 (virtual for resolver) for the currently active GTS file
*/
float4x4 _GetGraniteParameters2Virtual()
{
	int idx = (int)_GrIndex.x;
	if (idx == 0) return GraniteVirtualParameters2_0;
	if (idx == 1) return GraniteVirtualParameters2_1;
	if (idx == 2) return GraniteVirtualParameters2_2;
	if (idx == 3) return GraniteVirtualParameters2_3;
	if (idx == 4) return GraniteVirtualParameters2_4;
	if (idx == 5) return GraniteVirtualParameters2_5;
	if (idx == 6) return GraniteVirtualParameters2_6;
	if (idx == 7) return GraniteVirtualParameters2_7;

	float4x4 dummy = { 1,0,0,0,	0,1,0,0,	0,0,1,0,	0,0,0,1 };
	return dummy;
}

/**
	Get a GraniteConstantBuffers object for the currently active GTS file
*/
GraniteConstantBuffers GetGraniteConstantBuffers()
{
	GraniteConstantBuffers CB;
	CB.tilesetBuffer.data[0] = _GetGraniteParameters();
	CB.tilesetBuffer.data[1] = _GetGraniteParameters2();
	CB.streamingTextureBuffer.data[0] = _GrSTCB;
	CB.streamingTextureBuffer.data[1] = _GrSTCB2;
	return CB;
}

/**
	Get a GraniteConstantBuffers (virtual for resolver) object for the currently active GTS file
*/
GraniteConstantBuffers GetGraniteVirtualConstantBuffers()
{
	GraniteConstantBuffers CB;
	CB.tilesetBuffer.data[0] = _GetGraniteParametersVirtual();
	CB.tilesetBuffer.data[1] = _GetGraniteParameters2Virtual();
	CB.streamingTextureBuffer.data[0] = _GrSTCB;
	CB.streamingTextureBuffer.data[1] = _GrSTCB2;
	return CB;
}

/**
	Is the currently active asset a UDIM asset or not
*/
bool IsGraniteUDIM()
{
	int value = (int)_GrIndex.y;
	return value > 0;
}

/**
	Helper function, overlays the "texture not in tileset" in editor overlay.
*/
float4 SampleGraniteInvalid(float4 base, float2 texCoords)
{
	float4 overlay = GRANITE_SAMPLE_TEX2D(_ResolveTex, (float2(1, 1) - texCoords) * 8.0f);
	float4 res;
	res.xyz = lerp(base.xyz, overlay.xyz, overlay.a);
	res.a = base.a;
	return res;
}

/**
	Get the cache texture for the given layer index.
*/
graniteCacheTexObject GetCacheForLayer(uint layer)
{
	if (layer == 0)
		RETURN_GRANITE_CACHE_TEX(GR_JOIN(GraniteCache, 0))
	else if (layer == 1)
		RETURN_GRANITE_CACHE_TEX(GR_JOIN(GraniteCache, 1))
	else if (layer == 2)
		RETURN_GRANITE_CACHE_TEX(GR_JOIN(GraniteCache, 2))
	else if (layer == 3)
		RETURN_GRANITE_CACHE_TEX(GR_JOIN(GraniteCache, 3))

	else RETURN_GRANITE_CACHE_TEX(_ResolveTex)
}

/**
	All-in-one sampler function.
	Less efficient than the ones below but easier to use.
*/
float4 SampleGraniteSimple(float2 texCoords, uint layer)
{
	float4 color = 0;
	float4 not_used = 0;
	GraniteLookupData graniteLookupData;
	GRA_LOOKUP(GetGraniteConstantBuffers(),
		GetGraniteTranslationTable(), texCoords, IsGraniteUDIM(),
		graniteLookupData, not_used);
	Granite_Sample_HQ(GetGraniteConstantBuffers(),
		graniteLookupData,
		GetCacheForLayer(layer), layer,
		color);
	return color;
}


//
// If we are baking lightmaps or other fancyness don't render the Granite error overlays
//
#if defined(UNITY_PASS_META)
#define GRANITE_OVERLAY_ALPHA 0
#else
#define GRANITE_OVERLAY_ALPHA 1
#endif

//
// Some nice layer index to "actual layer index" conversion with defines. This enables support for
// less than 4 layers in a tileset. For example, a bumpmap would normally be bound to layer 3. If
// only 2 layers are compiled into a tileset, the "actual layer index" becomes 1.
// The defines do this conversion: 3 -> LAYER3 -> expansion into actual value -> call DeclareGraniteLayer with this value
//
#define NAME(index) LAYER##index
#define NAME_TO_VALUE(layername) layername
#define INDEX_TO_VALUE(index) NAME_TO_VALUE(NAME(index))

#define DeclareGraniteLayerX(layerIndex,layerSampler) DeclareGraniteLayer__(layerIndex,layerSampler)
#define DeclareGraniteLayer(layerIndex,layerSampler) DeclareGraniteLayerX(INDEX_TO_VALUE(layerIndex),layerSampler)  // expands layerIndex to actual int

#define DeclareGraniteLayerLODX(layerIndex,layerSampler) DeclareGraniteLayerLOD__(layerIndex,layerSampler)
#define DeclareGraniteLayerLOD(layerIndex,layerSampler) DeclareGraniteLayerLODX(INDEX_TO_VALUE(layerIndex),layerSampler)  // expands layerIndex to actual int
//
// If Granite is valid for this shader use the Granite functions, otherwise we fall back to standard 2d texture sampling
// and possibly mix in an overlay
//
#if GRANITE_VALID		

#if defined(GRANITE_RW_RESOLVE)


#if defined(_ALPHATEST_ON)
#define GRANITE_PIXELSHADER_ATTRIBUTES
#else
#define GRANITE_PIXELSHADER_ATTRIBUTES [earlydepthstencil]
#endif


struct LookupDataMRT
{
	GraniteLookupData lookupData;
	float4 resolveOutput;
};

struct LODLookupDataMRT
{
	GraniteLODLookupData lookupData;
	float4 resolveOutput;
};

#define UnityLookupData LookupDataMRT
#define UnityLODLookupData LODLookupDataMRT
#define GetLookupData(x) x.lookupData

// https://gist.github.com/keijiro/ee7bc388272548396870
float RandomValue(float2 uv)
{
	return frac(sin(dot(uv, float2(12.9898, 78.233))) * 43758.5453);
}

#if defined(GRANITE_RWTEXTURE_AVAILABLE)
void GraniteWriteResolveOutputRW(UnityLookupData lookupData, float2 screenPos, float depth)
{

#if defined(GRANITE_SURFACE_SHADER) && !defined(SHADER_API_GLES3)
	// The screenPos we get in a surface shader isn't the actual position used when rendering directly to the backbuffer
	// See https://docs.unity3d.com/Manual/SL-PlatformDifferences.html
	// We don't really care if we resolve upside down, as long as everyting renders consistently
	if (_ProjectionParams.x > 0.0f)
	{
		screenPos.y = _ScreenParams.y - screenPos.y;
	}
#endif

	const uint blockSize = GRA_RWTEXTURE2D_SCALE;

	uint2 pixelPos = uint2(screenPos);
	uint2 blockPos = pixelPos / blockSize;
	uint2 targetBlockOffset = pixelPos & (blockSize - 1);

	uint timeIdx = (uint) (_Time.y * 59.0f);
	uint blockIdx = blockPos.x + blockPos.y;

	uint offset = (timeIdx + blockIdx) & (blockSize*blockSize - 1);
	uint2 blockOffset = uint2(offset & (blockSize - 1), offset / blockSize);

	//[branch]
	if (targetBlockOffset.x == blockOffset.x && targetBlockOffset.y == blockOffset.y)
	{
		// We have to do stippling for alpha tested materials because forcing early depth testing also forces early depth writing.
		// We have to do the stippling in surface shaders because we can't enable early depth testing 
		// (we don't have access to the pixel shader entry function).
#if defined(_ALPHATEST_ON) || defined(GRANITE_SURFACE_SHADER)
					// Random  value between 0-1
		float threshold = RandomValue(screenPos);

		// Add in depth so we pick different thresholds on different depths 
		// Add in time for extra jitter so the pseudorandom pattern changes over time
		threshold = frac(threshold + depth + _Time.y * 7.0f);

		// We're doing alpha testing, so we don't have an actual alpha value 
		// (full transparent pixel will already be clipped before this function is called)
		const float alpha = 0.25f;

		if (alpha > threshold)
		{
			_ResolveTexRW[blockPos] = lookupData.resolveOutput;
		}
#else
		_ResolveTexRW[blockPos] = lookupData.resolveOutput;
#endif
	}
}
#elif defined(GRANITE_SURFACE_SHADER)
void GraniteWriteResolveOutputRWSurfaceShaderDummy(inout SurfaceOutput surfaceOutput, float4 screenPos)
{
	// Force the surface shader to include the necessary data
	// If we don't reference it in DX9 code, the surface shader will not detect the use of e.g. screenPos and Unity will simply not set it.
	// Warning: don't use surfaceOutput.Alpha for this, Alpha isn't used in deferred mode so that code is also stripped!
	// This code will never actually be used, so it doesn't really matter of there are any side effects.
	surfaceOutput.Albedo.r += screenPos.r * 0.000000001f;
}

void GraniteWriteResolveOutputRWSurfaceShaderDummyST(inout SurfaceOutputStandard surfaceOutputStandard, float4 screenPos)
{
	// Force the surface shader to include the necessary data
	// If we don't reference it in DX9 code, the surface shader will not detect the use of e.g. screenPos and Unity will simply not set it.
	// Warning: don't use surfaceOutput.Alpha for this, Alpha isn't used in deferred mode so that code is also stripped!
	// This code will never actually be used, so it doesn't really matter of there are any side effects.
	surfaceOutputStandard.Albedo.r += screenPos.r * 0.000000001f;
}
#endif

// In surface shaders screenPos is between [0, 1], otherwise it's in pixels between [0, viewportDim]
#ifdef GRANITE_SURFACE_SHADER
#ifdef GRANITE_RWTEXTURE_AVAILABLE
#define GraniteWriteResolveOutput(surfaceOutput, data, screenPos)	GraniteWriteResolveOutputRW(data, (screenPos.xy / screenPos.w) * _ScreenParams.xy, Linear01Depth(screenPos.z / screenPos.w));
#define GraniteWriteResolveOutputST(surfaceOutputStandard, data, screenPos)	GraniteWriteResolveOutputRW(data, (screenPos.xy / screenPos.w) * _ScreenParams.xy, Linear01Depth(screenPos.z / screenPos.w));
#else
#define GraniteWriteResolveOutput(surfaceOutput, data, screenPos)	GraniteWriteResolveOutputRWSurfaceShaderDummy(surfaceOutput, screenPos);
#define GraniteWriteResolveOutputST(surfaceOutputStandard, data, screenPos)	GraniteWriteResolveOutputRWSurfaceShaderDummyST(surfaceOutputStandard, screenPos);
#endif
#else
#ifdef GRANITE_RWTEXTURE_AVAILABLE
#define GraniteWriteResolveOutput(data, clipPos)					GraniteWriteResolveOutputRW(data, clipPos.xy, Linear01Depth(clipPos.z / clipPos.w));
#else
#define GraniteWriteResolveOutput(data, clipPos)
#endif
#endif

#else

#define UnityLookupData GraniteLookupData
#define UnityLODLookupData GraniteLODLookupData
#define GetLookupData(x) x

#if defined(GRANITE_WITH_ANDROID_WORKAROUND)

	// Workaround for a standard shader problem on Android: writing to a RWTexture inside a dynamic if.
	// Unknown why this works.

#if defined(_ALPHATEST_ON)
#define GRANITE_PIXELSHADER_ATTRIBUTES
#else
#define GRANITE_PIXELSHADER_ATTRIBUTES [earlydepthstencil]
#endif

void GraniteWriteResolveOutputRW(UnityLookupData lookupData, float2 screenPos, float depth)
{
	if (screenPos.x < -1.0)
	{
		_ResolveTexRW[uint2(0, 0)] = float4(1.0, 0.0, 0.0, 1.0);
	}
}

// In surface shaders screenPos is between [0, 1], otherwise it's in pixels between [0, viewportDim]
#ifdef GRANITE_SURFACE_SHADER
#define GraniteWriteResolveOutput(surfaceOutput, data, screenPos)	GraniteWriteResolveOutputRW(data, (screenPos.xy / screenPos.w) * _ScreenParams.xy, Linear01Depth(screenPos.z / screenPos.w));
#define GraniteWriteResolveOutputST(surfaceOutputStandard, data, screenPos)	GraniteWriteResolveOutputRW(data, (screenPos.xy / screenPos.w) * _ScreenParams.xy, Linear01Depth(screenPos.z / screenPos.w));
#else
#define GraniteWriteResolveOutput(data, clipPos) GraniteWriteResolveOutputRW(data, clipPos.xy, Linear01Depth(clipPos.z / clipPos.w));
#endif

#else

#define GRANITE_PIXELSHADER_ATTRIBUTES

#ifdef GRANITE_SURFACE_SHADER
#define GraniteWriteResolveOutput(surfaceOutput, data, screenPos)
#define GraniteWriteResolveOutputST(surfaceOutputStandard, data, screenPos)
#else
#define GraniteWriteResolveOutput(data, clipPos)
#endif

#endif

#endif


/**
	This function should be called before sampling the individual layers. It will return a struct that should be passed to ExtractGraniteLayer_SamplerName
	to get the actual texture value.
*/
UnityLookupData SampleGraniteLayers(float2 texCoords)
{
#ifndef GRANITE_RW_RESOLVE
	float4 not_used = 0;
#endif
	UnityLookupData unityLookupData;
	Granite_Lookup_Dynamic_Anisotropic(GetGraniteConstantBuffers(),
		GetGraniteTranslationTable(), texCoords, IsGraniteUDIM(), GetLookupData(unityLookupData),
#ifdef GRANITE_RW_RESOLVE
		unityLookupData.resolveOutput
#else
		not_used
#endif
	);
	return unityLookupData;
}

/**
	This function should be called before sampling the individual layers. It will return a struct that should be passed to ExtractGraniteLayer_SamplerName
	to get the actual texture value.
*/
UnityLODLookupData SampleGraniteLayers(float2 texCoords, float lod)
{
#ifndef GRANITE_RW_RESOLVE
	float4 not_used = 0;
#endif
	UnityLODLookupData unityLODLookupData;
	Granite_Lookup_Dynamic_Anisotropic(GetGraniteConstantBuffers(),
		GetGraniteTranslationTable(), texCoords, IsGraniteUDIM(), lod, GetLookupData(unityLODLookupData),
#ifdef GRANITE_RW_RESOLVE
		unityLODLookupData.resolveOutput
#else
		not_used
#endif
	);
	return unityLODLookupData;
}

/**
	This define causes two sample functions to be Generated for use in the shader.
	- ExtractGraniteLayer_SamplerName(UnityLookupData) : For regular color data
	- ExtractGraniteNormalLayer_SamplerName(UnityLookupData) : For normals

	The UnityLookupData data is the object returned by SampleGraniteLayers above.
*/
#define DeclareGraniteLayer__(layerIndex, layerSampler) \
			float4 ExtractGraniteLayer##layerSampler (UnityLookupData data)\
			{\
				float4 graniteSample;\
				DECLARE_GRANITE_CACHE_TEX(cacheTexture, layerIndex);\
				Granite_Sample_HQ(  GetGraniteConstantBuffers(), GetLookupData(data), cacheTexture, layerIndex, graniteSample);\
				return graniteSample;\
			}\
			float4 ExtractGraniteNormalLayer##layerSampler (UnityLookupData data, float bumpScale)\
			{\
				float4 graniteSample;\
				DECLARE_GRANITE_CACHE_TEX(cacheTexture, layerIndex);\
				Granite_Sample_HQ(  GetGraniteConstantBuffers(), GetLookupData(data), cacheTexture, layerIndex, graniteSample);\
				graniteSample.xyz = Granite_UnpackNormal(graniteSample, bumpScale);\
				return graniteSample;\
			}

/**
	This define causes two sample functions to be Generated for use in the shader.
	- ExtractGraniteLayerLOD_SamplerName(UnityLODLookupData) : For regular color data
	- ExtractGraniteNormalLayerLOD_SamplerName(UnityLODLookupData) : For normals

	The UnityLODLookupData data is the object returned by SampleGraniteLayers above.
*/
#define DeclareGraniteLayerLOD__(layerIndex, layerSampler) \
				DeclareGraniteLayer__(layerIndex, layerSampler)\
				float4 ExtractGraniteLayerLOD##layerSampler (UnityLODLookupData data)\
				{\
					float4 graniteSample;\
					DECLARE_GRANITE_CACHE_TEX(cacheTexture, layerIndex);\
					Granite_Sample(  GetGraniteConstantBuffers(), GetLookupData(data), cacheTexture, layerIndex, graniteSample);\
					return graniteSample;\
				}\
				float4 ExtractGraniteNormalLayerLOD##layerSampler (UnityLODLookupData data, float bumpScale)\
				{\
					float4 graniteSample;\
					DECLARE_GRANITE_CACHE_TEX(cacheTexture, layerIndex);\
					Granite_Sample(  GetGraniteConstantBuffers(), GetLookupData(data), cacheTexture, layerIndex, graniteSample);\
					graniteSample.xyz = Granite_UnpackNormal(graniteSample, bumpScale);\
					return graniteSample;\
				}

/**
	Not recommended for use by third parties. Internal low level use. Allows directly accessing layers.
	Notes/Caveats:
	- Note that this is only available if GRANITE_VALID is enabled. This means calling code needs to ensure this everywhere this is called.
	- Explicit use of layer indexes means the shader writer needs to keep track of which layer map to which texture slots.
	- This also doesn't do normal reconstruction.
*/

#define DeclareGraniteLayerX(layerIndex,layerSampler) DeclareGraniteLayer__(layerIndex,layerSampler)
#define DeclareGraniteLayer(layerIndex,layerSampler) DeclareGraniteLayerX(INDEX_TO_VALUE(layerIndex),layerSampler) 

#define DeclareGraniteLayerLODX(layerIndex,layerSampler) DeclareGraniteLayerLOD__(layerIndex,layerSampler)
#define DeclareGraniteLayerLOD(layerIndex,layerSampler) DeclareGraniteLayerLODX(INDEX_TO_VALUE(layerIndex),layerSampler) 

#define GraniteSampleLowLevelX(graniteLookupData,layer) GraniteSampleLowLevel__(graniteLookupData,layer)
#define GraniteSampleLowLevel(graniteLookupData,layer) GraniteSampleLowLevelX(graniteLookupData,INDEX_TO_VALUE(layer))

float4 GraniteSampleLowLevel__(UnityLookupData graniteLookupData, int layer)
{
	float4 result;
	Granite_Sample_HQ(GetGraniteConstantBuffers(), GetLookupData(graniteLookupData), GetCacheForLayer(layer), layer, result);
	return result;
}


#else


#define UnityLookupData float2
#define UnityLODLookupData float2
#define GRANITE_PIXELSHADER_ATTRIBUTES

UnityLookupData SampleGraniteLayers(float2 texCoords)
{
	return texCoords;
}


UnityLODLookupData SampleGraniteLayers(float2 texCoords, float LOD)
{
	return texCoords;
}

#define DeclareGraniteLayer__(layerIndex, layerSampler) \
			float4 ExtractGraniteLayer##layerSampler (float2 data)\
			{\
				float4 result = tex2D(layerSampler, data);\
				return SampleGraniteInvalid(result, data);\
			}\
			float3 ExtractGraniteNormalLayer##layerSampler (float2 data, float bumpScale)\
			{\
				float4 result = tex2D(layerSampler, data);\
				result.xyz = UnpackScaleNormal(result, bumpScale); \
				return result.xyz;\
			}

#define DeclareGraniteLayerLOD__(layerIndex, layerSampler) \
			DeclareGraniteLayer__(layerIndex, layerSampler) \
			float4 ExtractGraniteLayerLOD##layerSampler (float2 data)\
			{\
				float4 result = tex2D(layerSampler, data);\
				return SampleGraniteInvalid(result, data);\
			}\
			float3 ExtractGraniteNormalLayerLOD##layerSampler (float2 data, float bumpScale)\
			{\
				float4 result = tex2D(layerSampler, data);\
				result.xyz = UnpackScaleNormal(result, bumpScale); \
				return result.xyz;\
			}

#ifdef GRANITE_SURFACE_SHADER
#define GraniteWriteResolveOutput(surfaceOutput, data, screenPos)
#define GraniteWriteResolveOutputST(surfaceOutputStandard, data, screenPos)
#else
#define GraniteWriteResolveOutput(data, clipPos)
#endif

#endif

#endif //GRANITE_UNITY_INCLUDED