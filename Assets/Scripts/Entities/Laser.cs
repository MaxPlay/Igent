/** Code is poetry **/
using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

    public bool Active;
    public Transform emitPos;
    public float beamlength;
    private LineRenderer LineRender;
    public GameObject LaserSparks;

    void Start()
    {
        LineRender = transform.GetChild(0).GetComponent<LineRenderer>();
    }

	void Update () {
        transform.GetChild(0).gameObject.SetActive(Active);
        emitPos = transform.GetChild(0);

        if (Active)
        {
            RaycastHit hit;
            if (Physics.Raycast(emitPos.position + emitPos.right * 0.18f, emitPos.right, out hit, Mathf.Infinity))
            {
                beamlength = hit.distance;
                Vector3 Sparkpos = emitPos.position + emitPos.right * (beamlength+0.18f);
                Quaternion Sparkrot = new Quaternion();
                Sparkrot.eulerAngles = -emitPos.right;

                if (Vector3.Distance(Sparkpos, Camera.main.transform.position) < 50)
                    ((GameObject)Instantiate(LaserSparks, Sparkpos, Sparkrot)).transform.parent = transform;
            }
            else
            {
                beamlength = 1000;
            }

            LineRender.SetPosition(1,new Vector3(beamlength+0.18f,0,0));

        }
	}
}
