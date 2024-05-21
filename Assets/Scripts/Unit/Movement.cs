using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private InputController controller;
    private Rigidbody2D movementRigidbody;
    private PlayerStat playerStatsHandler;

    private Vector2 movementDirection = Vector2.zero;
    private Vector2 knockback = Vector2.zero;
    private float knockbackDuration = 0.0f;

    private void Awake()
    {
        controller = GetComponent<InputController>();
        movementRigidbody = GetComponent<Rigidbody2D>();
        playerStatsHandler = controller.Stats;
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
        if (knockbackDuration > 0.0f)
        {
            knockbackDuration -= Time.fixedDeltaTime;
        }
    }
    public void ApplyKnockback(Transform other, float power, float duration)
    {
        knockbackDuration = duration;
        knockback = -(other.position - transform.position).normalized * power;
    }
    private void ApplyMovement(Vector2 direction)
    {
        direction *= playerStatsHandler.moveSpeed;
        if (knockbackDuration > 0.0f)
        {
            direction += knockback;
        }
        movementRigidbody.velocity = direction;
    }

}
