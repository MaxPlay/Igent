/** Code is poetry **/
using UnityEngine;
using System.Collections;

public class Tesla : MonoBehaviour
{
    public bool GenerateLightning = false;
    public GameObject LightningPrefab;
    public float Height;
    public float Radius;
    public float BoltsPerFrame = 1f;

    private float BoltsCount;

    void Update()
    {
        if (GenerateLightning)
            BoltsCount += BoltsPerFrame;

        Vector3 newPos = Random.onUnitSphere*Radius;
        newPos.y = 0;
        while (BoltsCount>=1)
        {
            BoltsCount--;
            ((GameObject)Instantiate(LightningPrefab, newPos + new Vector3(0, Height, 0) + gameObject.transform.position, new Quaternion())).transform.parent = transform;
        }
    }
}
