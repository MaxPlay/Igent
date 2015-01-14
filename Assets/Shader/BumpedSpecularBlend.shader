Shader "Blending/Bumped Specular" {
	Properties {
		_Color1("Color (RGB)", Color) = (1,1,1)
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_BumpMap ("Normalmap", 2D) = "bump" {}
		_Shininess ("Shininess", Range (0.03, 1)) = 0.078125
		_Color2("Color 2 (RGB)", Color) = (1,1,1)
		_MainTex2 ("Base 2 (RGB)", 2D) = "white" {}
		_BumpMap2 ("Normalmap 2", 2D) = "bump" {}
		_Shininess2 ("Shininess 2", Range (0.03, 1)) = 0.53214
		_SpecColor ("Specular Color", Color) = (0.5, 0.5, 0.5, 1)
		_Blend ("Blend", Range (0,2)) = 0.5
		_BlendMap ("Blendmap (A)", 2D) = "gray" {}
		
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf BlinnPhong

		sampler2D _MainTex;
		sampler2D _MainTex2;
		sampler2D _BlendMap;
		sampler2D _BumpMap;
		sampler2D _BumpMap2;
		fixed4 _Color1;
		fixed4 _Color2;
		float _Blend;
		half _Shininess;
		half _Shininess2;

		struct Input {
			float2 uv_MainTex;
			float2 uv_MainTex2;
			float2 uv_BumpMap;
			float2 uv_BumpMap2;
			float2 uv_BlendMap;
		};
		
		void surf (Input IN, inout SurfaceOutput o) {
			half4 c = tex2D (_MainTex, IN.uv_MainTex);
			half4 d = tex2D (_MainTex2, IN.uv_MainTex2);
			half4 c_nrm = tex2D (_BumpMap, IN.uv_BumpMap);
			half4 d_nrm = tex2D (_BumpMap2, IN.uv_BumpMap2);
			half4 e = tex2D (_BlendMap, IN.uv_BlendMap);
			//half blendlerp = clamp (e.a *_Blend-1);
			half4 tex = lerp (c*_Color1,d*_Color2,clamp(e.a *_Blend-1,0,1));
			half4 nrm = lerp (c_nrm,d_nrm,clamp(e.a *_Blend-1,0,1));
			o.Albedo = tex.rgb;
			o.Alpha = tex.a;
			o.Gloss = lerp (c.a,d.a,clamp(e.a *_Blend-1,0,1));
			o.Specular = lerp (_Shininess,_Shininess2,clamp(e.a *_Blend-1,0,1));
			o.Normal = UnpackNormal(nrm);
		}
		ENDCG
	} 
	FallBack "Specular"
}
