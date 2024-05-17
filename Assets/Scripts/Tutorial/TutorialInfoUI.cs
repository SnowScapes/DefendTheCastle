using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialInfoUI : MonoBehaviour
{
    [SerializeField]
    private Image[] UnitImages;
    [SerializeField]
    private Text UnitNameTxt;
    [SerializeField]
    private Text UnitDescriptionTxt;

    public void InitInfo(InfoSO so)
    {
        for(int i = 0; i < UnitImages.Length; i++) 
        {
            UnitImages[i] = so.Images[i];
        }
        UnitNameTxt.text = so.Name;
        UnitDescriptionTxt.text = so.Description;
    }
}
