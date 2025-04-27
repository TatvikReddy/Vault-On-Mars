using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        // When player presses interaction button get the item and use its Interact() function
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (GameManager.instance.canInteract)
            {
                GameManager.instance.currentInteractable.Interact();
            }
        }
    }
}
