using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterBehavior : BehaviorController
{
    [SerializeField] private Transform _transform;

    [SerializeField] private TestSpawnManager spawnmanager;
    [SerializeField] private Spawn spawnPoint;

    private Queue<Vector2> rallyPoint = new Queue<Vector2>();
    private bool arrived = false;

    private void Awake()
    {
        _transform = this.GetComponent<Transform>();
    }

    private void Start()
    {
        SetRallyPos();
        OnMoveEvent += WalkTo;
        StartCoroutine(moveCoroutine());
    }

    private void SetRallyPos()
    {
        switch (spawnPoint)
        {
            case Spawn.Left:
                for (int i = 0; i < spawnmanager.Rally_Left.Count; i++)
                {
                    Vector2 rallypos = new Vector2(spawnmanager.Rally_Left[i].position.x, spawnmanager.Rally_Left[i].position.y);
                    rallyPoint.Enqueue(rallypos);
                    Debug.Log("queue success");
                }
                break;
            case Spawn.Center: 
                for (int i = 0; i < spawnmanager.Rally_Center.Count; i++)
                {
                    Vector2 rallypos = new Vector2(spawnmanager.Rally_Center[i].position.x,
                        spawnmanager.Rally_Center[i].position.y);
                    rallyPoint.Enqueue(rallypos);
                }
                break;
            case Spawn.Right: 
                for (int i = 0; i < spawnmanager.Rally_Right.Count; i++)
                {
                    Vector2 rallypos = new Vector2(spawnmanager.Rally_Right[i].position.x,
                        spawnmanager.Rally_Right[i].position.y);
                    rallyPoint.Enqueue(rallypos);
                }
                break;
        }
    }
    
    private void WalkTo(Vector2 destination)
    {
        // 추후에 정보에서 속도 불러오기
        _transform.position = Vector2.MoveTowards(_transform.position, destination, 0.01f);
        if ((Vector2)_transform.position == destination)
            arrived = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
        }
    }

    IEnumerator moveCoroutine()
    {
        int value = rallyPoint.Count;
        for (int i = 0; i < value; i++)
        {
            Vector2 _destination = rallyPoint.Dequeue();
            while (!arrived)
            {
                CallMoveEvent(_destination);
                yield return null;
            }
            arrived = false;
        }
    }
}
