using System;
using UnityEngine;

public class BuildingSelection : MonoBehaviour
{
    public GameObject buildMenu;
    
    public SpriteRenderer spriteRenderer;

    public Transform buildPosition;
    
    private bool hasBuilding = false;
    
    public GameObject currentBuilding = null;
    
    public BuildingBlueprint[] buildings;

    public void SelectBuilding(int buildingNum)
    {
        GameObject building = (GameObject)Instantiate(buildings[buildingNum].prefab, buildPosition.position + buildings[buildingNum].positionOffset, Quaternion.identity);
        currentBuilding = building;
        spriteRenderer.enabled = false;
        hasBuilding = true;
        buildMenu.SetActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasBuilding)
        {
            buildMenu.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasBuilding)
        {
            buildMenu.SetActive(false);
        }
    }
}
