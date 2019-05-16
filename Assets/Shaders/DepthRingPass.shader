// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/DepthRingPass" {

Properties {
   _MainTex ("", 2D) = "white" {} 
   _AnotherTex ( "Texture to change", 2D) = "white"{}
   _RingWidth("ring width", Float) = 0.01
   _RingPassTimeLength("ring pass time", Float) = 10.0
   _RingEmissionIntensity("Emission intensity", Range(0,20)) = 0.5
   _RingColor("Ring Color", Color) = (1,1,1,1)
}

SubShader {
Tags { "RenderType"="Opaque" }
Pass{
CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"

sampler2D _CameraDepthTexture;
float _StartingTime;
float _RingEmissionIntensity;
float4 _RingColor;
float4 _RingEmissionColor;
uniform float _RingPassTimeLength; //the length of time it takes the ring to traverse all depth values
uniform float _RingWidth; //width of the ring
float _RunRingPass = 0; //use this as a boolean value, to trigger the ring pass. It is called from the script attached to the camera.

struct v2f {
   float4 pos : SV_POSITION;
   float4 scrPos:TEXCOORD1;
};

//Our Vertex Shader
v2f vert (appdata_base v){
   v2f o;
   o.pos = UnityObjectToClipPos (v.vertex);
   o.scrPos=ComputeScreenPos(o.pos);
   return o;
}

sampler2D _MainTex; //Reference in Pass is necessary to let us use this variable in shaders
sampler2D _AnotherTex;

//Our Fragment Shader
half4 frag (v2f i) : COLOR{

   float depthValue = Linear01Depth (tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.scrPos)).r);

   fixed4 orgColor = tex2Dproj(_MainTex, i.scrPos);
   fixed4 nextView = tex2Dproj(_AnotherTex, i.scrPos);
   float4 newColor;
   float4 lightRing;

   float t = 1 - ((_Time.y - _StartingTime)/_RingPassTimeLength );

   if (_RunRingPass == 1){
      //this part draws the light ring
      if (depthValue < t && depthValue > t - _RingWidth){
         lightRing.r = _RingColor.r;
         lightRing.g = _RingColor.g;
         lightRing.b = _RingColor.b;
         lightRing.a = _RingColor.a;
		 
         return lightRing * _RingEmissionIntensity;
      } else {
          if (depthValue < t) {
             //this part the ring hasn't pass through yet
             return orgColor;
          } else {
             //this part the ring has passed through
			 newColor.r = nextView.r;
             newColor.g = nextView.g;
             newColor.b = nextView.b;
             newColor.a = 1;
             return newColor;
         }
      }
    } else {
        return orgColor;
    }
}
ENDCG
}
}
FallBack "Diffuse"
}
