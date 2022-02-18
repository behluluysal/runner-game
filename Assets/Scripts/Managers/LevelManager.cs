using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    [SerializeField] public int CurrentLevel { get; set; } = 1;
    [SerializeField] public int LevelCount { get; set; } = 3;
    [SerializeField] public int RoadLenght { get; set; } = 10;
    [SerializeField] public Difficulty Difficulty { get; set; } = Difficulty.Easy;
    private void Awake()
    {
        Instance = this;
    }

    public void NextLevel()
    {
        GameManager.Instance.TotalScore += GameManager.Instance.Score;
        GameManager.Instance.Score = 0;
        if(GameManager.Instance.Health<3)
            GameManager.Instance.Health = 3;
    }

}
