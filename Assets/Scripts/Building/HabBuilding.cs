using UnityEngine;
using System.Collections;

public class HabBuilding : Building
{
    public int habSize;

    public GameObject NpcPrefab;
    
    public GameObject[] habResidents;

    private float spawnTimer = 1.5f;

    private void Start()
    {
        StartCoroutine(SpawnNPCs());
    }

    private IEnumerator SpawnNPCs()
    {
        for (int i = 0; i < habSize; i++)
        {
            GameObject npc = Instantiate(NpcPrefab, transform);
            npc.GetComponent<NPCBehavior>().SetHome(gameObject);
            yield return new WaitForSeconds(spawnTimer);
        }
    }

    private IEnumerator NPCReset()
    {
        foreach (var resident in habResidents)
        {
            yield return new WaitForSeconds(Random.Range(1.5f, 6.0f));
            resident.GetComponent<NPCBehavior>().currentState = NpcState.GoingToWork;
        }
    }

    public override void resetBuilding()
    {
        foreach (var resident in habResidents)
        {
            resident.GetComponent<NPCBehavior>().currentState = NpcState.IdleAtHome;
            resident.transform.position = transform.position;
        }
        
        StartCoroutine(NPCReset());
        //Get NPCs back home and have them wait random time before going to work
    }
}
