using UnityEngine;

public class CanvasToggle : MonoBehaviour
{
    public GameObject canvasObject; // Assign this in the Inspector

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && canvasObject != null)
        {
            canvasObject.SetActive(!canvasObject.activeSelf);
            GameManager.instance.canMove = false;
        }
    }



    // Call this method from the Continue button's OnClick event
    public void CloseCanvas()
    {
        if (canvasObject != null)
        {
            canvasObject.SetActive(false);
        }
        GameManager.instance.canMove = true;

    }
}
