using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    [SerializeField] Slider masterSlider, musicSlider;
    Animator anim, anim2;

    [SerializeField] AudioMixer mixer;

    const string MIXER_MUSIC = "MusicVolume";

    bool open;

    private void Start()
    {
        anim = masterSlider.GetComponent<Animator>();
        anim2 = musicSlider.GetComponent<Animator>();

        if (!PlayerPrefs.HasKey("MasterVolume") || !PlayerPrefs.HasKey("MusicVolume"))
        {
            PlayerPrefs.SetFloat("MasterVolume", 0.8f);
            PlayerPrefs.SetFloat("MusicVolume", 0.8f);
            Load();
        }
        else
        {
            Load();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    public void PlayGame()
    {

    }

    public void TutorialAudio()
    {

    }

    public void Options()
    {
        open = !open;
        if (open)
        {
            anim.Play("SliderOpen", 0, 0.0f);
            anim2.Play("SliderOpen", 0, 0.0f);
        }
        else
        {
            anim.Play("SliderClose", 0, 0.0f);
            anim2.Play("SliderClose", 0, 0.0f);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    
    public void ChangeMaster(float value)
    {
        mixer.SetFloat("MasterVolume", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("MasterVolume", value);
    }


    public void ChangeMusic(float value)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("MusicVolume", value);
    }

    void Load()
    {
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        mixer.SetFloat("MasterVolume", Mathf.Log10(masterSlider.value) * 20);
        mixer.SetFloat("MusicVolume", Mathf.Log10(musicSlider.value) * 20);
    }
}
