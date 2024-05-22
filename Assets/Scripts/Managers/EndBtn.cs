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
        if (GameManager.instance.isAlive)
        {
            VictoryPanel.SetActive(true);
        }
            
        else
        {
            GameOverPanel.SetActive(true);
        }
        ScoreText.text = ScoreManager.instance.gameScore.ToString();
          
    }
    public void RetryBtn()
    {

        GameManager.instance.isAlive = true;
        GameManager.instance.ChangedScene(Define.eSceneName.TutorialScene);
        VictoryPanel.SetActive(false);
        GameOverPanel.SetActive(false);

    }
    public void ExitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
