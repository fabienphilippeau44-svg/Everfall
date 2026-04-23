using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class LoadingScreenManager : MonoBehaviour
{

    [SerializeField] private Image progressBar;
    [SerializeField] private TextMeshProUGUI progressText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(LoadSceneAsync());
    }

    private IEnumerator LoadSceneAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneController.SceneToLoad);
        operation.allowSceneActivation = false;

        float fakeProgress = 0f;

        while (operation.progress < 0.9f || fakeProgress < 1f)
        {
            fakeProgress = Mathf.MoveTowards(fakeProgress, Mathf.Clamp01(operation.progress / 0.9f), Time.deltaTime * 0.5f);
            progressBar.fillAmount = fakeProgress;
            progressText.text = Mathf.RoundToInt(fakeProgress * 100f) + "%";
            yield return null;
        }

        progressBar.fillAmount = 1f;
        progressText.text = "100%";
        yield return new WaitForSeconds(0.5f);
        operation.allowSceneActivation = true;
    }

    // Update is called once per frame
    
}
