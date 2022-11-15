using UnityEngine;
using System.Collections.Generic;
using System;

namespace FactorySimulator
{
    public class Building : MonoBehaviour, IUIContent
    {
        [SerializeField] private int initialInventorySize;
        
        [Serializable]
        public class Resource
        {
            public string Id;
            public int Amount;
        }

        private int maxInventorySpace;
        public List<Resource> inventory;
        private int currentInventorySpace;

        virtual protected void Awake()
        {
            inventory = new List<Resource>();
        }

        public int AddResource(string resourceId, int amount)
        {
            int leftOverAmount;

            maxInventorySpace = initialInventorySize == -1 ? Int32.MaxValue : initialInventorySize;

            if (currentInventorySpace == maxInventorySpace)
            {
                leftOverAmount = amount;
                return leftOverAmount;
            }

            int found = inventory.FindIndex(resource => resource.Id == resourceId);
            int addedAmount = Mathf.Min(amount, maxInventorySpace - currentInventorySpace);

            if (found == -1)
            {
                Resource resource = new Resource()
                {
                    Id = resourceId,
                    Amount = amount
                };

                inventory.Add(resource);
            }
            else
            {
                inventory[found].Amount += addedAmount;
            }

            currentInventorySpace += addedAmount;
            leftOverAmount = amount - addedAmount;
            return leftOverAmount;
        }

        public int RemoveResource(string resourceId, int amount)
        {
            int ableToRemoveAmount = 0;

            int found = inventory.FindIndex(resource => resource.Id == resourceId);

            if (found != -1)
            {
                Resource resource = inventory[found];
                ableToRemoveAmount = Mathf.Min(amount, resource.Amount);
                resource.Amount -= ableToRemoveAmount;

                if (resource.Amount <= 0)
                {
                    inventory.RemoveAt(found);
                }
            }

            currentInventorySpace -= ableToRemoveAmount;

            return ableToRemoveAmount;
        }

        public void GetContent(ref List<Resource> inventory)
        {
            inventory.AddRange(this.inventory);
        }

        public string GetName()
        {
            return gameObject.name;
        }

        public string GetData()
        {
            return "building";
        }
    }
}

