using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingFade : MonoBehaviour
{
    [SerializeField] private Image LoadingBoard;
    [SerializeField] private Text LoadingText;

    private void Start()
    {
        StartCoroutine(Fade());
    }

    private IEnumerator Fade()
    {
        yield return new WaitForSeconds(7f);
        float effectTime = 3f;
        float elapsedTime = 0;

        Color imageColor = LoadingBoard.color;
        Color textColor = LoadingText.color;
        
        while (elapsedTime < effectTime)
        {
            elapsedTime += Time.deltaTime;
            imageColor.a = Mathf.Clamp01(1 - (elapsedTime / effectTime));
            textColor.a = Mathf.Clamp01(1 - (elapsedTime / effectTime));
            LoadingBoard.color = imageColor;
            LoadingText.color = textColor;
            yield return null;
        }
        
        LoadingBoard.gameObject.SetActive(false);
    }
}
