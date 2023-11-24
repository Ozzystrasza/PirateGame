using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    [SerializeField] Text gameSessionTimeText;
    [SerializeField] Text enemySpawnTimeText;

    int gameSessionTime = 1;
    float enemySpawnTime = 6;

    private void Start()
    {
        gameSessionTimeText.text = GameManager.instance.MaxGameSessionTime.ToString();
        enemySpawnTimeText.text = GameManager.instance.SpawnRate.ToString();
    }

    public void ChangeGameSessionTime(int time)
    {
        gameSessionTime += time;
        gameSessionTime = Mathf.Clamp(gameSessionTime, 1, 3);

        gameSessionTimeText.text = gameSessionTime.ToString();

        GameManager.instance.SetMaxGameSessionTime(gameSessionTime);
    }

    public void ChangeEnemySpawnTime(int time)
    {
        enemySpawnTime += time;
        enemySpawnTime = Mathf.Clamp(enemySpawnTime, 4, 10);

        enemySpawnTimeText.text = enemySpawnTime.ToString();

        GameManager.instance.SetEnemySpawnTime(enemySpawnTime);
    }

}
