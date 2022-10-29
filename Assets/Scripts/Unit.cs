using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    [SerializeField] private float speed;

    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        
    }

    public void GoTo(Vector3 target)
    {
        Debug.Log($"Go to {target}");
        agent.SetDestination(target);
    }
}
