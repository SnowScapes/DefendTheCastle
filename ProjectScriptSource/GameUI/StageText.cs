using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageText : MonoBehaviour, IUiText
{
    [SerializeField] private Text stageText;
    
    public void SetText(string text)
    {
        stageText.text = text;
    }
}
