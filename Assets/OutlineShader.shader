Shader "Unlit/OutlineShader"
{
	Properties
	{
		_Color("Main Color", Color) = (0.5,0.5,0.5,1)
		_MainTex("Texture", 2D) = "white" {}
		_OutlineColor ("Outline color", Color) = (0,0,0,1)
		_OutlineWidth ("Outline width", Range(1.0,5.0)) = 1.01
	}
		
	CGINCLUDE
	#include "UnityCG.cginc"

	//We Declare everything here so it can be used for multiple passes
	struct appdata {
			float4 vertex : POSITION;
			float3 normal : NORMAL;
	};

	struct v2f {
			float4 pos : POSITION;
			float4 color : COLOR;
			float3 normal : NORMAL;
	};

	float _OutlineWidth;
	float4 _OutlineColor;

	v2f vert(appdata v) { //Render the normal mesh but bigger
		v.vertex.xyz *= _OutlineWidth;

		v2f output;
		output.pos = UnityObjectToClipPos(v.vertex);
		output.color = _OutlineColor;
		return output;
	};

	ENDCG

	SubShader
	{
		Tags{"Queue" = "Transparent"}
		Pass //Render the outline
		{
			Zwrite Off

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			half4 frag(v2f i) : COLOR
			{
				return _OutlineColor;
			}
			ENDCG
		}

		Pass //Normal Render
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			//make fog work
			#pragma multi_compile_fog

			#include "UnityCG.cginc"

			//We Declare everything here so it can be used for multiple passes
			struct appdata2 {
				float4 vertex : POSITION;
				float3 uv : TEXCOORD0;
			};

			struct v2f2 {
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;

			v2f2 vert(appdata2 v) {
				v2f2 output;
				output.vertex = UnityObjectToClipPos(v.vertex);
				output.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(output, output.vertex);
				return output;
			};

			fixed4 frag(v2f2 i) : SV_TARGET
			{
				fixed4 col = tex2D(_MainTex,i.uv);
				UNITY_APPLY_FOG(i.fogCoord, col);
				return col;
			}

			ENDCG
		}
	}
}
