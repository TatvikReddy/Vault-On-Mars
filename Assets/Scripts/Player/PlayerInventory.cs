using System;
using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    Dictionary<ResourceType, int> resources = new Dictionary<ResourceType, int>();

    public TMP_Text moneyText;
    public TMP_Text metalText;
    
    private void Start()
    {
        resources[ResourceType.Metal] = 0;
        resources[ResourceType.Money] = 0;
    }
    
    private void Update()
    {
        metalText.text = printResource(ResourceType.Metal);
        moneyText.text = printResource(ResourceType.Money);
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
        return resources[resource].ToString();
    }
    
}
