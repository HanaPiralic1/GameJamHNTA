using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string startSceneName = "AwakeningGrove";

    public void OnStartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(startSceneName);
    }
    
}
