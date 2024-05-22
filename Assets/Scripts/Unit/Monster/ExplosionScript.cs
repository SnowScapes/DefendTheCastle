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
        switch (other.gameObject.layer)
        {
            case 11: GameManager.instance.playerStat.DamageHandler(power);
                break;
            case 12: other.gameObject.GetComponentInParent<Castle>().OnDamaged(power);
                break;
        }
    }

    IEnumerator delay()
    {
        source.PlayOneShot(bombClip);
        yield return new WaitForSeconds(0.91f);
        Destroy(gameObject);
    }
}
