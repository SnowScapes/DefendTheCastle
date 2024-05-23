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

    [SerializeField]private PlayerStat player;
    [SerializeField]private Castle castle;

    protected IEnumerator move;
    protected IEnumerator attack;
    private Queue<Vector2> rallyPoint = new Queue<Vector2>();
    private bool arrived = false;
    public bool die { get; set; } = false;

    protected virtual void Awake()
    {
        _rigidbody = this.GetComponent<Rigidbody2D>();
        _transform = this.GetComponent<Transform>();
    }

    protected virtual void Start()
    {
        OnMoveEvent += WalkTo;
    }

    public void queueRally(List<Transform> rallyPos)
    {
        rallyPoint.Clear();
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
            case 11:
                StopCoroutine(move);
                player = other.gameObject.GetComponent<InputController>().Stats;
                OnAttackEvent += player.DamageHandler;
                StartCoroutine(attack);
                break;
            case 12:
                StopCoroutine(move);
                castle = other.gameObject.GetComponentInParent<Castle>();
                OnAttackEvent += castle.OnDamaged;
                StartCoroutine(attack);
                break;
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        switch (other.gameObject.layer)
        {
            case 11: StopCoroutine(attack);
                OnAttackEvent -= player.DamageHandler;
                if(!die)
                    StartCoroutine(move);
                break;
            case 12: StopCoroutine(attack);
                OnAttackEvent -= castle.OnDamaged;
                break;
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

    protected virtual void OnEnable()
    {
        stat.InitStatFromSo();
        attack = attackCoroutine();
        move = moveCoroutine();
        StartCoroutine(move);
    }

    protected virtual void OnDisable()
    {
        if (die)
        {
            OnAttackEvent = null;
            StopAllCoroutines();
        }
        die = false;
    }
}