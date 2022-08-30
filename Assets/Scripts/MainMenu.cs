using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TMP_InputField playerNameInputField;

    void Start()
    {
        
    }

    public void CollectPlayerName()
    {
        DataManager.Instance.playerName = playerNameInputField.text;
        SceneManager.LoadScene(1);
    }

}
