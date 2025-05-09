using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public List<Building> buildings = new List<Building>();

    public Canvas turnEndCanvas;

    public Transform spawnPoint;

    public int currentTurn;
    public TMP_Text turnText;

    public Interactable currentInteractable;

    public PlayerInventory playerInventory;

    public Camera mainCamera;

    public bool canInteract = false;

    public bool canMove = true;
    
    public bool transitioning = false;
    
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        currentTurn = 0;
        turnText.text = currentTurn.ToString();
    }

    public void StartTurn()
    {
        
        playerInventory.updateResource(ResourceType.Money,  -1 *getUpkeepCost());

        if (playerInventory.getResource(ResourceType.Money) < 0)
        {
            turnEndCanvas.GetComponent<TurnTransition>().GameLost();
            return;
        }
        
        currentTurn++;
        turnText.text = currentTurn.ToString();

        //reset all buildings
        foreach (var building in buildings)
        {
            building.resetBuilding();
        }
        
        transitioning = false;
        canMove = true;

    }

    public void EndTurn()
    {
        canMove = false;
        canInteract = false;
        transitioning = true;
        //Calculate cost of all buildings and then start animation to subtract and start next turn
        turnEndCanvas.GetComponent<TurnTransition>().StartTransition();
    }

    public int getUpkeepCost()
    {
        int totalCost = 0;
        foreach (var building in buildings)
        {
            totalCost += building.blueprint.moneyUpkeepCost;
        }

        return totalCost;
    }

    public void resetPlayer()
    {
        playerInventory.gameObject.transform.position = spawnPoint.position;
    }
    
}
