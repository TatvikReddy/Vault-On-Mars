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
}
