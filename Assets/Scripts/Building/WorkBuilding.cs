using UnityEngine;

public class WorkBuilding : Building
{
    public int totalJobOpenings = 0;
    public int currentJobOpening = 0;
    public GameObject[] NpcList;
    
    private void Start()
    {
        NpcList = new GameObject[totalJobOpenings];
        currentJobOpening = totalJobOpenings;
        if (totalJobOpenings > 0)
        {
            JobManager.instance.AddJob(this);
        }
    }
    
    public void AddWorker(GameObject worker)
    {
        if (currentJobOpening <= 0)
        {
            Debug.Log(buildingName + " is already full of workers");
            return;
        }
        
        NpcList[--currentJobOpening] = worker;
    }
}
