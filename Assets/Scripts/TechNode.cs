using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TechNode : MonoBehaviour
{
    public int id;

    public TMP_Text titleText;
    public TMP_Text descriptionText;

    public int[] connectedTechs;

    public void UpdateUI()
    {
        titleText.text = TechTree.instance.TechLevels[id] + "/" + TechTree.instance.TechCaps[id] + "\n" + TechTree.instance.TechNames[id];
        descriptionText.text = TechTree.instance.TechDescriptions[id] + "\nCost: " + TechTree.instance.TechPoint + "/1 TP";

        GetComponent<Image>().color = TechTree.instance.TechLevels[id] >= TechTree.instance.TechCaps[id]
            ?
            Color.yellow
            : TechTree.instance.TechPoint >= 1
                ? Color.green
                : Color.white;

        foreach (var connectedTech in connectedTechs)
        {
            TechTree.instance.TechList[connectedTech].gameObject.SetActive(TechTree.instance.TechLevels[id] > 0);
            TechTree.instance.ConnectorList[connectedTech].SetActive(TechTree.instance.TechLevels[id] > 0);
        }
    }

    public void Buy()
    {
        if (TechTree.instance.TechPoint < 1 || TechTree.instance.TechLevels[id] >= TechTree.instance.TechCaps[id])
        {
            return;
        }

        TechTree.instance.TechPoint -= 1;
        TechTree.instance.TechLevels[id]++;
        TechTree.instance.UpdateAllTechUI();
    }

    
}
