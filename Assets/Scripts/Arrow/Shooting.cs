using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class Shooting : MonoBehaviour
{
    private InputController controller;
    [SerializeField]private PlayerStat stat;
    [SerializeField] private Transform projectileSpawnPosition;
    private Vector2 aimDirection = Vector2.right;

    private ProjObjectPool objectPool;

    private void Awake()
    {
        controller = GetComponent<InputController>();
        objectPool = GetComponent<ProjObjectPool>();
    }

    private void Start()
    {
        stat = controller.Stats;
        controller.OnAttackEvent += OnShoot;
        controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 direction)
    {
        aimDirection = direction;
    }


    private void OnShoot(int _)
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        StartCoroutine(DelayShoot());
    }

    IEnumerator DelayShoot()
    {
        yield return new WaitForSeconds(0.5f);
        float projectilesAngleSpace = stat.multipleProjectilesAngle;
        int numberOfPorjectilesPerShot = stat.numberOfProjectilesPerShot;

        float minAngle = -(numberOfPorjectilesPerShot / 2f) * projectilesAngleSpace + 0.5f * stat.multipleProjectilesAngle;

        for(int i = 0; i< numberOfPorjectilesPerShot; i++)
        {
            float angle = minAngle + i * projectilesAngleSpace;
            float randomSpread = Random.Range(-stat.spread, stat.spread);
            angle += randomSpread;
            CreateProjectile(angle);
        }
    }
    private void CreateProjectile(float angle)
    {
        Define.eProjName type;
        if (stat.bulletName == "Arrow")
            type = Define.eProjName.Arrow;
        else if (stat.bulletName == "Tnt")
            type = Define.eProjName.Tnt;
        else
            return;

        GameObject obj = objectPool.dicProjPool[type].Get();
        obj.GetComponent<ProjectileController>().stat = GetComponent<InputController>().Stats;
        //obj.transform.SetParent(objectPool.transform);
        obj.transform.position = projectileSpawnPosition.position;
        ProjectileController attackController = obj.GetComponent<ProjectileController>();
        attackController.InitializeAttack(RotateVector2(aimDirection,angle));
    }

    private static Vector2 RotateVector2(Vector2 v, float angle)
    {
        return Quaternion.Euler(0f, 0f, angle) * v;
    }
}
