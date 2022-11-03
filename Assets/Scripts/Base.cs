using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FactorySimulator
{
    public class Base : Building
    {
        public static Base Instance;
        protected override void Awake()
        {
            base.Awake();
            Instance = this;
        }
    }
}
