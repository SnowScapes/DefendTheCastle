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
    [SerializeField] internal MonsterStat stat;

    protected IEnumerator move;
    protected IEnumerator attack;
    private Queue<Vector2> rallyPoint = new Queue<Vector2>();
    private bool arrived = false;

    protected virtual void Awake()
    {
        _rigidbody = this.GetComponent<Rigidbody2D>();
        _transform = this.GetComponent<Transform>();
    }

    protected virtual void Start()
    {
        OnMoveEvent += WalkTo;
        move = moveCoroutine();
        attack = attackCoroutine();
        StartCoroutine(move);
    }

    public void queueRally(List<Transform> rallyPos)
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
        _rigidbody.position = Vector2.MoveTowards(_rigidbody.position, destination, Time.deltaTime);
        if ((Vector2)_rigidbody.position == destination)
        {
            arrived = true;
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.layer)
        {
            case 11: Debug.Log("Attack Player");
                StopCoroutine(move);
                OnAttackEvent += other.gameObject.GetComponent<InputController>().Stats.DamageHandler;
                StartCoroutine(attack);
                break;
            case 12: Debug.Log("Attack Castle");
                StopCoroutine(move);
                StartCoroutine(attack);
                break;
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StopCoroutine(attack);
            OnAttackEvent -= other.gameObject.GetComponent<InputController>().Stats.DamageHandler;
            StartCoroutine(move);
            Debug.Log("Goto Castle Again");
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
                yield return null;
                CallMoveEvent(_destination);
            }
            arrived = false;
        }
    }

    protected virtual IEnumerator attackCoroutine()
    {
        WaitForSeconds delay = new WaitForSeconds(stat.attackSO.delay);
        while (true)
        {
            CallAttackEvent(stat.atk);
            yield return delay;
        }
    }
}
