using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public LevelInfo LevelInfo;
    public LevelSystem LevelSystem;
    public PlayerStat playerStat;
    private Define.eSceneName currentScene;
    private int currentLevel = 1;
    private float totalRoundTime;
    public bool isPlaying = false;
    public bool isAlive = true;
    public IEnumerator gameStart;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            Application.targetFrameRate = 60;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            if (GameManager.instance.currentScene == Define.eSceneName.MainScene)
            {
                GameManager.instance.LevelSystem._monsterSpawner = this.LevelSystem._monsterSpawner;
            }
            Destroy(this.gameObject);
        }
    }

    public IEnumerator GameStart()
    {
        isAlive = true;
        yield return new WaitForSeconds(10f);
        currentLevel = 1;
        float spawnDelay = 5;
        
        for (int i = 0; i < LevelInfo.levelList.Count; i++)
        {
            MainUIManager.Instance.stageText.SetText(currentLevel.ToString());
            LevelSystem.SetLevel(currentLevel++, spawnDelay);
            yield return new WaitForSeconds(spawnDelay-- * LevelInfo.levelList[i].Total + 15);
        }

        GameOver();
    }

    public void GameOver()
    {
        LevelSystem.StopLevel();
        StopCoroutine(gameStart);
        ScoreManager.instance.CastleHpScoreAdd();
        ScoreManager.instance.StageLevelScoreAdd(currentLevel-1);
        ChangedScene(Define.eSceneName.EndScene);
        
    }
    public void ChangedScene(Define.eSceneName name)
    {
        GameManager.instance.LevelSystem._monsterSpawner = null;
        SceneManager.LoadScene((int)name);
        currentScene = name;
        if (name == Define.eSceneName.MainScene)
        {
            gameStart = GameStart();
            StartCoroutine(gameStart);
        }
    }
}
