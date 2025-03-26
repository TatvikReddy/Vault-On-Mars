using System;
using UnityEngine;

public class BuildingSelection : MonoBehaviour
{
    
    public BuildingBlueprint[] buildings;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Building Menu opened");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Building Menu closed");
        }
    }
}
