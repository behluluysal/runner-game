using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState State;
    public static event Action<GameState> OnGameStateChanged;
    [SerializeField] public int Score = 0;
    public int TotalScore = 0;
    public bool isBoostActive = false;
    [SerializeField] public int Health = 3;
    [SerializeField] private Text UIScoreText;
    [SerializeField] private Animator UIScoreAnimator;
    [SerializeField] private Animator HP1;
    [SerializeField] private Animator HP2;
    [SerializeField] private Animator HP3;
    [SerializeField] private Animator HP4;
    [Space]
    [SerializeField] private TextMeshProUGUI TotalScoreText;
    [SerializeField] private TextMeshProUGUI BuyHpErrorText;
    [SerializeField] private TextMeshProUGUI BuyBoostErrorText;
    [SerializeField] public GameObject RestartButton;
    private void Awake()
    {
        Instance = this;
        TotalScoreText.text = "0";
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.Ready:
                TotalScoreText.text = Score.ToString();
                break;
            case GameState.PlayerTurn:
                break;
            case GameState.Victory:
                break;
            case GameState.Lose:
                RestartButton.SetActive(true);
                break;
            default:
                break;
        }
        OnGameStateChanged?.Invoke(newState);
        return;
    }

    public void ReturnToReady()
    {
        UpdateGameState(GameState.Ready);
        return;
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
        if(Health == 4)
        {
            Health--;
            HP4.Play("HpLoss");
        }
        else if(Health == 3)
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

    #region [ UI Buy Section ]
    
    public void BuyHp()
    {
        if(TotalScore < 300)
        {
            BuyHpErrorText.text = "You don't have enough points";
            BuyHpErrorText.gameObject.SetActive(true);
            BuyBoostErrorText.gameObject.SetActive(false);
            return;
        }
        if(Health == 4)
        {
            BuyHpErrorText.text = "You have max health possible";
            BuyHpErrorText.gameObject.SetActive(true);
            BuyBoostErrorText.gameObject.SetActive(false);
            return;
        }
        Health++;
        BuyBoostErrorText.gameObject.SetActive(false);
        BuyHpErrorText.gameObject.SetActive(false);
    }

    public void BuyBoost()
    {
        if (TotalScore < 200)
        {
            BuyBoostErrorText.text = "You don't have enough points";
            BuyBoostErrorText.gameObject.SetActive(true);
            BuyHpErrorText.gameObject.SetActive(false);
            return;
        }
        if (!isBoostActive)
        {
            BuyBoostErrorText.text = "You already have boost for next level";
            BuyBoostErrorText.gameObject.SetActive(true);
            BuyHpErrorText.gameObject.SetActive(false);
            return;
        }
        isBoostActive = true;
        BuyBoostErrorText.gameObject.SetActive(false);
        BuyHpErrorText.gameObject.SetActive(false);
    }

    #endregion
}