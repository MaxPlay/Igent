using UnityEngine;
using System.Collections.Generic;

public class Fire : MonoBehaviour {

    public GameObject FireParticleSystem;
    public Vector2 Area;
    public float Height;

    private float defaultLifetime;
    private float defaultSpeed;
    private float defaultSmokeLifetime;
    private float defaultSmokeSpeed;

    void Start()
    {
        defaultSpeed = FireParticleSystem.particleSystem.startSpeed;
        defaultLifetime = FireParticleSystem.particleSystem.startLifetime;
        defaultSmokeSpeed = FireParticleSystem.transform.GetChild(0).particleSystem.startSpeed;
        defaultSmokeLifetime = FireParticleSystem.transform.GetChild(0).particleSystem.startLifetime;


        for (int x = 0; x < Area.x; x++)
            for (int y = 0; y < Area.y; y++)
            {
                GameObject g = ((GameObject)Instantiate(FireParticleSystem, new Vector3(x, y, 0) + transform.position, new Quaternion()));
                g.GetComponent<Transform>().parent = transform;
                g.particleSystem.startSpeed = defaultSpeed * Height;
                g.particleSystem.startLifetime = defaultLifetime * Height;
                g.transform.GetChild(0).particleSystem.startSpeed = defaultSmokeSpeed * Height;
                g.transform.GetChild(0).particleSystem.startLifetime = defaultSmokeLifetime * Height;
            }

        Quaternion q = new Quaternion();
        q.eulerAngles = new Vector3(-90,0,0);
        transform.rotation = q;
    }

	void Update () 
    {

	}
}
