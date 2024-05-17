using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialInfoView : MonoBehaviour
{
    [SerializeField]
    private GameObject infoUIPrefab;
    public TutorialManager tutorialMananger;
    [SerializeField]
    private InfoSO[] infoSOs;
    // Start is called before the first frame update
    void Start()
    {
        CreateInfoes();
    }

    private void CreateInfoes()
    {
        for (int i = 0; i < infoSOs.Length; i++)
        {
            GameObject go = Instantiate(infoUIPrefab, transform);
            tutorialMananger.infoes.Add(go);
            var panel = go.GetComponent<TutorialInfoUI>();
            panel.InitInfo(infoSOs[i]);
            go.gameObject.SetActive(false);
        }        
    }
}
