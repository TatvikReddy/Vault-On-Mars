using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Interactable currentInteractable;

    public PlayerInventory playerInventory;

    public bool canInteract = false;

    public bool canMove = true;
    
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }
}
