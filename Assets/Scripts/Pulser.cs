using UnityEngine;
using System.Collections;

public class Pulser : MonoBehaviour {


	// Update is called once per frame
	void Update () {
        Light l = gameObject.GetComponent<Light>();
        l.intensity -= 2;
        if (l.intensity <= 0)
            l.intensity = 0;
	}
}
