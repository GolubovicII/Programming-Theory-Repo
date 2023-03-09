using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    // enemy watch distance
    public float radius;

    // enemy fov
    [Range(0, 360)]
    public float angle;

    // player reference
    public GameObject playerRef;

    [SerializeField]
    LayerMask targetMask;

    [SerializeField]
    LayerMask obstructionMask;

    // ENCAPSULATION
    public bool canSeePalyer { get; private set; }

    private void Start()
    {
        playerRef = GameObject.Find("Player");
        StartCoroutine(FOVRoutine());
    }

    private IEnumerator FOVRoutine()
    {
        float delay = 0.2f;

        while (true)
        {
            yield return new WaitForSeconds(delay);
            FieldOfViewCheck();
        }
    }

    // ABSTRACTION
    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                    canSeePalyer = true;
                else
                    canSeePalyer = false;
            }
            else
                canSeePalyer = false;
        }
        else if (canSeePalyer)
            canSeePalyer = false;
    }
}
