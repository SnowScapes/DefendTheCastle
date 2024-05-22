using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelBehavior : MonsterBehavior
{
    [SerializeField] private GameObject explosion_prefab;
    private GameObject explosion;
    private Vector2 size = new Vector2(1.5f, 1.5f);
    
    
    protected override void Awake()
    {
        base.Awake();
        explosion = Instantiate(explosion_prefab);
        explosion.SetActive(false);
    }

    protected override void Start()
    {
        base.Start();
        attack = attackCoroutine();
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 11 || other.gameObject.layer == 12)
        {
            StopCoroutine(move);
            CallAttackEvent(stat.atk);
            StartCoroutine(attack);
        }
    }

    protected override void OnTriggerExit2D(Collider2D other)
    {
        // 기존 MonsterBehavior의 OntriggerExit은 작동하면 안됨.
    }

    protected override IEnumerator attackCoroutine()
    {
        WaitForSeconds delay = new WaitForSeconds(stat.attackSO.delay);
        yield return delay;
        explosion.GetComponent<ExplosionScript>().power = stat.atk;
        explosion.GetComponent<Transform>().localScale = size;
        explosion.GetComponent<Transform>().position = this.transform.position;
        explosion.SetActive(true);
        gameObject.SetActive(false);
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }
    
    protected override void OnDisable()
    {
        base.OnDisable();
    }
}
