using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerName;
    [SerializeField] TextMeshProUGUI highScoreText;

    private void Start()
    {
        highScoreText.text = $"High Score: {DataManager.Instance.highScore}\nHeld By: {DataManager.Instance.heldBy}";
    }

    public void StartGame()
    {
        DataManager.Instance.playerName = playerName.text;
        SceneManager.LoadScene(1);
    }
}
