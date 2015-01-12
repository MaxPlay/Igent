using UnityEngine;
using System.Collections;

public class MoveCameraToTarget : MonoBehaviour
{

    public int Target;
    public Transform[] ListofTargets;
    public float TimeForInterpolation;

    private float passedTime;
    private int formerTarget;

    // Update is called once per frame
    void Update()
    {
        if (Target < ListofTargets.Length)
            if (Vector3.Distance(transform.position, ListofTargets[Target].position) > 0f)
            {
                transform.position = Vector3.Lerp(ListofTargets[formerTarget].position, ListofTargets[Target].position, passedTime / TimeForInterpolation);
                transform.rotation = Quaternion.Lerp(ListofTargets[formerTarget].rotation, ListofTargets[Target].rotation, passedTime / TimeForInterpolation);
            }
            else
                formerTarget = Target;
        passedTime += Time.deltaTime;
    }

    public void SetTarget(int iTarget)
    {
        passedTime = 0;
        Target = iTarget;
    }
}
