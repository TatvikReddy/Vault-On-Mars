using System;
using UnityEngine;

public class Building : Interactable
{
    // Name of the building
    public string buildingName;
    // Blueprint of the building (Contains the Prefab, position offsets, and costs)
    public BuildingBlueprint blueprint;
    
    // Add NPC array here later
    public override void Interact()
    {
        // Add functionality of displaying building details when interacted with
        Debug.Log("Interacted with Building");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.currentInteractable = this;
            GameManager.instance.canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && GameManager.instance.currentInteractable == this)
        {
            GameManager.instance.currentInteractable = null;
            GameManager.instance.canInteract = false;
        }
    }
}
