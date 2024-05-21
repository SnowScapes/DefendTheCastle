using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSFX : SFXController
{
    private MonsterBehavior controller;
    protected override void Awake()
    {
        base.Awake();
        controller = GetComponent<MonsterBehavior>();
    }

    private void Start()
    {
        controller.OnAttackEvent += playSound;
    }

    private void playSound(int _)
    {
        source.PlayOneShot(sfxClip);
    }
}
