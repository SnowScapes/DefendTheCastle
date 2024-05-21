using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private LayerMask levelCollisionLayer;
    public ProjObjectPool pool;
    private Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;
    private TrailRenderer trailRenderer;
    public InputController playerController;
    public PlayerStat stat;
    private AttackSO attackData;
    private float currentDuration;
    private Vector2 direction;
    private bool isReady;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        trailRenderer = GetComponent<TrailRenderer>();
    }

    private void Start()
    {
        stat = playerController.Stats;
        attackData = stat.attackSO;
    }

    private void Update()
    {
        if(!isReady)
        {
            return;
        }

        currentDuration += Time.deltaTime;

        if(currentDuration > stat.duration)
        {
            DestroyProjectile();

        }
        rigidbody.velocity = direction * stat.projSpeed;
    }

    private void DestroyProjectile()
    {
        gameObject.SetActive(false);
        pool.ReleaseProjPool(0, gameObject);
    }

    public void InitializeAttack(Vector2 direction)
    {
        //this.attackData = attackData;
        this.direction = direction;

        UpdateProjectileSprite();
        trailRenderer.Clear();
        currentDuration = 0;
        spriteRenderer.color = stat.projectileColor;

        transform.right = this.direction;

        isReady = true;
    }

    private void UpdateProjectileSprite()
    {
        transform.localScale = Vector3.one * stat.size;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (IsLayerMatched(levelCollisionLayer.value,collision.gameObject.layer))
        {
            Vector2 destroyPosition = collision.ClosestPoint(transform.position) - direction * 0.2f;
            DestroyProjectile();
            

        }
        else if(IsLayerMatched(attackData.target.value,collision.gameObject.layer))
        {
            collision.GetComponent<MonsterHealthManager>().DamageHandler(stat.atk);
            DestroyProjectile();
        }
    }
    
    private bool IsLayerMatched(int value, int layer)
    {
        return value == (value | 1 << layer);
    }
}