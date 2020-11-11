Shader "Custom/UnlitVertexColor" {
    Properties{
        [IntRange] _Silhouette("Draw Silhouette", Range(0,1)) = 0
    }

    SubShader{
        Tags {
            "RenderType" = "Opaque"
            "Queue" = "Geometry"
        }

        Stencil {
            Ref [_Silhouette]
            Pass Replace
        }

        Cull Off

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
                float4 color : COLOR0;
            };

            struct v2f {
                float4 vertex : SV_POSITION;
                float4 color : COLOR0;
            };

            v2f vert(appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.color = v.color;
                return o;
            }

            fixed4 frag(v2f i) : COLOR {
                return i.color;
            }
            ENDCG
        }
    }
}
