using System;
using UnityEngine;
using System.Collections.Generic;

public class TechTree : MonoBehaviour
{

    public static TechTree instance;

    public int[] TechLevels;
    public int[] TechCaps;
    public string[] TechNames;
    public string[] TechDescriptions;

    public List<TechNode> TechList;
    public GameObject TechHolder;
    
    public List<GameObject> ConnectorList;
    public GameObject ConnectorHolder;

    public int TechPoint;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    private void Start()
    {
        Debug.Log("Starting TechTree");
        TechPoint = 20;

        TechLevels = new int[6];
        TechCaps = new[] { 1, 5, 5, 2, 10, 10 };
        
        TechNames = new[] {"Upgrade 1", "Upgrade 2", "Upgrade 3", "Upgrade 4", "Upgrade 5", "Upgrade 6"};
        TechDescriptions = new[]
        {
            "Does something",
            "Does something else",
            "Does something cool",
            "Does something lame",
            "Does whatever",
            "Does anything you want",
        };

        foreach (var tech in TechHolder.GetComponentsInChildren<TechNode>())
        {
            TechList.Add(tech);
        }

        for (int i = 0; i < TechList.Count; i++)
        {
            TechList[i].id = i;
        }
        
        foreach (var connector in ConnectorHolder.GetComponentsInChildren<RectTransform>())
        {
            ConnectorList.Add(connector.gameObject);
        }

        TechList[0].connectedTechs = new[] {1, 2, 3};
        TechList[3].connectedTechs = new[] { 4, 5 };
        
        UpdateAllTechUI();
    }

    public void UpdateAllTechUI()
    {
        foreach (var tech in TechList)
        {
            tech.UpdateUI();
        }
    }
}
