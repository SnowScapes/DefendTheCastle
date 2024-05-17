using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AimRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer characterRenderer;
    [SerializeField] private Transform pivot;
    [SerializeField] private GameObject Character;

    private BehaviorController controller;

    private void Awake()
    {
        controller = GetComponent<BehaviorController>();
    }

    private void Start()
    {
        controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 direction)
    {
        Rotation(direction);
    }

    private void Rotation(Vector2 direction)
    { 
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;

        pivot.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
