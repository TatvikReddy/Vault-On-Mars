using UnityEngine;

[System.Serializable]
public class BuildingBlueprint
{
   // Prefab of the building
   public GameObject prefab;
   // Position offsets for the visual
   public Vector3 positionOffset;
   // Costs to build
   public int metalCost;
   public int moneyCost;
   public int moneyUpkeepCost;
}
