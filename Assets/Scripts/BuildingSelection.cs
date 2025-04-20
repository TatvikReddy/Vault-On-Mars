using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingSelection : MonoBehaviour
{
    // Reference to Canvas the UI is built on
    public GameObject buildMenu;
    // Reference to Parent of the buttons
    public GameObject buttonParent;
    // Reference to a Prefab of the buttons
    public GameObject buttonPrefab;
    // Display of the current building in the plot
    public GameObject currentBuilding = null;
    // Reference to an Array of building options set in inspector
    public Building[] buildings;
    // Reference to the sprite renderer of the building plots visuals
    private SpriteRenderer spriteRenderer;
    // Boolean to check if a building has been placed
    private bool hasBuilding = false;

    public void Start()
    {
        // Get the sprite renderer of the plot for later use
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        // Get the rect transform of the canvas and reshape it for the buttons in this plot
        RectTransform rt = buildMenu.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(buildings.Length * 200, 900);
        
        // Get buttons made for the plot
        for(int i = 0; i < buildings.Length; i++)
        {
            // Instantiates the buttons and makes sure the scale is reset
            GameObject button = Instantiate(buttonPrefab, buttonParent.transform);
            button.transform.localScale = Vector3.one;
            
            // Save the building index because of an error when adding listeners and using loop variables for arguments
            int buildingIndex = i;
            
            // Set the text to the name of the correct building
            TMP_Text text = button.GetComponentInChildren<TMP_Text>();
            text.text = buildings[i].buildingName;
            
            // Add an OnClick function to the button connected to the SelectBuilding function
            button.GetComponent<Button>().onClick.AddListener(() => SelectBuilding(buildingIndex));
        }
    }

    public void SelectBuilding(int buildingNum)
    {
        // Instantiate the building and set current building
        GameObject building = (GameObject)Instantiate(buildings[buildingNum].blueprint.prefab, this.transform.position + buildings[buildingNum].blueprint.positionOffset, Quaternion.identity);
        currentBuilding = building;
        
        // Get rid of the visuals for the plot and update the status of the build menu
        spriteRenderer.enabled = false;
        hasBuilding = true;
        buildMenu.SetActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // When player is inside the collider of the plot it will appear
        if (other.CompareTag("Player") && !hasBuilding)
        {
            buildMenu.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // When player exits the collider of the plot it will disappear
        if (other.CompareTag("Player") && !hasBuilding)
        {
            buildMenu.SetActive(false);
        }
    }
}
