using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public static string SceneToLoad { get; private set; }

    public void LoadSceneAsync(string sceneName)
    {
        SceneToLoad = sceneName;
        SceneManager.LoadScene("LoadingScreen");
    }

    

    public void QuitGame()
    {
        Debug.Log("Jeu quitté");
        Application.Quit();
    }
}
