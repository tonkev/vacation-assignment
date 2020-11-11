﻿Shader "Unlit/UnlitMonoColor" {
    Properties{
        _Color("Main Color", Color) = (1, 1, 1, 1)
    }

    SubShader{
        Tags {
            "RenderType" = "Opaque"
            "Queue" = "Geometry"
        }

        Cull Off

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
            };

            struct v2f {
                float4 vertex : SV_POSITION;
            };

            fixed4 _Color;

            v2f vert(appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 frag(v2f i) : COLOR {
                return _Color;
            }
            ENDCG
        }
    }
}
