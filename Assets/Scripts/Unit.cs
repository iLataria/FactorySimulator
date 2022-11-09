using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace FactorySimulator
{
    public class Unit : MonoBehaviour, IUIContent
    {
        [SerializeField] private float speed;
        [SerializeField] private GameObject markerPrefab;
        [SerializeField] private GameObject markerWrapper;

        private Building.Resource currentResource ;
        private Building targetToReturn;
        public int maxCapacity = 5;
        private GameObject markerGO;
        private NavMeshAgent agent;
        private Building target;

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            agent.speed = speed;
            currentResource = new Building.Resource();
        }

        private void Update()
        {
            if (!target) return;
            float distance = Vector3.Distance(transform.position, target.transform.position);
            if (distance < 1f)
            {
                Debug.Log($"Take resource from building");
                agent.isStopped = true;

                if (target == Base.Instance)
                {
                    if (currentResource.Amount > 0)
                    {
                        Debug.Log($"Unload resource at base");
                        target.AddResource(currentResource.Id, currentResource.Amount);
                        currentResource.Id = "";
                        currentResource.Amount = 0;
                        GoTo(targetToReturn);
                    }
                }
                else
                {
                    if (target.inventory.Count <= 0)
                        return;

                    string resourceId = target.inventory[0].Id;
                    int amount = target.RemoveResource(resourceId, maxCapacity);
                    currentResource.Id = resourceId;
                    currentResource.Amount = amount;
                    targetToReturn = target;
                    GoTo(Base.Instance);
                }
            
            }
        }

        public void GoTo(Vector3 position)
        {
            this.target = null;
            Debug.Log($"Go to {position}");
            agent.isStopped = false;
            agent.SetDestination(position);
        }

        public void GoTo(Building building)
        {
            target = building;
            if (target == null) return;

            agent.SetDestination(target.transform.position);
            agent.isStopped = false;
        }

        public void SetMarkerActive(bool isActive)
        {
            if (isActive && markerGO == null)
            {
                markerGO = Instantiate(markerPrefab, markerWrapper.transform.position, Quaternion.identity);
                markerGO.transform.SetParent(markerWrapper.transform);
            }
            else if (!isActive && markerGO)
            {
                Destroy(markerGO);
            }
        }

        public string GetName()
        {
            return gameObject.name;
        }

        public string GetData()
        {
            return "Just some unit";
        }

        public void GetContent(ref List<Building.Resource> content)
        {
            
        }
    }
}


