using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject options;

    public void StartGame()
    {
        GameManager.instance.StartGame();
    }

    public void Options()
    {
        options.SetActive(true);
    }
}
