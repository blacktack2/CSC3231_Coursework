Shader "Unlit/Planet Ring"
{
    Properties
    {
		_NoiseMap ( "Noise Map", 2D ) = "white" {}
        _NoiseAmplitude ("Noise Map Amplitude", Float) = 0.4
        _Transparency ("Transparency", Range(0.0, 1.0)) = 0.8
        _Cutoff ("Cutoff", Range(0.0, 1.0)) = 0.5
        _Gradient ("Gradient", Float) = 1.0
        
        _FogColor ("Fog Color", Color) = (0, 0, 0, 0)

        _Ring0Width ("Ring 0 Width", Float) = 0.0
        _Ring0Color ("Ring 0 Color", Color) = (0, 0, 0, 1)
        _Ring1Width ("Ring 1 Width", Float) = 0.0
        _Ring1Color ("Ring 1 Color", Color) = (0, 0, 0, 1)
        _Ring2Width ("Ring 2 Width", Float) = 0.0
        _Ring2Color ("Ring 2 Color", Color) = (0, 0, 0, 1)
        _Ring3Width ("Ring 3 Width", Float) = 0.0
        _Ring3Color ("Ring 3 Color", Color) = (0, 0, 0, 1)
        _Ring4Width ("Ring 4 Width", Float) = 0.0
        _Ring4Color ("Ring 4 Color", Color) = (0, 0, 0, 1)
        _Ring5Width ("Ring 5 Width", Float) = 0.0
        _Ring5Color ("Ring 5 Color", Color) = (0, 0, 0, 1)
        _Ring6Width ("Ring 5 Width", Float) = 0.0
        _Ring6Color ("Ring 5 Color", Color) = (0, 0, 0, 1)
        _Ring7Width ("Ring 5 Width", Float) = 0.0
        _Ring7Color ("Ring 5 Color", Color) = (0, 0, 0, 1)
        _Ring8Width ("Ring 5 Width", Float) = 0.0
        _Ring8Color ("Ring 5 Color", Color) = (0, 0, 0, 1)
        _Ring9Width ("Ring 5 Width", Float) = 0.0
        _Ring9Color ("Ring 5 Color", Color) = (0, 0, 0, 1)
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" } 
        LOD 100

        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 norm			: TEXCOORD1;
                float4 lightDir		: TEXCOORD2;
                float3 eyeDir		: TEXCOORD3;
            };

            float4 _LightColor0;

            sampler2D _NoiseMap;
            float _NoiseAmplitude;
            float _Transparency;
            float _Cutoff;
            float _Gradient;

            float4 _FogColor;
            
            float _Ring0Width;
            float4 _Ring0Color;
            float _Ring1Width;
            float4 _Ring1Color;
            float _Ring2Width;
            float4 _Ring2Color;
            float _Ring3Width;
            float4 _Ring3Color;
            float _Ring4Width;
            float4 _Ring4Color;
            float _Ring5Width;
            float4 _Ring5Color;
            float _Ring6Width;
            float4 _Ring6Color;
            float _Ring7Width;
            float4 _Ring7Color;
            float _Ring8Width;
            float4 _Ring8Color;
            float _Ring9Width;
            float4 _Ring9Color;

            v2f vert (appdata_tan v)
            {
                float4 lightDir		= normalize( _WorldSpaceLightPos0 );

                TANGENT_SPACE_ROTATION;

                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.texcoord.xy;
                o.norm = normalize(mul(unity_ObjectToWorld, float4(v.normal, 1))).xyz;
                o.lightDir = normalize(float4(mul(rotation, mul(unity_WorldToObject, lightDir).xyz), 0));
                o.eyeDir = normalize(mul(rotation, ObjSpaceViewDir(v.vertex)));
                return o;
            }

            half4 frag (v2f i) : Color
            {
                float distance = sqrt(pow(i.uv.x-0.5, 2) + pow(i.uv.y-0.5, 2)) * 2;
                half4 col = 0;
                if (distance >= _Cutoff)
                {
                    float widths[] =  {          0, _Ring0Width, _Ring1Width, _Ring2Width, _Ring3Width, _Ring4Width, _Ring5Width, _Ring6Width, _Ring7Width, _Ring8Width, _Ring9Width};
                    float4 colors[] = {_Ring0Color, _Ring0Color, _Ring1Color, _Ring2Color, _Ring3Color, _Ring4Color, _Ring5Color, _Ring6Color, _Ring7Color, _Ring8Color, _Ring9Color};
                    float ringPos = (distance - _Cutoff) / (1 - _Cutoff); // Position on the entire ring (0 - on minor radius, 1 on major radius)
                    for (int r = 1; r < 10; r++)
                    {
                        ringPos -= widths[r];
                        if (ringPos < 0)
                        {
                            ringPos += widths[r];
                            float t = -((ringPos) * 2 / widths[r] - 1.0); // Position on the sub-ring (-1 to 1)
                            t = (1.0 / (1.0 + pow(2, _Gradient * t))); // Apply sigmoid to get smoother (0 to 1)
                            // float t = ((ringPos) / widths[r]);
                            col = colors[r-1] + t * (colors[r] - colors[r-1]);
                            break;
                        }
                    }
                    col.a *= _Transparency;
                    col.a = clamp((col.a + (tex2D(_NoiseMap, i.uv) * _NoiseAmplitude - _NoiseAmplitude / 2)), 0, 1);
                }
                col.rgb = lerp(col.rgb, _FogColor.rgb, _FogColor.a);
                return col;
            }
            ENDCG
        }
    }
}
