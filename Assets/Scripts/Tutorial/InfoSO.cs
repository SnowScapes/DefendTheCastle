using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "InfoSo", menuName = "Tutorial/UI/Infoes/Deafult", order = 0)]
public class InfoSO : ScriptableObject
{
    public Sprite[] sprites;
    public Animator[] animator;
    public string unitName;
    public string description;
}
