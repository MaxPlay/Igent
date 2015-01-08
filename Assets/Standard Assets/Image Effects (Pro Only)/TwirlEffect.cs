using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Displacement/Twirl")]
public class TwirlEffect : ImageEffectBase {
	public Vector2  radius = new Vector2(0.3F,0.3F);
	public float    angle = 50;
	public Vector2  center = new Vector2 (0.5F, 0.5F);
    public Vector2 AnimBorders = new Vector2(-30f,30f);
    private bool pingpong = false;

	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		ImageEffects.RenderDistortion (material, source, destination, angle, center, radius);
	}

    void Update()
    {
        if (pingpong)
            angle += 1;
        else
            angle -= 1;

        if (angle > AnimBorders.y)
        {
            pingpong = false;
            angle = AnimBorders.y;
        }
        if (angle < AnimBorders.x)
        {
            pingpong = true;
            angle = AnimBorders.x;
        }
    }
}
