using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private BehaviorController controller;
    [SerializeField] private Transform projectileSpawnPosition;
    private Vector2 aimDirection = Vector2.right;

    public GameObject ProjPrefab; // ≈ıªÁ√º «¡∏Æ∆’ ( »≠ªÏ, ∆¯≈∫ )
    private void Awake()
    {
        controller = GetComponent<BehaviorController>();
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


    private void OnShoot()
    {
        CreateProjectile();
    }

    private void CreateProjectile()
    {
        Instantiate(ProjPrefab, projectileSpawnPosition.position, Quaternion.identity);
    }
}
