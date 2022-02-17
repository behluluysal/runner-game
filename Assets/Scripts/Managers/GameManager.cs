using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState State;
    public static event Action<GameState> OnGameStateChanged;
    [SerializeField] private int Score = 0;
    [SerializeField] private int Health = 3;
    private void Awake()
    {
        Instance = this;
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.Ready:
                break;
            case GameState.PlayerTurn:
                break;
            case GameState.Victory:
                break;
            case GameState.Lose:
                break;
            default:
                break;
        }
        OnGameStateChanged?.Invoke(newState);
    }

    public enum GameState
    {
        Ready,
        PlayerTurn,
        Victory,
        Lose
    }
}