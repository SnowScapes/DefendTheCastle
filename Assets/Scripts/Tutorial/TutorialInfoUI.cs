using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialInfoUI : MonoBehaviour
{
    [SerializeField]
    private GameObject[] unitImages;
    [SerializeField]
    private Text unitNameTxt;
    [SerializeField]
    private Text unitDescriptionTxt;

    public void InitInfo(InfoSO so)
    {
        for(int i = 0; i < unitImages.Length; i++) 
        {
            unitImages[i].GetComponent<Image>().sprite = so.sprites[i];
        }
        unitNameTxt.text = so.unitName;
        unitDescriptionTxt.text = so.description;
    }
}
