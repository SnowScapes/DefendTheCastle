using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkillController : MonoBehaviour
{

    [SerializeField]
    private Castle castle;
    [SerializeField]
    private GameObject worker;
    bool bIsRepair = false;
    float coolDownTime = 30.0f;
    float operateTime = 5.0f;
    //float waitPeriod = 1.0f;
    [SerializeField]
    private int recoveryAmount = 5;
    [SerializeField]
    private Image coolDownBar;
    [SerializeField]
    private Button coolDownBtn;
    private BehaviorController controller;

    private void Awake()
    {
        controller = GetComponent<BehaviorController>();
    }
    
    void Start()
    {
        controller.OnSkillEvent += SKill;
    }

    public void SKill()
    {
        if (!bIsRepair)
        {
            bIsRepair = true;
            coolDownBtn.interactable = false;
            StartCoroutine(RepairedCastle());
        }
    }

    private IEnumerator RepairedCastle()
    {
        worker.SetActive(true);
        float repairTime = 0;
        int second = 1;
        while (repairTime < operateTime)
        {
            repairTime += Time.deltaTime;

            if (repairTime >= second)
            {
                second++;
                castle.RepairCastle(recoveryAmount);
            }
            yield return null;
        }
        worker.SetActive(false);
        StartCoroutine(CoolDonwSkill());
    }

    private IEnumerator CoolDonwSkill()
    {
        coolDownBar.gameObject.SetActive(true);
        float waitTime = coolDownTime;
        while (waitTime > 0)
        {
            waitTime -= Time.deltaTime;
            coolDownBar.fillAmount = waitTime / coolDownTime;
            yield return null;
        }
        coolDownBar.gameObject.SetActive(false);
        coolDownBtn.interactable = true;
        bIsRepair = false;
    }
}
