using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    public ParticleSystem[] Effects;
    public float AutoReloadTime;
    private float TimePassed;

    void Update()
    {
        if (Input.GetAxis("Fire1") != 0)
            Shoot();
    }

    public void Shoot()
    {
        if (AutoReloadTime < TimePassed)
        {
            for(int i = 0; i < Effects.Length;i++)
                Effects[i].Play();
            TimePassed = 0;
        }
        else
            TimePassed += Time.deltaTime;
    }
}
