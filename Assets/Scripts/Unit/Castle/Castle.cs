using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    public int hpUpgradStep { get; private set; } = 0;
    [SerializeField]
    private int castleHp = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCastleHp(int stat)
    {
        castleHp = stat;
        hpUpgradStep++;
    }
}
