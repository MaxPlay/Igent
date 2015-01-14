using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    public ParticleSystem[] Effects;
    public float AutoReloadTime;
    public Light[] LightEffects;
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

            for (int i = 0; i < LightEffects.Length; i++)
                LightEffects[i].intensity = Random.value + 3;
        }
        else
            TimePassed += Time.deltaTime;
    }
}
