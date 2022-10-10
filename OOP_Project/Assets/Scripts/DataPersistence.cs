using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DataPersistence : MonoBehaviour
{
    public static DataPersistence Instance;

    public TMP_InputField inputfieldName;
    public string currentPlayer;

    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SavePlayerName()
    {
        currentPlayer = inputfieldName.text;
    }
}
