using UnityEngine;

public class Resource : Interactable
{
    public ResourceType resourceType;

    public int resourceGainPerHit;

    public int totalResource;
    
    private int currentResource;
    
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
}
