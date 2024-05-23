using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialInfoUI : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> unitImages;
    [SerializeField]
    private Text unitNameTxt;
    [SerializeField]
    private Text unitDescriptionTxt;

    public void InitInfo(InfoSO so)
    {
        CheckObjectCount(so);
        for (int i = 0; i < unitImages.Count; i++) 
        {
            unitImages[i].GetComponent<Image>().sprite = so.sprites[i];
        }
        unitNameTxt.text = so.unitName;
        SetDescription(so);
    }

    private void SetDescription(InfoSO so)
    {
        for (int i = 0; i < so.description.Length; i++)
        {
            unitDescriptionTxt.text += so.description[i];
            unitDescriptionTxt.text += "\n";
        }
    }

    private void CheckObjectCount(InfoSO so)
    {
        
        while (so.sprites.Length != unitImages.Count)
        {
            if (so.sprites.Length < unitImages.Count)
            {
                Destroy(unitImages[unitImages.Count - 1]);
                unitImages.RemoveAt(unitImages.Count - 1);
            }
        }
    }
}
