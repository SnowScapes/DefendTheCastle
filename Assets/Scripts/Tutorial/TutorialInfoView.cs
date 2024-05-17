using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialInfoView : MonoBehaviour
{
    [SerializeField]
    private GameObject InfoUIPrefab;
    public List<GameObject> Infoes = new List<GameObject>();
    [SerializeField]
    private InfoSO[] InfoSOs;
    // Start is called before the first frame update
    void Start()
    {
        CreateInfoes();
    }

    private void CreateInfoes()
    {
        for (int i = 0; i < InfoSOs.Length; i++)
        {
            GameObject go = Instantiate(InfoUIPrefab, transform);
            Infoes.Add(go);
            var panel = go.GetComponent<TutorialInfoUI>();
            panel.InitInfo(InfoSOs[i]);
        }        
    }
}
