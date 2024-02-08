Shader "Custom/GradientSkybox"
{
    Properties
    {
        _TopColor ("Top Color", Color) = (0.5, 0.7, 1.0, 1.0)
        _BottomColor ("Bottom Color", Color) = (0.2, 0.3, 0.5, 1.0)
        _Exponent ("Exponent", Float) = 1.0
    }
 
    SubShader
    {
        Tags { "Queue" = "Background" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float3 worldPos : TEXCOORD0;
            };

            float4 _TopColor;
            float4 _BottomColor;
            float _Exponent;

            v2f vert(appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float3 viewDir = normalize(i.worldPos - _WorldSpaceCameraPos);
                float blendFactor = pow(saturate(dot(viewDir, float3(0, 1, 0))), _Exponent);

                fixed4 topColor = _TopColor;
                fixed4 bottomColor = _BottomColor;

                fixed4 finalColor = lerp(bottomColor, topColor, blendFactor);

                return finalColor;
            }
            ENDCG
        }
    }
    Fallback "Skybox/Cubemap"
}
