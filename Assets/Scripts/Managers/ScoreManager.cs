using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    Castle castle;
    private int gameScore = 0;

    [SerializeField] private int scorePointKing = 50;
    [SerializeField] private int scorePointBarrel = 5;
    [SerializeField] private int scorePointTNT = 3;
    [SerializeField] private int scorePointTorch = 1;

    public static ScoreManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        gameScore = 0;
    }

    //After Monster Die, Monster.cs call, Update
    //After call gameScore += score;
    ScoreManager scoreManager;
    public void MonsterScoreAdd()
    {
        int score;
        if (gameObject.name == "goblinTorch")
            score = scorePointTorch;
        else if (gameObject.name == "goblinTNT")
            score = scorePointTNT;
        else if (gameObject.name == "goblinBarrel")
            score = scorePointBarrel;
        else //¸¶¿Õ
            score = scorePointKing;

        scoreManager.gameScore += score;
        Debug.Log(gameScore);
    }

    //After Item Eat call, Update
    public void ItemScoreAdd(int itemScore)
    {
        scoreManager.gameScore += 10 * itemScore;
    }

    //Castle call
    public void CastleHpScoreAdd(int castleHp)
    {
        scoreManager.gameScore += 10 * castleHp;
    }

    //GameManager? call, Stage Level
    public void StageLevelScoreAdd(int stageLevel)
    {
        scoreManager.gameScore += 100*stageLevel;
    }
}
