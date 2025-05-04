using UnityEngine;
using System.Collections.Generic;

public class JobManager : MonoBehaviour
{
    public static JobManager instance;

    public int jobsOpen = 0;
    public List<WorkBuilding> jobs = new List<WorkBuilding>();
    public List<NPCBehavior> unassignedNpcs = new List<NPCBehavior>();
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    public void RequestJob(NPCBehavior worker)
    {
        Debug.Log("Worker Looking For Job");
        if (jobsOpen == 0)
        {
            unassignedNpcs.Add(worker);
            Debug.Log("Worker Couldn't Find Job");
            return;
        }
        
        foreach (var job in jobs)
        {
            if (job.currentJobOpening > 0)
            {
                Debug.Log("Worker Found Job at " + job.buildingName);
                job.AddWorker(worker.gameObject);
                worker.AssignJob(job.gameObject);
                jobsOpen--;
                return;
            }
        }
    }

    public void AddJob(WorkBuilding job)
    {
        Debug.Log("Made " + job.totalJobOpenings + " jobs");
        jobs.Add(job);
        jobsOpen += job.totalJobOpenings;

        for (int i = 0; i < job.totalJobOpenings; i++)
        {
            if (unassignedNpcs.Count > 0)
            {
                job.AddWorker(unassignedNpcs[0].gameObject);
                unassignedNpcs[0].AssignJob(job.gameObject);
                unassignedNpcs.RemoveAt(0);
                jobsOpen--;
            }
        }
    }
    
}
