using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainUIHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerMessage;
    [SerializeField] TextMeshProUGUI highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = $"High Score: {DataManager.Instance.highScore}\nHeld By: {DataManager.Instance.heldBy}";
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
