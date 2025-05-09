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

    private void Awake()
    {
        GameManager.instance.buildings.Add(this);
    }

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
            GameManager.instance.mainCamera.GetComponent<CameraController>().SwitchOffset();

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && GameManager.instance.currentInteractable == this)
        {
            GameManager.instance.currentInteractable = null;
            GameManager.instance.canInteract = false;
            GameManager.instance.mainCamera.GetComponent<CameraController>().SwitchOffset();
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

    public virtual void resetBuilding()
    {
        //For work buildings this does not mean anything
        //For HAB buildings this means bringing their workers back to home for a little bit
    }
}
