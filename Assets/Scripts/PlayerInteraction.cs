using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            print("Interacting with Something");
        }
    }
}
