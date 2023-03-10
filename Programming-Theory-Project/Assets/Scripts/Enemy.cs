using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    float range; //radius of sphere

    [SerializeField]
    Vector3 centrePoint; //centre of the area the agent wants to move around in

    private FieldOfView fov;
    private NavMeshAgent agent;
    protected AudioSource enemyAudio;

    private void Awake()
    {
        fov = GetComponent<FieldOfView>();
        agent = GetComponent<NavMeshAgent>();
        enemyAudio = GetComponent<AudioSource>();
    }

    void Start()
    {
        centrePoint = transform.position;
    }

    void Update()
    {
        if (fov.canSeePalyer == true)
            Aggro();
        else if (fov.canSeePalyer == false)
            Patrol();
    }

    // ABSTRACTION
    public void Patrol()
    {
        if (agent.remainingDistance <= agent.stoppingDistance) //done with path
        {
            Vector3 point;
            if (RandomPoint(centrePoint, range, out point)) //pass in our centre point and radius of area
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
                agent.SetDestination(point);
            }
        }
    }

    // ABSTRACTION
    public virtual void Aggro()
    {
        agent.SetDestination(fov.playerRef.transform.position);
    }

    // ABSTRACTION
    public void Yell(AudioClip sound)
    {
        if (!enemyAudio.isPlaying)
            enemyAudio.PlayOneShot(sound, 0.3f);
    }

    // ABSTRACTION
    private bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range; //random point in a sphere 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) //documentation: https://docs.unity3d.com/ScriptReference/AI.NavMesh.SamplePosition.html
        {
            //the 1.0f is the max distance from the random point to a point on the navmesh, might want to increase if range is big
            //or add a for loop like in the documentation
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }
}
