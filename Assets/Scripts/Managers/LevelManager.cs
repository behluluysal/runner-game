using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    [SerializeField] public int CurrentLevel = 1;
    [SerializeField] public int LevelCount = 3;
    [SerializeField] public int RoadLenght = 10;
    [SerializeField] public int EmptyRoadLength = 2;
    [SerializeField] public Difficulty Difficulty = Difficulty.Easy;
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
