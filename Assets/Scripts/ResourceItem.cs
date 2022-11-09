using UnityEngine;

[CreateAssetMenu(fileName = "ResourceItem", menuName = "ResourceItem")]
public class ResourceItem : ScriptableObject
{
    public string Id;
    public Sprite Icon;
    public string Name;
}