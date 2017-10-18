// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/FogOfWar2" {
Properties {
    _Color ("Main Color", Color) = (1,1,1,1)
	_ColorFog ("Fog Color", Color) = (1,1,1,1)
    _MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
    _FogRadius ("FogRadius", Float) = 1.0
	_ExpFactor ("ExpFactor", Float) = 0.05
    _FogMaxRadius("FogMaxRadius", Float) = 0.5
    _Player1_Pos ("_Player1_Pos", Vector) = (0,0,0,1)
}

SubShader {

	Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}

    LOD 200
    Blend SrcAlpha OneMinusSrcAlpha
    Cull Off

	
    CGPROGRAM
    #pragma surface surf Lambert vertex:vert

    sampler2D _MainTex;
    fixed4     _Color;
	fixed4     _ColorFog;
    float     _FogRadius;
	float     _ExpFactor;
    float     _FogMaxRadius;
    float4     _Player1_Pos;


    struct Input {
        float2 uv_MainTex;
        float2 location;
    };

    fixed4 powerForPos(float4 pos, float2 nearVertex, float4 bColor);

    void vert(inout appdata_full vertexData, out Input outData) {
        float4 pos = UnityObjectToClipPos(vertexData.vertex);
        float4 posWorld = mul(unity_ObjectToWorld, vertexData.vertex);
        outData.uv_MainTex = vertexData.texcoord;
        outData.location = posWorld.xz;
    }

    void surf (Input IN, inout SurfaceOutput o) {
        fixed4 baseColor = tex2D(_MainTex, IN.uv_MainTex)*_Color ;
		baseColor= powerForPos(_Player1_Pos, IN.location,baseColor);

       // float alpha = (1.0 - (baseColor.a + powerForPos(_Player1_Pos, IN.location)));

        o.Albedo = baseColor.rgb;
        o.Alpha = baseColor.a; 
    }

    //return 0 if (pos - nearVertex) > _FogRadius
    fixed4 powerForPos(float4 pos, float2 nearVertex,float4 bColor) {
		/*float atten = clamp(length(pos.xz - nearVertex.xy), _FogRadius, _FogMaxRadius);
		float k =(atten - _FogRadius)/(_FogMaxRadius-_FogRadius+0.00001f) ;
		fixed4 white =  bColor*(1-k)+ (k)*_ColorFog;
        return white;*/

		float distance = clamp(length(pos.xz - nearVertex.xy)-_FogRadius,0.0, abs( length(pos.xz - nearVertex.xy)-_FogRadius));
		float k =1.0f/(pow(2.7f, distance*_ExpFactor)) ;
		fixed4 white =  bColor*(k)+ (1-k)*_ColorFog;
        return white;
	}

    ENDCG
}

Fallback "Transparent/VertexLit"
}