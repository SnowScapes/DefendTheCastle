using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    public Dictionary<Define.eMonsterType, IObjectPool<GameObject>> dicMonsterPool = new Dictionary<Define.eMonsterType, IObjectPool<GameObject>>();

    [SerializeField]
    private ObjectPoolManager creator;
    [SerializeField]
    private GameObject[] objMonster;
    [SerializeField]
    private GameObject[] spawnerLocation;
    [SerializeField]
    private int MaxMonsterCount = 5;

    public List<Transform> Rally_Left;
    public List<Transform> Rally_Center;
    public List<Transform> Rally_Right;
    private void Awake()
    {
        creator = GetComponent<ObjectPoolManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        FilledMonsterPool();
        StartCoroutine(StartGame());      
    }

    //?�시??
    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(GetMonsters(Define.eMonsterType.Torch, 5, spawnerLocation[1].transform, 1.0f));
        yield return null;
    }

    private void FilledMonsterPool()
    {
        for (int i = 0; i < objMonster.Length; i++)
        {
            dicMonsterPool[(Define.eMonsterType)i] = creator.InitPool(objMonster[i]);
            //초기 ?�???�소
            Summon((Define.eMonsterType)i, MaxMonsterCount, spawnerLocation[1].transform, 1);
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
            go.transform.position = tr.position;
            go.transform.SetParent(transform);
            switch (type)
            {
                case Define.eMonsterType.Torch: go.GetComponent<TorchBehavior>().spawnPoint = (Spawn)spawnLocation;
                    break;
                case Define.eMonsterType.Tnt: go.GetComponent<TNTBehavior>().spawnPoint = (Spawn)spawnLocation;
                    break;
                case Define.eMonsterType.Barrel: go.GetComponent<BarrelBehavior>().spawnPoint = (Spawn)spawnLocation;
                    break;
            }
            pools.Add(go);
        }

        foreach (var pool in pools)
        {
            ReleaseMonsterPool(type, pool);
        }
    }
    
    //몬스???�환
    public IEnumerator GetMonsters(Define.eMonsterType type, int count, Transform tr, float delayTime)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject go = dicMonsterPool[type].Get();
            go.transform.position = tr.position;
            go.transform.SetParent(transform);
            yield return new WaitForSeconds(delayTime);
        }
    }

    //몬스???�제
    public void ReleaseMonsterPool(Define.eMonsterType type, GameObject go)
    {
        dicMonsterPool[type].Release(go);
    }
}
