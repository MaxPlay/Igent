using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour {

    public Material[] LitMaterial;
    public Material[] UnlitMaterial;
    public Light[] Lights;

    public bool lit;

	void Update() {
        if (lit)
            gameObject.renderer.materials = LitMaterial;
        else
            gameObject.renderer.materials = UnlitMaterial;
	}
}
