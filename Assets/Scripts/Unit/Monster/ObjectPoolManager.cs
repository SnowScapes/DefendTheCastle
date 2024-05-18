using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolManager : MonoBehaviour
{
    public IObjectPool<GameObject> InitPool(GameObject go)
    {
        IObjectPool<GameObject> pool = new ObjectPool<GameObject>(() => CreateMonster(go), GetMonster, ReleaseMonster, DestroyMonster, maxSize: 20);
        return pool;       
    }

    private void DestroyMonster(GameObject pool)
    {
        Destroy(pool);
    }

    private void ReleaseMonster(GameObject pool)
    {
        pool.SetActive(false);
    }

    public void GetMonster(GameObject pool)
    {
        pool.SetActive(true);
    }

    private GameObject CreateMonster(GameObject pool)
    {
        GameObject go = Instantiate(pool);
        //TODO 받아넣기
        return go;
    }
}
