using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNTBehavior : MonsterBehavior
{
    [SerializeField] private GameObject Dynamite_Prefab;
    private DynamiteScript dynamite_Script;
    private GameObject dynamite;

    private bool stop = false;
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.layer)
        {
            case 11:
                StopCoroutine(move);
                stop = false;
                StartCoroutine(throwCouroutine(other.transform));
                break;
            case 12:
                StopCoroutine(move);
                stop = false;
                StartCoroutine(throwCouroutine(other.transform));
                break;
        }
    }

    protected override void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 11)
        {
            stop = true;
            StartCoroutine(move);
        }
    }

    private IEnumerator throwCouroutine(Transform target)
    {
        WaitForSeconds delay = new WaitForSeconds(GetComponent<MonsterBehavior>().stat.attackSO.delay);
        while (!stop)
        {
            yield return delay;
            CallAttackEvent(0);
            dynamite = Instantiate(Dynamite_Prefab);
            dynamite.SetActive(false);
            dynamite_Script = dynamite.GetComponent<DynamiteScript>();
            dynamite_Script.targetPos = target.transform;
            dynamite.transform.position = transform.position;
            dynamite.SetActive(true);
        }
    }
}
