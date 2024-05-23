using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinShop : MonoBehaviour
{
    [SerializeField]
    private GameObject StoreCanvas;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StoreCanvas.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ContinueGame()
    {
        StoreCanvas.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
