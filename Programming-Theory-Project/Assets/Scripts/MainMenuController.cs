using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private GameObject nameInputField;

    private void Awake()
    {
        nameInputField = GameObject.Find("Enter Name InputField");
    }

    public void UpdatePlayerName()
    {
        GameManager.Instance.playerName = nameInputField.GetComponent<TMP_InputField>().text;
        Debug.Log(GameManager.Instance.playerName);
    }

    public void LoadGameScene()
    {
        if (GameManager.Instance.playerName != null && GameManager.Instance.playerName != "")
            SceneManager.LoadScene(1);
    }
}
