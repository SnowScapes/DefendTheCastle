using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public LevelInfo LevelInfo;
    public int currentLevel { get; set; }
    public bool isPlaying = false;
    public bool isAlive = true;
    private void Awake()
    {
        if(instance == null) 
        { 
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {

    }
    public void ChangedScene(Define.eSceneName name)
    {
        SceneManager.LoadScene((int)name);
    }
}
