using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class MonsterBehavior : BehaviorController
{
    [SerializeField] private Transform _transform;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private MonsterSpawner spawnmanager;
    [SerializeField] internal Spawn spawnPoint;

    private IEnumerator move;
    private Queue<Vector2> rallyPoint = new Queue<Vector2>();
    private bool arrived = false;

    protected virtual void Awake()
    {
        spawnmanager = GameObject.Find("SpawnManager").GetComponent<MonsterSpawner>();
        _rigidbody = this.GetComponent<Rigidbody2D>();
        _transform = this.GetComponent<Transform>();
    }

    protected virtual void Start()
    {
        SetRallyPos();
        OnMoveEvent += WalkTo;
        move = moveCoroutine();
        StartCoroutine(move);
    }

    private void SetRallyPos()
    {
        switch (spawnPoint)
        {
            case Spawn.Left:
                queueRally(spawnmanager.Rally_Left);
                break;
            case Spawn.Center: 
                queueRally(spawnmanager.Rally_Center);
                break;
            case Spawn.Right: 
                queueRally(spawnmanager.Rally_Right);
                break;
        }
    }

    private void queueRally(List<Transform> rallyPos)
    {
        for (int i = 0; i < rallyPos.Count; i++)
        {
            float rallypos_x = Random.Range(rallyPos[i].position.x - 0.5f, rallyPos[i].position.x + 0.5f);
            float rallypos_y = Random.Range(rallyPos[i].position.y - 0.5f, rallyPos[i].position.y + 0.5f);
            rallyPoint.Enqueue(new Vector2(rallypos_x,rallypos_y));
        }
    }
    
    private void WalkTo(Vector2 destination)
    {
        // 추후에 정보에서 속도 불러오기
        _rigidbody.position = Vector2.MoveTowards(_rigidbody.position, destination, 0.01f);
        if ((Vector2)_rigidbody.position == destination)
            arrived = true;
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StopCoroutine(move);
        }
    }

    protected void OnTriggerExit2D(Collider2D other)
    {
        StartCoroutine(move);
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
