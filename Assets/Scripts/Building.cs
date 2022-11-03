using UnityEngine;
using System.Collections.Generic;
using System;

namespace FactorySimulator
{
    public class Building : MonoBehaviour
    {
        [SerializeField] private int initialInventorySpace;
        [SerializeField] private float productionSpeed;
        [SerializeField] private string resourceId;

        private float resourceAddTimer;

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

        private void Update()
        {
            if (resourceAddTimer > 1.0f)
            {
                int amountToAdd = (int)(Math.Truncate(resourceAddTimer));
                int leftOver = AddResource(resourceId, amountToAdd);
                
                //Debug.Log($"leftOver {amountToAdd} {leftOver}");
                
                resourceAddTimer = resourceAddTimer - amountToAdd + leftOver;
            }
            else
            {
                resourceAddTimer += productionSpeed * Time.deltaTime;
            }
        }

        //Returns 0 if everything fit in the inventory, otherwise return the left over amount
        public int AddResource(string resourceId, int amount)
        {
            int leftOverAmount;

            maxInventorySpace = initialInventorySpace == -1 ? Int32.MaxValue : initialInventorySpace;

            if (currentInventorySpace == maxInventorySpace)
            {
                return amount;
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

        //Returns how much was actually removed. 0 if cant get any.
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
    }
}

