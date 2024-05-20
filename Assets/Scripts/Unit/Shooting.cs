using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class Shooting : MonoBehaviour
{
    private BehaviorController controller;
    [SerializeField] private Transform projectileSpawnPosition;
    private Vector2 aimDirection = Vector2.right;

    private ProjObjectPool objectPool;

    public GameObject ProjPrefab; // ≈ıªÁ√º «¡∏Æ∆’ ( »≠ªÏ, ∆¯≈∫ )
    private void Awake()
    {
        controller = GetComponent<BehaviorController>();
        objectPool = GetComponent<ProjObjectPool>();
    }

    private void Start()
    {
        controller.OnAttackEvent += OnShoot;
        controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 direction)
    {
        aimDirection = direction;
    }


    private void OnShoot(AttackSO attackSO)
    {
        RangedAttackSO rangedAttackSO = attackSO as RangedAttackSO;
        if(rangedAttackSO == null) return;

        float projectilesAngleSpace = rangedAttackSO.multipleProjectilesAngle;
        int numberOfPorjectilesPerShot = rangedAttackSO.numberOfProjectilesPerShot;

        float minAngle = -(numberOfPorjectilesPerShot / 2f) * projectilesAngleSpace + 0.5f * rangedAttackSO.multipleProjectilesAngle;

        for(int i = 0; i< numberOfPorjectilesPerShot; i++)
        {
            float angle = minAngle + i * projectilesAngleSpace;
            float randomSpread = Random.Range(-rangedAttackSO.spread, rangedAttackSO.spread);
            angle += randomSpread;
            CreateProjectile(rangedAttackSO, angle);
        }

    }

    private void CreateProjectile(RangedAttackSO rangedAttackSO , float angle)
    {
        Define.eProjName type;
        if (rangedAttackSO.bulletName == "Arrow")
            type = Define.eProjName.Arrow;
        else if (rangedAttackSO.bulletName == "Tnt")
            type = Define.eProjName.Tnt;
        else
            return;

        GameObject obj = objectPool.dicProjPool[type].Get();

        obj.transform.position = projectileSpawnPosition.position;
        ProjectileController attackController = obj.GetComponent<ProjectileController>();
        attackController.InitializeAttack(RotateVector2(aimDirection,angle),rangedAttackSO);
    }

    private static Vector2 RotateVector2(Vector2 v, float angle)
    {
        return Quaternion.Euler(0f, 0f, angle) * v;
    }
}
