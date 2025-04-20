using System;
using UnityEngine;

public class Resource : Interactable
{
    public ResourceType resourceType;

    public int resourceGainPerHit;

    public int totalResource;
    
    public int currentResource;

    private void Start()
    {
        currentResource = totalResource;
    }

    public override void Interact()
    {
        if (currentResource > 0)
        {
            currentResource -= resourceGainPerHit;
        }
        else
        {
            // Take this resource to exhausted state
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
}
