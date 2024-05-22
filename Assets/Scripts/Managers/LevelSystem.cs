using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelSystem : MonoBehaviour
{
    [SerializeField] private MonsterSpawner _monsterSpawner;
    
    private List<int> RandomPool = new List<int>();
    
    private int RandomSpawn;
    private int Torch;
    private int Tnt;
    private int Barrel;

    private void Start()
    {
        RandomPool.Capacity = 10;
        StartCoroutine(StartLevel(21, 6, 3, 1f));
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
