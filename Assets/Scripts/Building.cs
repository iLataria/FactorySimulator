using UnityEngine;
using System.Collections.Generic;

namespace FactorySimulator
{
    public class Building : MonoBehaviour
    {
        public class Resource
        {
            public string Id;
            public int Amount;
        }

        private int maxInventorySpace;
        private List<Resource> inventory;
        private int currentInventorySpace;

        private void Awake()
        {
            inventory = new List<Resource>();
        }

        //Returns 0 if everything fit in the inventory, otherwise return the left over amount
        public int AddItem(string resourceId, int amount)
        {
            int leftOverAmount = 0;
            if (currentInventorySpace == maxInventorySpace)
            {
                return leftOverAmount;
            }

            int found = inventory.FindIndex(resource => resource.Id == resourceId);
            int addedAmount = Mathf.Min(amount, maxInventorySpace - currentInventorySpace);

            if (found == 0)
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
    }
}

