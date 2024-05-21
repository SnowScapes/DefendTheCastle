using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Spawner spawner;
    [SerializeField]
    private Define.eItmeType type;
    [SerializeField]
    private int amount;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnBecameVisible()
    {
        if (animator != null) 
        {
            animator.SetTrigger("IsReset");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
