using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
  public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
