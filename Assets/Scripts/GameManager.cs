using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField, Range(1, 3)] int maxGameSessionTime;
    [SerializeField] float spawnRate;

    [SerializeField] Spawner spawner;
    [SerializeField] PlayerController playerController;
    [SerializeField] EndingScreen endingScreen;
    [SerializeField] MainMenu mainMenu;

    int playerScore;

    public int MaxGameSessionTime { get => maxGameSessionTime; set => maxGameSessionTime = value; }
    public float SpawnRate { get => spawnRate; set => spawnRate = value; }

    private void Awake()
    {
        if (!instance)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("MainMenu", 1) == 1)
            OpenMainMenu();
        else
            StartGame();
    }

    IEnumerator CountGameSessionTime()
    {
        int gameSessionTime = 0;
        while (gameSessionTime < MaxGameSessionTime * 60)
        {
            gameSessionTime += 1;
            yield return new WaitForSeconds(1);
        }

        GameOver();
    }

    public void StartGame()
    {
        playerController.EnableControlOfShip();
        StartCoroutine(CountGameSessionTime());
        spawner.StartSpawning(SpawnRate);
    }

    public void AddPlayerScore()
    {
        playerScore++;
    }

    public void GameOver()
    {
        spawner.StopSpawning();
        playerController.DisableControlOfShip();
        endingScreen.OpenEndingScreen(playerScore);
    }

    public void RestartGame(int mainMenu)
    {
        PlayerPrefs.SetInt("MainMenu", mainMenu);
        SceneManager.LoadScene(0);
    }

    public void OpenMainMenu()
    {
        mainMenu.gameObject.SetActive(true);
    }

    public void SetMaxGameSessionTime(int time)
    {
        MaxGameSessionTime = time;
    }

    public void SetEnemySpawnTime(float time)
    {
        SpawnRate = time;
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("MainMenu", 1);
    }
}
