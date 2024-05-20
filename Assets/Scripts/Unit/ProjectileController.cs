using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private LayerMask levelCollisionLayer;

    private Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;
    private TrailRenderer trailRenderer;
    public InputController playerController;
    public PlayerStat stat;
    private AttackSO attackData;
    private float currentDuration;
    private Vector2 direction;
    private bool isReady;
    private bool fxOnDestroy = true;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        trailRenderer = GetComponent<TrailRenderer>();
    }

    private void Start()
    {
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
            DestroyProjectile(transform.position, false);
        }
        rigidbody.velocity = direction * stat.projSpeed;
    }

    private void DestroyProjectile(Vector3 position, bool createFx)
    {
        if(createFx)
        {
            // Todo : 파티클 시스템
        }
        gameObject.SetActive(false);
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
        if(IsLayerMatched(levelCollisionLayer.value,collision.gameObject.layer))
        {
            Vector2 destroyPosition = collision.ClosestPoint(transform.position) - direction * 0.2f;
            DestroyProjectile(destroyPosition, fxOnDestroy);
        }
        else if(IsLayerMatched(attackData.target.value,collision.gameObject.layer))
        {
            playerController.OnAttackEvent += collision.GetComponent<MonsterHealthManager>().DamageHandler;
            // Todo : 데미지 주기
            DestroyProjectile(collision.ClosestPoint(transform.position), fxOnDestroy);
        }
    }
    
    private bool IsLayerMatched(int value, int layer)
    {
        return value == (value | 1 << layer);
    }
}