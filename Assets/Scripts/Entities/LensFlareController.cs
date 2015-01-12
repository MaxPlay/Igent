using UnityEngine;
using System.Collections;

[RequireComponent (typeof (LensFlare))]
public class LensFlareController : MonoBehaviour {

    public bool Infinite;
    public float Distance;

    private float Intensity;

    void Start()
    {
        Intensity = gameObject.GetComponent<LensFlare>().brightness;
    }

	void Update () {

        float activeDistance = Vector3.Distance(Camera.main.transform.position,transform.position);
        if (!Infinite)
                if (activeDistance > Distance)
                    transform.GetComponent<LensFlare>().brightness = 0f;
                else
                    transform.GetComponent<LensFlare>().brightness = Mathf.Lerp(0f, Intensity, Mathf.Abs(activeDistance / Distance - 1));

	}
}
