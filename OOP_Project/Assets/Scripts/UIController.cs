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
    public TextMeshProUGUI gameOverText;
    public GameObject panelGameOver;

    //public bool gameOn = true;

    private float timeStart = 30f;
    private float currentTime;

    private Player player;

    private void Start()
    {
        Time.timeScale = 1f;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        currentTime = timeStart;
    }

    private void Update()
    {
        // The conditional structure is only temporary to avoid console errors
        // Maintenance needed in the future
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            // Countdown
            currentTime -= Time.deltaTime;
            countdownText.text = "Time left: " + currentTime.ToString("0");


            // Life
            lifeText.text = "Life: " + player.health.ToString();

            if (player.health <= 0)
            {
                GameOver(1);
            }
            else if (currentTime <= 0f)
            {
                GameOver(2);
            }
        }
        else
        {
            return;
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
    public void GameOver(int textMensage)
    {
        panelGameOver.SetActive(true);

        switch (textMensage)
        {
            case 1:
                gameOverText.text = "Que pena fulano, melhor sorte na próxima vez!";
                break;

            case 2:
                gameOverText.text = "Parabens fulano, você venceu!";
                break;
        }

        Time.timeScale = 0f;
    }

    public void ButtonTryAgain()
    {
        SceneManager.LoadScene(1);
    }
}
