using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int totalPoints;
    [SerializeField] public TextMeshProUGUI pointsText;
    public GameObject DeathScreen;
    [SerializeField] public TextMeshProUGUI finalPointsText;
    private bool gameStarted = false;
    public GameObject StartScreen;
    public static bool isRestarting = false;

    public void addPoint()
    {
        totalPoints++;
        Debug.Log("Point added" + totalPoints);

        if (pointsText != null)
        {
            pointsText.text = totalPoints.ToString();
        }
    }

    public void PlayerDied()
    {
        Debug.Log("PlayerDied() called, showing death screen.");
        DeathScreen.SetActive(true);
        finalPointsText.text = totalPoints.ToString();
    }

    public int getScore()
    {
        return totalPoints;
    }

    public void Reset()
    {
        totalPoints = 0;
        DeathScreen.SetActive(false);
        StartScreen.SetActive(false);
        isRestarting = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public bool IsGameStarted()
    {
        return gameStarted;
    }
   
    public void setIsRestarting()
    {
        isRestarting = true;
        GameManager.Instance.gameStart();
    }
    public void gameStart()
    {
        gameStarted = true;
        isRestarting = true;
        StartScreen.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DeathScreen.SetActive(false);
        StartScreen.SetActive(true);

        if (isRestarting)
        {
            StartScreen.SetActive(false); // Don't show start UI again
            gameStarted = true;
            isRestarting = false;
        }
        else
        {
            StartScreen.SetActive(true);

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
