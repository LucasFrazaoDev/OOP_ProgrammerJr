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
    [SerializeField] private TextMeshProUGUI lifeText;
    [SerializeField] private TextMeshProUGUI countdownText;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private GameObject panelGameOver;

    private string playerName;
    private float timeStart = 30f;
    private float currentTime;

    private Player player;

    private void Start()
    {
        Time.timeScale = 1f;
        playerName = DataPersistence.Instance.CurrentPlayer;
        currentTime = timeStart;

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            // Countdown
            currentTime -= Time.deltaTime;
            countdownText.text = "Time left: " + currentTime.ToString("0");

            // Life
            lifeText.text = "Life: " + player.Health.ToString();

            if (player.Health <= 0)
            {
                GameOver(1);
            }
            else if (currentTime <= 0f)
            {
                GameOver(2);
            }
        }
    }

    #region MainMenu
    public void ButtonStartGame()
    {
        DataPersistence.Instance.SavePlayerName();
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
    public void GameOver(int textMensage)
    {
        lifeText.text = "Life: 0";
        panelGameOver.SetActive(true);

        switch (textMensage)
        {
            case 1:
                gameOverText.text = "Too bad " + playerName + ", better luck next time!";
                break;

            case 2:
                gameOverText.text = "Congratulations " +playerName + ", you win!";
                break;
        }

        Time.timeScale = 0f;
    }

    public void ButtonTryAgain()
    {
        SceneManager.LoadScene(1);
    }
}
