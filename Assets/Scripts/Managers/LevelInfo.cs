using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
class Level
{
    public int level;
    public int Torch;
    public int Tnt;
    public int Barrel;


    public int get(Define.eMonsterType type)
    {
        int amount = 0;
        switch (type)
        {
            case Define.eMonsterType.Torch : 
                amount = Torch;
                break;
            case Define.eMonsterType.Tnt :
                amount = Tnt;
                break;
            case Define.eMonsterType.Barrel :
                amount = Barrel;
                break;
        }
        return amount;
    }
}

[CreateAssetMenu(fileName = "LevelInfo", menuName = "Level", order = 0)]
public class LevelInfo : ScriptableObject
{
    [SerializeField]internal List<Level> levelList;
}
