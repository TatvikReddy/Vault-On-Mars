using System;
using UnityEngine;

public class Building : Interactable
{
    // Name of the building
    public string buildingName;
    // Blueprint of the building (Contains the Prefab, position offsets, and costs)
    public BuildingBlueprint blueprint;

    public GameObject menuCanvas;

    public bool onDisplayCanMove = true;
    
    // Add NPC array here later

    public override void Interact()
    {
        // Add functionality of displaying building details when interacted with
        Debug.Log("Interacted with " + buildingName);

        if (menuCanvas != null)
        {
            enableMenu(onDisplayCanMove);
        }
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

    public void enableMenu(bool freeMovement)
    {
        GameManager.instance.canMove = freeMovement;
        menuCanvas.SetActive(true);
    }

    public void disableMenu()
    {
        GameManager.instance.canMove = true;
        menuCanvas.SetActive(false);
    }
}
