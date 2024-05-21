using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip bombClip;
    public int power { get; set; }
    
    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(delay());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 11)
        {
            Debug.Log("player damaged " + power);
            other.gameObject.GetComponent<InputController>().Stats.DamageHandler(power);
        }
    }

    IEnumerator delay()
    {
        source.PlayOneShot(bombClip);
        yield return new WaitForSeconds(0.91f);
        Destroy(gameObject);
    }
}
