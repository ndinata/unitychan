// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/CelShader"
{
	Properties
	{
		_Color ("Diffuse Color", Color) = (1,1,1,1)
		_UnlitColor ("Unlit Color", Color) = (0.5,0.5,0.5,1)
		_DiffuseThreshold ("Lighting Threshold", Range(-1.1,1)) = 0.1
		_SpecColor ("Specular Material Color", Color) = (1,1,1,1) //Color of the Material (OBJECT)
		_Shininess ("Shininess", Range(0.5,1)) = 1
		_OutlineThickness ("Outline Thickness", Range(0,1)) = 0.20 //Thickness of the outline
		_MainTex ("Texture", 2D) = "Cube" {}
	}
	SubShader
	{
		//Tags { "RenderType"="Opaque" }
		//LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			//#pragma multi_compile_fog

			//TOON SHADING UNIFORMS
			uniform float4 _Color;
			uniform float4 _UnlitColor;
			uniform float _DiffuseThreshold;
			uniform float4 _SpecColor;
			uniform float _Shininess;
			uniform float _OutlineThickness;

			uniform float4 _LightColor0;
			uniform sampler2D _MainTex;
			uniform float4 _MainTex_ST;

			//#include "UnityCG.cginc"

			struct vertexInput
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 textcoord : TEXCOORD0;
			};

			struct vertexOutput
			{
				//UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
				float3 normalDir : TEXTCOORD1;
				float4 lightDir : TEXTCOORD2;
				float3 viewDir : TEXTCOORD3;
				float2 uv : TEXCOORD0;
			};

			
			vertexOutput vert (vertexInput input)
			{
				vertexOutput output;
				//normalDirection
				output.normalDir = normalize(mul(float4(input.normal, 0.0), unity_WorldToObject).xyz);
				//worldPosition
				float4 posWorld = mul(unity_ObjectToWorld, input.vertex);
				//ViewDirection
				output.viewDir = normalize(_WorldSpaceCameraPos.xyz - posWorld.xyz);
				//lightDirection
				float3 fragmentToLightSource = (_WorldSpaceCameraPos.xyz - posWorld.xyz);
				output.lightDir = float4(
					normalize(lerp(_WorldSpaceLightPos0.xyz, fragmentToLightSource, _WorldSpaceLightPos0.w)),
					lerp(1.0, 1.0 / length(fragmentToLightSource), _WorldSpaceLightPos0.w)
					);

				output.vertex = UnityObjectToClipPos(input.vertex);
				output.uv = input.textcoord;
				
				return output;
			}
			
			float4 frag (vertexOutput input) : SV_Target
			{
				float nDotL = saturate(dot(input.normalDir, input.lightDir.xyz));
				float diffuseCutOff = saturate((max(_DiffuseThreshold, nDotL) - _DiffuseThreshold) * 1000);

				float specularCutOff = saturate(max(_Shininess,dot(reflect(-input.lightDir.xyz,input.normalDir),input.viewDir))-_Shininess);
				
				float outlineStrength = saturate((dot(input.normalDir, input.viewDir) - _OutlineThickness) * 1000);

				float3 ambientLight = (1 - diffuseCutOff) * _UnlitColor.xyz;
				float3 diffuseReflection = (1 - specularCutOff) * _Color.xyz * diffuseCutOff;
				float3 specularReflection = _SpecColor.xyz * specularCutOff;

				float3 combinedLight = (ambientLight+diffuseReflection) * outlineStrength + specularReflection;
				return float4(combinedLight, 1.0);
				// sample the texture
				
			}
			ENDCG
		}
	}
}
