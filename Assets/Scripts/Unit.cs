using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject markerPrefab;
    [SerializeField] private GameObject markerWrapper;
    
    private GameObject markerGO;
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

    public void SetMarkerActive(bool isActive)
    {
        if (isActive && markerGO == null)
        {
            markerGO = Instantiate(markerPrefab, markerWrapper.transform.position, Quaternion.identity);
            markerGO.transform.SetParent(markerWrapper.transform);
        }
        else if(!isActive && markerGO)
        {
            Destroy(markerGO);
        }
    }
}
