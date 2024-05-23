using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class EndBtn : MonoBehaviour
{

    [SerializeField] private GameObject VictoryPanel;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private Text ScoreText;

    private void Start()
    {
        SoundManager.Instance.ChangeBGM(Define.eSceneName.EndScene);
        ScoreText.text = ScoreManager.instance.gameScore.ToString();
        if (GameManager.instance.isAlive)
        {
            VictoryPanel.SetActive(true);
        }
            
        else
        {
            GameOverPanel.SetActive(true);
        }
          
    }
    public void RetryBtn()
    {
        ScoreManager.instance.RefreshScore();
        SoundManager.Instance.ChangeBGM(Define.eSceneName.TutorialScene);
        GameManager.instance.isAlive = true;
        GameManager.instance.ChangedScene(Define.eSceneName.TutorialScene);
        VictoryPanel.SetActive(false);
        GameOverPanel.SetActive(false);

    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
