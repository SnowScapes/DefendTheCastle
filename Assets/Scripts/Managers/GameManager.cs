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
    private int currentLevel = 1;
    [SerializeField]private float totalRoundTime = 45f;
    public bool isPlaying = false;
    public bool isAlive = true;
    private IEnumerator gameStart;
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
            GameManager.instance.LevelSystem._monsterSpawner = this.LevelSystem._monsterSpawner;
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        gameStart = GameStart();
    }

    public IEnumerator GameStart()
    {
        currentLevel = 1;
        WaitForSeconds roundTime = new WaitForSeconds(totalRoundTime);
        for (int i = 0; i < LevelInfo.levelList.Count; i++)
        {
            Debug.Log(currentLevel);
            LevelSystem.SetLevel(currentLevel);
            yield return roundTime;
            currentLevel++;
        }   
    }

    public void GameOver()
    {
        StopCoroutine(gameStart);
    }
    public void ChangedScene(Define.eSceneName name)
    {
        SceneManager.LoadScene((int)name);
        if (name == Define.eSceneName.MainScene)
            StartCoroutine(gameStart);
    }
}
