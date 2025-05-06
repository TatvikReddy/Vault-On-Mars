using System;
using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    Dictionary<ResourceType, int> resources = new Dictionary<ResourceType, int>();

    public TMP_Text metalText;
    public TMP_Text waterText;
    public TMP_Text energyText;
    
    private void Start()
    {
        resources[ResourceType.Metal] = 0;
        resources[ResourceType.Water] = 0;
        resources[ResourceType.Energy] = 0;
    }

    private void Update()
    {
        metalText.text = printResource(ResourceType.Metal);
        waterText.text = printResource(ResourceType.Water);
        energyText.text = printResource(ResourceType.Energy);
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

    public string printResource(ResourceType resource)
    {
        string resString = "";
        if (resource == ResourceType.Metal)
        {
            resString += "Metal: ";
        }
        else if (resource == ResourceType.Water)
        {
            resString += "Water: ";
        }
        else if (resource == ResourceType.Energy)
        {
            resString += "Energy: ";
        }
        
        return resString + resources[resource];
    }
}
