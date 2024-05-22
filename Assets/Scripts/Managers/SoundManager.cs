using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip introBGM;
    [SerializeField] private AudioClip tutorialBGM;
    [SerializeField] private AudioClip mainBGM;
    [SerializeField] private AudioClip endBGM;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = this.GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ChangeBGM("IntroScene");
    }

    public void ChangeBGM(string sceneName)
    {
        //Change BGM by sceneName
        switch (sceneName)
        {
            case "IntroScene":
                audioSource.clip = introBGM;
                break;
            case "TutorialScene":
                audioSource.clip = tutorialBGM;
                break;
            case "MainScene":
                audioSource.clip = mainBGM;
                break;
            case "EndScene":
                audioSource.clip = endBGM;
                break;
        }

        audioSource.Play();
    }
}
