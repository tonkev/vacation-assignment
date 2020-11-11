Shader "Custom/Silhouette" {
    Properties{
        _SilhouetteColor("Silhouette Color", Color) = (0, 0, 0, 1)
    }
        SubShader{
            Tags {
                "RenderType" = "Opaque"
                "Queue" = "Geometry+1"
            }

            Stencil {
                Ref 1
                Comp NotEqual
            }

            ZTest Always
            ZWrite Off
            Cull Off

            Pass {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag

                #include "UnityCG.cginc"

                uniform float4 _SilhouetteColor;

                struct appdata {
                    float4 vertex : POSITION;
                };

                struct v2f {
                    float4 vertex : SV_POSITION;
                };

                v2f vert(appdata v) {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target {
                    return _SilhouetteColor;
                }
                ENDCG
            }
    }
}
