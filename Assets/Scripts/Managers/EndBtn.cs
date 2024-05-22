using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class EndBtn : MonoBehaviour
{
    public void SceneChange(int num)
    {
        SceneManager.LoadScene(num);
        SoundManager.Instance.ChangeBGM(Define.eSceneName.EndScene);
    }
    public void ExitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
