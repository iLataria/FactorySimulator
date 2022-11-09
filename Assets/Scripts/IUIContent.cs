
using System.Collections.Generic;

namespace FactorySimulator
{
    public interface IUIContent
    {
        public string GetName();
        public string GetData();
        public void GetContent(ref List<Building.Resource> content);
    }
}
