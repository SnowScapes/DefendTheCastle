using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    
    [SerializeField] private Slider MasterVol;
    [SerializeField] private Slider BgmVol;
    [SerializeField] private Slider SfxVol;

    [SerializeField] private Button SaveButton;
    [SerializeField] private Button ExitButton;
    
    private void Start()
    {
        SaveButton.onClick.AddListener(() => saveSetting());
        ExitButton.onClick.AddListener(() => closeWindow());
    }

    // 저장 버튼을 눌렀을 때, 슬라이더의 value를 통해 volume 설정
    private void saveSetting()
    {
        _audioMixer.SetFloat("Master", MasterVol.value);
        _audioMixer.SetFloat("BGM", BgmVol.value);
        _audioMixer.SetFloat("SFX", SfxVol.value);
    }

    // 저장하지 않고 설정창을 닫을 때, 슬라이더를 원위치로 만들기
    private void closeWindow()
    {
        float value; // slider.value는 property라 out에 넣을 수 없어서 만든 변수
        
        _audioMixer.GetFloat("Master", out value);
        MasterVol.value = value;
        _audioMixer.GetFloat("BGM", out value);
        BgmVol.value = value;
        _audioMixer.GetFloat("SFX", out value);
        SfxVol.value = value;
        
        gameObject.SetActive(false);
    }
}
