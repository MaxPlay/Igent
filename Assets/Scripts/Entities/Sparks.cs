/** Code is poetry **/
using UnityEngine;
using System.Collections;

public class Sparks : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        ParticleSystem particleSystem = gameObject.particleSystem;
        if (particleSystem.time > 0.1f && particleSystem.particleCount == 0)
            Destroy(gameObject);
	}
}
