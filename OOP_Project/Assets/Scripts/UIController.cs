using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI countdownText;

    //public bool gameOn = true;

    private float timeStart = 30f;
    private float currentTime;

    private Player player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        currentTime = timeStart;
    }

    private void Update()
    {
        // Countdown
        currentTime -= Time.deltaTime;
        countdownText.text = "Time left: " + currentTime.ToString("0");


        // Life
        lifeText.text = "Life: " + player.health.ToString();

        if (player.health <= 0 || currentTime <= 0f)
        {
            GameOver();
        }
    }

    #region MainMenu
    public void ButtonStartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ButtonExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }
    #endregion


    public void ButtonBackMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    

    // Panel Game Over
    public void GameOver()
    {
        Time.timeScale = 0f;
    }
}
