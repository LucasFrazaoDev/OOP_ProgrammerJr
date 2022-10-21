using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DataPersistence : MonoBehaviour
{
    public static DataPersistence Instance;

    private string _currentPlayer;

    [SerializeField] private TMP_InputField inputfieldName;

    public string CurrentPlayer
    { 
        get => _currentPlayer;
        set => _currentPlayer = value;
    }


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
        if (inputfieldName.text == "")
        {
            CurrentPlayer = "Stranger";
        }
        else
        {
            CurrentPlayer = inputfieldName.text;
        }
    }
}
