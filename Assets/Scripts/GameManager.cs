using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] float spawnRate;
    [SerializeField] Spawner spawner;

    private void Awake()
    {
        instance = this;

        spawner.SetSpawnRate(spawnRate);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameOver()
    {

    }
}
