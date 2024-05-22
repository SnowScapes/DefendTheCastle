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
    private GameObject[] spawnerLocation;

    private MonsterBehavior monsterController;

    public List<Transform> Rally_Left;
    public List<Transform> Rally_Center;
    public List<Transform> Rally_Right;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        //StartCoroutine(StartGame());      
    }
    /*
    //?�시??
    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(GetMonsters(Define.eMonsterType.Tnt, 1, spawnerLocation[2].transform, 1.0f));
        yield return null;
    }*/

    protected override void FilledPool()
    {
        for (int i = 0; i < objPrefab.Length; i++)
        {
            DefaultItemCount = GameManager.instance.LevelInfo.levelList[4].get((Define.eMonsterType)i);
            dicMonsterPool[(Define.eMonsterType)i] = creator.InitPool(objPrefab[i], DefaultItemCount);
            //초기 ?�???�소
            Summon((Define.eMonsterType)i, DefaultItemCount, spawnerLocation[0].transform);
        }
    }

    //미리?�성
    private void Summon(Define.eMonsterType type, int count, Transform tr)
    {
        List<GameObject> pools = new List<GameObject>();
        pools.Capacity = count;
        for (int i = 0; i < count; i++)
        {
            GameObject go = dicMonsterPool[type].Get();
            go.transform.position = tr.position;
            go.transform.SetParent(transform);
            
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
            case Spawn.Left: monsterController.queueRally(Rally_Left);
                break;
            case Spawn.Center: monsterController.queueRally(Rally_Center);
                break;
            case Spawn.Right: monsterController.queueRally(Rally_Right);
                break;
        }
        go.transform.position = spawnerLocation[spawnLocation].transform.position;
        go.transform.SetParent(poolBox.transform);
        go.SetActive(true);
    }

    //몬스???�제
    public void ReleaseMonsterPool(Define.eMonsterType type, GameObject go)
    {
        dicMonsterPool[type].Release(go);
    }
}
