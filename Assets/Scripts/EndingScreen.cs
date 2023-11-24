using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingScreen : MonoBehaviour
{
    [SerializeField] Text score;

    public void OpenEndingScreen(int score)
    {
        gameObject.SetActive(true);
        this.score.text = score.ToString();
    }

    public void RestartGame()
    {
        GameManager.instance.RestartGame(0);
    }

    public void MainMenu()
    {
        GameManager.instance.RestartGame(1);
    }
}
