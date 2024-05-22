using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    Castle castle;
    public int gameScore = 0;

    [SerializeField] public int scorePointKing = 50;
    [SerializeField] public int scorePointBarrel = 5;
    [SerializeField] public int scorePointTNT = 3;
    [SerializeField] public int scorePointTorch = 1;

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

    public void AddScore(int score)
    {
        gameScore += score;
        Debug.Log("Score: " + gameScore);
    }

    //After Monster Die, Monster.cs call, Update
    //After call gameScore += score;
    public void MonsterScoreAdd(string name)
    {
        int score;
        if (name == "GoblinTorch(Clone)")
            score = scorePointTorch;
        else if (name == "GoblinTNT(Clone)")
            score = scorePointTNT;
        else if (name == "GoblinBarrel(Clone)")
            score = scorePointBarrel;
        else //¸¶¿Õ
            score = scorePointKing;

        instance.AddScore(score);
    }

    //After Item Eat call, Update
    public void ItemScoreAdd()
    {
        gameScore += 10;
        Debug.Log("Score: " + gameScore);
    }

    //Castle call
    public void CastleHpScoreAdd(int castleHp)
    {
        gameScore += 10 * castleHp;
    }

    //GameManager? call, Stage Level
    public void StageLevelScoreAdd(int stageLevel)
    {
        gameScore += 100*stageLevel;
    }
}
