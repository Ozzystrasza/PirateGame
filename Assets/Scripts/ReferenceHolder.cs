using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceHolder : MonoBehaviour
{
    public static ReferenceHolder instance;

    public Spawner spawner;
    public PlayerController playerController;
    public MainMenu mainMenu;
    public EndingScreen endingScreen;

    private void Awake()
    {
        instance = this;
    }
}
