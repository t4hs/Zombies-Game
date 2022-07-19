using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public GameObject zombieSpawning;
    public GameObject playerSpawning;
    private event Action<GameState> GameStateChange;

    void Awake()
    {
        GameStateChange+=OnGameStateChange;
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        ChangeState(GameState.GameStart);
    }
    void OnDestroy()
    {
        GameStateChange-=OnGameStateChange;
    }



    public void ChangeState(GameState state)
    {
        GameStateChange(state);
    }

    public static GameManager GetInstance()
    {
        return instance;
    }
    private void OnGameStateChange(GameState state)
    {
        switch(state)
        {
            case GameState.GameStart:
                StartGame();
                break;
            case GameState.GameOver:
                EndGame();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
    }

    private void StartGame()
    {
        PlayerManager.GetInstance().SpawnPlayer();
        ZombieManager.GetInstance().SpawnZombies(10);
    }

    public void Print(string text)
    {
        Debug.Log(text);
    }
    private void EndGame()
    {
        //ToDo show player gameover screen
    }
}

public enum GameState
{
    GameStart,
    GameOver
}
