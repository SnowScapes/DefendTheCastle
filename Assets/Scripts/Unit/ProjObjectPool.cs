using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ProjObjectPool : MonoBehaviour
{
    [SerializeField] public Dictionary<Define.eProjName, IObjectPool<GameObject>> dicProjPool = new Dictionary<Define.eProjName, IObjectPool<GameObject>>();
    [SerializeField]  ObjectPoolManager creator;
    public static ProjObjectPool instance;
    [SerializeField] private GameObject[] objProj;
    [SerializeField] private int DefaultMonsterCount = 20;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        FilledProjPool();
    }

    private void FilledProjPool()
    {
        for (int i = 0; i < objProj.Length; i++)
        {
            dicProjPool[(Define.eProjName)i] = creator.InitPool(objProj[i]);

            Summon((Define.eProjName)i, DefaultMonsterCount);
        }
    }

    private void Summon(Define.eProjName type, int count)
    {
        List<GameObject> pools = new List<GameObject>();
        pools.Capacity = count;
        for (int i = 0; i < count; i++)
        {
            GameObject go = dicProjPool[type].Get();
            go.transform.SetParent(creator.transform);
            go.GetComponent<ProjectileController>().playerController = this.GetComponent<InputController>();
            go.GetComponent<ProjectileController>().stat = this.GetComponent<InputController>().Stats;
            pools.Add(go);
        }

        foreach (var pool in pools)
        {
            ReleaseProjPool(type, pool);
        }
    }

    public void ReleaseProjPool(Define.eProjName type, GameObject go)
    {
        dicProjPool[type].Release(go);
    }
}
