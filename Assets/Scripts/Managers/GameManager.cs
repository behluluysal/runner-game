using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState State;
    public static event Action<GameState> OnGameStateChanged;
    [SerializeField] private int Score = 0;
    [SerializeField] private int Health = 3;
    [SerializeField] private Text UIScoreText;
    [SerializeField] private Animator UIScoreAnimator;
    [SerializeField] private Animator HP1;
    [SerializeField] private Animator HP2;
    [SerializeField] private Animator HP3;
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

    public IEnumerator AddScore(int score)
    {
        UIScoreAnimator.Play("ScoreTextAddPoints");
        for (int i = 0; i<score; ++i)
        {
            Score++;
            UIScoreText.text = Score.ToString();
            yield return new WaitForSeconds(.1f);
        }
    }
    public void HPLoss()
    {
        if(Health == 3)
        {
            Health--;
            HP3.Play("HpLoss");
        }
        else if(Health == 2)
        {
            Health--;
            HP2.Play("HpLoss");
        }
        else
        {
            Health--;
            HP1.Play("HpLoss");
        }
    }

    public enum GameState
    {
        Ready,
        PlayerTurn,
        Victory,
        Lose
    }
}