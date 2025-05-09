using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.canInteract)
        {
            // When player presses interaction button get the item and use its Interact() function
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameManager.instance.currentInteractable.Interact();
            }
        }

        if (!GameManager.instance.transitioning)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                GameManager.instance.EndTurn();
            }
        }
        
    }
}
