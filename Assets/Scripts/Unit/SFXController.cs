using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    [SerializeField] protected AudioSource source;
    [SerializeField] protected AudioClip sfxClip;

    protected virtual void Awake()
    {
        source = GetComponent<AudioSource>();
    }
}
