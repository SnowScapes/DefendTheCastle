using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private BehaviorController controller;
    private Rigidbody2D movementRigidbody;
    private PlayerStatsHandler playerStatsHandler;

    private Vector2 movementDirection = Vector2.zero;

    private void Awake()
    {
        controller = GetComponent<BehaviorController>();
        movementRigidbody = GetComponent<Rigidbody2D>();
        playerStatsHandler = GetComponent<PlayerStatsHandler>();
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
    }

    private void Move(Vector2 direction)
    {
        movementDirection = direction;
    }

    private void FixedUpdate()
    {
        ApplyMovement(movementDirection);
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction *= playerStatsHandler.CurrentStat.moveSpeed;
        movementRigidbody.velocity = direction;
    }

}
