using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FactorySimulator
{
    public class ResourcePile : Building
    {
        [SerializeField] private string resourceId;
        [SerializeField] private float productionSpeed;
        private float resourceAddTimer;

        private void Update()
        {
            if (resourceAddTimer > 1.0f)
            {
                int amountToAdd = (int)Math.Truncate(resourceAddTimer);
                int leftOver = AddResource(resourceId, amountToAdd);

                resourceAddTimer = resourceAddTimer - amountToAdd + leftOver;
            }
            else
            {
                resourceAddTimer += productionSpeed * Time.deltaTime;
            }
        }
    }
}

