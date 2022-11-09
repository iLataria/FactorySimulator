using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ResourcesDatabase", menuName = "Resources Database")]
public class ResourceDB : ScriptableObject
{
    public List<ResourceItem> resources;
    private Dictionary<string, ResourceItem> resourcesTable;

    public void Init()
    {
        resourcesTable = new Dictionary<string, ResourceItem>();
        foreach (var resource in resources)
        {
            string id = resource.Id;
            resourcesTable.Add(id, resource);
        }
    }

    public ResourceItem GetItem(string id)
    {
        Debug.Log($"{ resourcesTable.TryGetValue(id, out ResourceItem type)}");
        return type;
    }
}