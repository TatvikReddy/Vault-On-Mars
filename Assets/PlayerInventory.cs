using System;
using UnityEngine;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    Dictionary<ResourceType, int> resources = new Dictionary<ResourceType, int>();

    private void Start()
    {
        resources[ResourceType.Metal] = 0;
        resources[ResourceType.Water] = 0;
        resources[ResourceType.Energy] = 0;
    }

    public int getResource(ResourceType resource)
    {
        Debug.Log(resource + " : " + resources[resource]);
        return resources[resource];
    }

    public void updateResource(ResourceType resource, int amount)
    {
        resources[resource] += amount;
        Debug.Log(resource + " : " + resources[resource]);
    }
}
