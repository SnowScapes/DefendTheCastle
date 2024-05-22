using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingBtn : MonoBehaviour, IUiButton
{
    [SerializeField] private GameObject SettingBoard;
    public void ButtonOnClick()
    {
        Time.timeScale = 0f;
        SettingBoard.SetActive(true);
    }
}
