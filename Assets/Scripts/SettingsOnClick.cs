using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SettingsOnClick : MonoBehaviour
{

    public GameObject panel;
    public Button exit;
    void Start()
    {
        exit.onClick.AddListener(ExitClick);
    }

    public void SettingsClick()
    {
        panel.SetActive(true);
    }

    public void ExitClick()
    {
        exit.onClick.RemoveListener(ExitClick);
        exit.gameObject.SetActive(false);
        panel.SetActive(false);
    }

}