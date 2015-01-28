/** Code is poetry **/
using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour {

    void Update()
    {
        Vector3 CamRot = Camera.main.transform.rotation.eulerAngles;
        Vector3 ThisRot = transform.rotation.eulerAngles;
        Quaternion q = new Quaternion();
        q.eulerAngles = new Vector3(-90, CamRot.y, 90);

        transform.rotation = q;
	}
}
