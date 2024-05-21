using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{
    Dictionary<int, CastleInfoes> dicCastleLv = new Dictionary<int, CastleInfoes>();
    [SerializeField]
    private CastleInfoes[] _castleInfoes;
    private int castleLv = 0;
    [SerializeField]
    public int currentCastleHp { get; private set; } = 50;
    [SerializeField]
    private int castleMaxHp = 50;

    [SerializeField]
    private GameObject[] burningeffects;
    [SerializeField]
    private GameObject[] explosioneffects;
    [SerializeField]
    private Image hpBar;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < _castleInfoes.Length; i++) 
        {
            dicCastleLv[i] = _castleInfoes[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpgradeCastle(int stat)
    {
        
        int temp = stat - castleMaxHp;
        castleMaxHp = stat;
        currentCastleHp = temp;
        dicCastleLv[castleLv++].castle.SetActive(false);
        dicCastleLv[castleLv].castle.SetActive(true);
        burningeffects = dicCastleLv[castleLv].burningEffect;
    }

    public void RepairCastle(int amount)
    {
        currentCastleHp += amount;
        CheckedState();
    }
    public void OnDamaged(int damage)
    {       
        currentCastleHp -= damage;
        CheckedState();
    }

    [ContextMenu("CheckState")]
    public void CheckedState()
    {
        float percent = (float)currentCastleHp / (float)castleMaxHp;
        hpBar.fillAmount = percent;
        if (percent >= 0.6f)
        {
            Burning(-1);
        }
        else if (percent >= 0.4f)
        {
            Burning(0);
        }
        else if (percent >= 0.2f)
        {
            Burning(1);
        }
        else if (percent > 0)
        {
            Burning(2);
        }
        else
        {

            hpBar.fillAmount = 0;
            StartCoroutine(ExplosionShake(0.1f,2));
            StartCoroutine(OnExplosion());
        }
    }

    private void Burning(int index)
    {
        for(int i = 0; i < burningeffects.Length; i++)
        { 
            if (i <= index)
            {
                burningeffects[i].SetActive(true);
            }
            else
            {
                burningeffects[i].SetActive(false);
            }
        }
    }

    public IEnumerator ExplosionShake(float _amount, float _duration)
    {
        Vector3 originPos = Camera.main.transform.position;
        float timer = 0;
        while (timer <= _duration)
        {
            Camera.main.transform.position = (Vector3)Random.insideUnitCircle * _amount + originPos;

            timer += Time.deltaTime;
            yield return null;
        }
        Camera.main.transform.position = originPos;
        GameManager.instance.GameOver();
    }

    private IEnumerator OnExplosion()
    {
        for(int i = 0;i < explosioneffects.Length;i++) 
        {
            explosioneffects[i].SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }
        dicCastleLv[castleLv].spriteRenderer.sprite = dicCastleLv[castleLv].destroySprite;
    }
}

[System.Serializable]
public class CastleInfoes
{
    public GameObject castle;
    public GameObject[] burningEffect;
    public SpriteRenderer spriteRenderer;
    public Sprite destroySprite;
}