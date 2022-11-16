using System;
using UnityEngine;

namespace FactorySimulator
{
    public class ResourcePile : Building
    {
        [SerializeField] private ResourceItem resourceItem;
        [SerializeField] private float productionSpeed;
        private float resourceAddTimer;

        private void Update()
        {
            if (resourceAddTimer > 1.0f)
            {
                int amountToAdd = (int)Math.Truncate(resourceAddTimer);
                int leftOver = AddResource(resourceItem.Id, amountToAdd);

                resourceAddTimer = resourceAddTimer - amountToAdd + leftOver;
            }
            else
            {
                resourceAddTimer += productionSpeed * Time.deltaTime;
            }
        }
    }
}

