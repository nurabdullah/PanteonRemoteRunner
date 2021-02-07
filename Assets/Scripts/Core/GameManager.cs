using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    OnGameMenu,
    OnGamePlay,
    OnGameFinish
}

public class GameManager : MonoBehaviour
{
    #region Singleton

    public static GameManager Manager;
        
    private void MakeSingleton()
    {
        if (Manager == null)
        {
            Manager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion
    
    private void Awake()
    {
        MakeSingleton();
        currentGameState = GameState.OnGameMenu;
    }

    public GameState currentGameState;

    private void Update()
    {
        switch (currentGameState)
        {
            case GameState.OnGameMenu:

                break;
            case GameState.OnGamePlay:

                break;
            case GameState.OnGameFinish:

                break;
        }
    }
}
