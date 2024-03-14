using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    private GameState gameState;
    private void Awake()
    {
        Instance = this;
    }

    public void changeState(GameState newState)
    {
        gameState = newState;

        switch (newState)
        {
            case GameState.GenerateGrid:
                break;
            case GameState.SpawnHeroes:
                break;
            case GameState.SpawnEnemies:
                break;
            case GameState.HeroesTurn:
                break;
            case GameState.EnemiesTurn:
                break;
        }


    }
}

public enum GameState
{
    GenerateGrid = 0,
    SpawnHeroes = 1,
    SpawnEnemies = 2,
    HeroesTurn = 3,
    EnemiesTurn = 4
}
