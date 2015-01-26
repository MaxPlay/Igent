/** Code is poetry **/
using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(Light))]
public class LightningCreator : MonoBehaviour
{

    public int Jumps = 5;
    public float JumpRadius = 0.5f;
    public float LifetimeInSeconds = 0.1f;
    public Color32 StartColor = new Color32(255, 255, 255, 200);
    public Color32 EndColor = new Color32(255, 255, 255, 100);
    public float StartWidth = 0.01f;
    public float EndWidth = 0.001f;

    private float passedLifetime;
    private LineRenderer LR;
    private Light L;

    void Start()
    {
        LR = gameObject.GetComponent<LineRenderer>();
        L = gameObject.GetComponent<Light>();
        LR.SetColors(StartColor, EndColor);
        LR.SetWidth(StartWidth, EndWidth);
        LR.castShadows = false;
        LR.receiveShadows = false;
        LR.useWorldSpace = false;
        LR.SetVertexCount(Jumps);
        L.type = LightType.Point;
        L.range = 0.5f;
        L.color = StartColor;

        CreateNew();
    }

    void Update()
    {
        if (LifetimeInSeconds > passedLifetime)
            passedLifetime += Time.deltaTime;
        else
            Destroy(gameObject);
    }

    private void CreateNew()
    {
        Vector3 lastV3 = new Vector3();

        for (int i = 0; i < 5; i++)
        {
            LR.SetPosition(i,lastV3);
            lastV3 += Random.insideUnitSphere*JumpRadius;
        }
    }
}
