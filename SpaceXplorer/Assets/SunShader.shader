﻿Shader "Custom/SunShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Color Tint", Color) = (1, 1, 0, 1)
        _GlowIntensity ("Glow Intensity", Range(0, 5)) = 1
    }

    SubShader
    {
        Tags { "Queue"="Geometry" "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            ZWrite On        // Asigură scrierea în buffer-ul de adâncime
            ZTest LEqual     // Obiectele sunt desenate corect
            Blend Off        // Oprește transparența
            Cull Back        // Ascunde fața din spate

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _Color;
            float _GlowIntensity;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv) * _Color;
                col.rgb *= _GlowIntensity;
                return col;
            }
            ENDCG
        }
    }

    FallBack "Diffuse"
}
