Shader "Custom/OutlineShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0

        _OutlineWidth ("Outline Width", Float) = 1
        _OutlineColor ("Outline Color", Color) = (1,1,1,1)
        _OutlineEnabled ("Outline Enabled", Float) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Pass 
        {
            Cull Front
            ZWrite On
            ZTest Less

            CGPROGRAM
            fixed4 _OutlineColor;
            fixed _OutlineWidth;
            float _OutlineEnabled;

            #pragma vertex vert
            #pragma fragment frag

            struct appdata 
            {
                float3 normal : NORMAL;
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
            };

            v2f vert(appdata v)
            {
                if (_OutlineEnabled > 0.5)
                {
                    v.vertex.xyz += normalize(v.normal) * _OutlineWidth;
                }

                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                return o;
            };

            float4 frag (v2f i) : SV_Target
            {
                if (_OutlineEnabled < 0.5)
                {
                    discard;
                }

                return _OutlineColor;
            };
            ENDCG
        }

        Cull Back
        ZWrite On
        ZTest LEqual

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        UNITY_INSTANCING_BUFFER_START(Props)
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
