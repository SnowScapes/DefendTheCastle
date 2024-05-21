using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    
    public Spawner spawner;
    public Define.eItmeType type { get; private set; }
    public int amount { get; private set; }
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

    public void Init(Define.eItmeType itemType, int _amount)
    {
        type = itemType;
        amount = _amount;
        GetItemType(itemType);
    }

    public int GetItemType(Define.eItmeType _type)
    {
        switch (_type) 
        {
            case Define.eItmeType.Wood:

                animator.SetTrigger("Wood");
                amount = 5;
                return 0;
            case Define.eItmeType.Gold:
                animator.SetTrigger("Gold");
                return 1;
            case Define.eItmeType.Meat:
                amount = 5;
                animator.SetTrigger("Meat");
                return 2;
            case Define.eItmeType.Mushroom:
                animator.SetTrigger("Mushroom");
                return 3;
            default:
                return -1;
        }
    }


}
