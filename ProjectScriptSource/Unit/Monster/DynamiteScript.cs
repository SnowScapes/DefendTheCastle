using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamiteScript : MonoBehaviour
{
    [SerializeField] private GameObject explosion_prefab;

    private GameObject explosion;
    [SerializeField]private RangedAttackSO TntSO;
    public Transform targetPos { get; set; }

    private IEnumerator _throw;

    private void Start()
    {
        _throw = throwDynamite();
        StartCoroutine(_throw);
    }

    private IEnumerator throwDynamite()
    {
        Vector3 direction = targetPos.position - transform.position;
        direction = direction.normalized;
        while (true)
        {
            transform.position += direction * Time.deltaTime * TntSO.projSpeed;
            yield return null;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.layer)
        {
            case 7 : DestroyDynamite();
                break;
            case 11 : DynamiteExplosion(other.transform);  DestroyDynamite();
                break;
            case 12 : DynamiteExplosion(other.transform); DestroyDynamite(); 
                break;
        }
    }

    private void DestroyDynamite()
    {
        StopCoroutine(_throw);
        Destroy(gameObject);
    }

    private void DynamiteExplosion(Transform target)
    {
        explosion = Instantiate(explosion_prefab);
        explosion.SetActive(false);
        explosion.transform.position = target.position;
        explosion.GetComponent<ExplosionScript>().power = TntSO.power;
        explosion.SetActive(true);
    }
}
