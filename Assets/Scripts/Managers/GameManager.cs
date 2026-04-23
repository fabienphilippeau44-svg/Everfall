using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private float distanceTravelled = 0f;  
    private bool isRunning = false;
    private bool isPaused = false;

    [SerializeField] private TextMeshProUGUI distanceText;
    [SerializeField] private TextMeshProUGUI countdownText;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateDistanceUI();
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        countdownText.text = "3";
        yield return new WaitForSeconds(1f);
        countdownText.text = "2";
        yield return new WaitForSeconds(1f);
        countdownText.text = "1";
        yield return new WaitForSeconds(1f);
        countdownText.text = "GO!";
        yield return new WaitForSeconds(0.5f);
        countdownText.text = "";
        StartGame();
    }
    public void StartGame()
    {
        isRunning = true;
        distanceTravelled = 0f;
    }

    private void Update()
    {
        if (isRunning && !isPaused)
        {
            distanceTravelled += Time.deltaTime * 2f;
            UpdateDistanceUI();
        }
    }

    public void StopGame()
    {
        isRunning = false;
    }

    public void ResetGame()
    {
        distanceTravelled = 0f;
        UpdateDistanceUI();
    }

    public float GetDistance()
    {
        return distanceTravelled; 
    }

    public void PauseGame()
    {
        isPaused = true;
    }

    public void ResumeGame()
    {
        isPaused = false;
    }

    public bool IsPaused()
    {
        return isPaused;
    }

    private void UpdateDistanceUI()
    {
        distanceText.text = $"{Mathf.FloorToInt(distanceTravelled)} m";
    }
}