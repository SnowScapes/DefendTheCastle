using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{
    [SerializeField]
    private int currentCastleHp = 50;
    [SerializeField]
    private int castleMaxHp = 50;
    [SerializeField] 
    private GameObject[] castleLv;
    [SerializeField]
    private GameObject[] effects;
    [SerializeField]
    private Image hpBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpgradeCastle(int stat)
    {
        int temp = stat - castleMaxHp;
        castleMaxHp = stat;
        currentCastleHp = temp;
    }

    public void OnDamaged(int damage)
    {
        
        currentCastleHp -= damage;
        float percent = currentCastleHp / castleMaxHp;
        hpBar.fillAmount = percent;

        if (percent >= 0.6f)
        {
            
        }
        else if(percent >= 0.4f)
        {
            effects[0].SetActive(true);
        }
        else if(percent >= 0.2f)
        {
            effects[1].SetActive(true);
        }
        else if (percent > 0)
        {
            effects[2].SetActive(true);
        }
        else
        {
            hpBar.fillAmount = 0;
            GameManager.instance.GameOver();
        }


    }
}
