using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelSystem : MonoBehaviour
{
    public MonsterSpawner _monsterSpawner;
    
    private List<int> RandomPool = new List<int>();
    
    private int RandomSpawn;
    private int Torch;
    private int Tnt;
    private int Barrel;

    public IEnumerator startLevel;
    
    private void Start()
    {
        RandomPool.Capacity = 10;
    }

    public void SetLevel(int level, float spawnDelay)
    {
        spawnDelay = 50f / GameManager.instance.LevelInfo.levelList[level - 1].Total;
        Torch = GameManager.instance.LevelInfo.levelList[level - 1].get(Define.eMonsterType.Torch);
        Tnt = GameManager.instance.LevelInfo.levelList[level - 1].get(Define.eMonsterType.Tnt);
        Barrel = GameManager.instance.LevelInfo.levelList[level - 1].get(Define.eMonsterType.Barrel);
        startLevel = StartLevel(Torch, Tnt, Barrel, spawnDelay);
        StartCoroutine(startLevel);
    }

    IEnumerator StartLevel(int TorchAmount, int TntAmount, int BarrelAmount, float delay)
    {
        WaitForSeconds spawnDelay = new WaitForSeconds(delay);
        
        yield return new WaitForSeconds(3.0f);
        
        AddItemsToPool(RandomPool, TorchAmount, 0);
        AddItemsToPool(RandomPool, TntAmount, 1);
        AddItemsToPool(RandomPool, BarrelAmount, 2);
        ShufflePool(RandomPool);
        
        for (int i = 0; i < RandomPool.Count; i++)
        {
            RandomSpawn = Random.Range(0, 3);
            _monsterSpawner.GetMonsters((Define.eMonsterType)RandomPool[i], RandomSpawn);
            yield return spawnDelay;
        }
    }
    
    void AddItemsToPool(List<int> pool, int count, int value)
    {
        for (int i = 0; i < count; i++)
        {
            pool.Add(value);
        }
    }

    void ShufflePool(List<int> pool)
    {
        for (int i = pool.Count - 1; i > 1; i--)
        {
            int j = Random.Range(0, i + 1);
            (pool[j], pool[i]) = (pool[i], pool[j]);
        }
    }
}
