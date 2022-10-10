using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIController : MonoBehaviour
{
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
}
