using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroButtons : MonoBehaviour, IUiButton
{
    [SerializeField] private Button[] _buttons;
    [SerializeField] private GameObject SettingBoard;
    
    private int buttonNum;
    void Start()
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            int index = i;
            _buttons[i].onClick.AddListener(() => setButtonNum(index));
            _buttons[i].onClick.AddListener(() => ButtonOnClick());
        }
    }

    private void setButtonNum(int _input)
    {
        buttonNum = _input;
    }
    
    public void ButtonOnClick()
    {
        switch (buttonNum)
        {
            case 0:
                GameManager.instance.ChangedScene(Define.eSceneName.TutorialScene);
                SoundManager.Instance.ChangeBGM("TutorialScene");
                break;
            case 1: SettingBoard.SetActive(true);
                break;
            case 2: Application.Quit();
                break;
        }
    }
}
