using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ProjObjectPool : Spawner
{
    [SerializeField] public Dictionary<Define.eProjName, IObjectPool<GameObject>> dicProjPool = new Dictionary<Define.eProjName, IObjectPool<GameObject>>();
    [SerializeField] private int MaxProjCount = 20;
    InputController inputController;

    private void Awake()
    {
        inputController = GetComponent<InputController>();
    }
    protected override void Start()
    {
        base.Start();
    }

    protected override void FilledPool()
    {
        for (int i = 0; i < objPrefab.Length; i++)
        {
            dicProjPool[(Define.eProjName)i] = creator.InitPool(objPrefab[i], MaxProjCount);

            Summon((Define.eProjName)i, MaxProjCount);
        }
    }

    private void Summon(Define.eProjName type, int count)
    {
        List<GameObject> pools = new List<GameObject>();
        pools.Capacity = count;
        for (int i = 0; i < count; i++)
        {
            GameObject go = dicProjPool[type].Get();
            go.transform.SetParent(poolBox.transform);
            ProjectileController proj = go.GetComponent<ProjectileController>();
            proj.playerController = inputController;
            proj.pool = this;
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
