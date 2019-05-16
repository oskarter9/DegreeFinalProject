Shader "Custom/TimeTravelPortal" {
	Properties
	{
		_ColorAlpha("Color Alpha Value", Range(0, 1)) = 0.015
	}
	SubShader
	{
		Tags {"Queue"="Transparent" "RenderType"="Transparent" }
		LOD 100
		Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			#include "UnityStandardUtils.cginc"

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float4 screen_uv : TEXCOORD1;
			};
			
			v2f vert (appdata_base v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.screen_uv = ComputeScreenPos(o.vertex);
				return o;
			}
			sampler2D _TimeCrackTexture;
			float _ColorAlpha;

			fixed4 frag (v2f i) : COLOR
			{
				float2 screen_uv = i.screen_uv.xy / i.screen_uv.w;
				fixed4 col = tex2D(_TimeCrackTexture, screen_uv);
				col.a = _ColorAlpha;
				return col;
			}
			ENDCG
		}
	}
}
