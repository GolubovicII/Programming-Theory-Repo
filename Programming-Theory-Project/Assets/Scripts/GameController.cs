using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI playerNameText;

    private void Awake()
    {
        playerNameText.text = GameManager.Instance.playerName;
    }

    private void Update()
    {
        FaceTheCamera();
    }

    // ABSTRACTION
    private void FaceTheCamera()
    {
        Quaternion q = Camera.main.transform.rotation;
        playerNameText.transform.rotation = q;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
