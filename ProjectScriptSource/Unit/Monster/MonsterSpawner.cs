using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class MonsterSpawner : Spawner
{
    [SerializeField]
    public Dictionary<Define.eMonsterType, IObjectPool<GameObject>> dicMonsterPool = new Dictionary<Define.eMonsterType, IObjectPool<GameObject>>();
    [SerializeField]
    private ItemSpawner itemSpawner;
    [SerializeField]
    private GameObject[] spawnerLocation;

    private MonsterBehavior monsterController;

    public List<Transform> Rally_Left;
    public List<Transform> Rally_Center;
    public List<Transform> Rally_Right;

    private void Awake()
    {
        itemSpawner = GetComponent<ItemSpawner>();   
    }

    protected override void Start()
    {
        base.Start();  
    }

    protected override void FilledPool()
    {
        for (int i = 0; i < objPrefab.Length; i++)
        {
            DefaultItemCount = GameManager.instance.LevelInfo.levelList[4].get((Define.eMonsterType)i);
            dicMonsterPool[(Define.eMonsterType)i] = creator.InitPool(objPrefab[i], DefaultItemCount);
            //초기 ?�???�소
            Summon((Define.eMonsterType)i, DefaultItemCount, spawnerLocation[0].transform, 0);
        }
    }

    //미리?�성
    private void Summon(Define.eMonsterType type, int count, Transform tr, int spawnLocation)
    {
        List<GameObject> pools = new List<GameObject>();
        pools.Capacity = count;
        for (int i = 0; i < count; i++)
        {
            GameObject go = dicMonsterPool[type].Get();
            Init(go, tr, spawnLocation);
            pools.Add(go);
        }

        foreach (var pool in pools)
        {
            ReleaseMonsterPool(type, pool);
        }
    }

    //몬스???�환
    public void GetMonsters(Define.eMonsterType type, int spawnLocation)
    {
        GameObject go = dicMonsterPool[type].Get();
        go.SetActive(false);
        monsterController = go.GetComponent<MonsterBehavior>();
        monsterController.spawnPoint = (Spawn)spawnLocation;
        switch ((Spawn)spawnLocation)
        {
            case Spawn.Left:
                go.GetComponentInChildren<SpriteRenderer>().flipX = false;
                monsterController.queueRally(Rally_Left);
                break;
            case Spawn.Center:
                go.GetComponentInChildren<SpriteRenderer>().flipX = false;
                monsterController.queueRally(Rally_Center);
                break;
            case Spawn.Right:
                go.GetComponentInChildren<SpriteRenderer>().flipX = true;
                monsterController.queueRally(Rally_Right);
                break;
        }
        go.transform.position = spawnerLocation[spawnLocation].transform.position;
        go.transform.SetParent(poolBox.transform);
        go.SetActive(true);
    }

    public void Init(GameObject go, Transform tr, int spawnLocation)
    {
        go.transform.position = tr.position;
        go.transform.SetParent(poolBox.transform);
        go.GetComponent<MonsterHealthManager>().itemSpawner = itemSpawner;
        go.GetComponent<MonsterBehavior>().spawnPoint = (Spawn)spawnLocation;

        switch ((Spawn)spawnLocation)
        {
            case Spawn.Left:
                go.GetComponent<MonsterBehavior>().queueRally(Rally_Left);
                break;
            case Spawn.Center:
                go.GetComponent<MonsterBehavior>().queueRally(Rally_Center);
                break;
            case Spawn.Right:
                go.GetComponent<MonsterBehavior>().queueRally(Rally_Right);
                break;
        }
    }

    //몬스???�제
    public void ReleaseMonsterPool(Define.eMonsterType type, GameObject go)
    {
        dicMonsterPool[type].Release(go);
    }
}
