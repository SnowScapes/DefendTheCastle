using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    private int infoIndex = 0;
    public List<GameObject> infoes = new List<GameObject>();
    [SerializeField]
    private Button leftArrowBtn, rightArrowBtn, startBtn, skipBtn;
    // Start is called before the first frame update
    private void Start()
    {
        infoes[infoIndex].SetActive(true);
        if (GameManager.instance != null)
        {
            startBtn.onClick.AddListener(() => GameManager.instance.ChangedScene(Define.eSceneName.MainScene));
            startBtn.interactable = false;
            skipBtn.onClick.AddListener(() => GameManager.instance.ChangedScene(Define.eSceneName.MainScene));
        }
    }

    public void TurnLeft()
    {
        if (infoIndex >= 1)
        {
            infoes[infoIndex].SetActive(false);
            infoes[--infoIndex].SetActive(true);
        }

        if(infoIndex == 0) 
        {
            leftArrowBtn.interactable = false;
        }
        else if(infoIndex == infoes.Count - 2) 
        {
            rightArrowBtn.interactable = true;
        }
    }

    public void TurnRigt()
    {
        if (infoIndex < infoes.Count - 1)
        {
            infoes[infoIndex].SetActive(false);
            infoes[++infoIndex].SetActive(true);
        }

        if (infoIndex == infoes.Count - 1)
        {
            rightArrowBtn.interactable = false;
        }
        else if (infoIndex == 1)
        {
            leftArrowBtn.interactable = true;
        }

        if (infoIndex == infoes.Count - 1 && !startBtn.interactable)
        {
            startBtn.interactable = true;
        }
    }
}
