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
    
    public AudioClip startClip, clickClip;
    AudioSource source;

    public UnityEngine.UI.Button butStart;

    bool open;
    GameObject sound;
    bool playbut;

    private void Start()
    {
        anim = masterSlider.GetComponent<Animator>();
        anim2 = musicSlider.GetComponent<Animator>();
        source = GetComponent<AudioSource>();

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
        if (Input.GetKeyDown(KeyCode.M))
        {
            PlayerPrefs.DeleteAll();
        }
        if (!source.isPlaying && playbut)
        {
            sound.SetActive(true);
            playbut = false;
        }
    }

    public void PlayGame()
    {
        butStart.interactable = false;
        source.PlayOneShot(startClip);
        source.PlayOneShot(clickClip);
        sound = GameObject.Find("Sound");
        sound.SetActive(false);
        playbut = true;
    }

    public void TutorialGame()
    {
        source.PlayOneShot(clickClip);
    }

    public void Options()
    {
        source.PlayOneShot(clickClip);
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
        source.PlayOneShot(clickClip);
        StartCoroutine(Quit());
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
    IEnumerator Quit()
    {
        yield return new WaitForSeconds(1);
        Application.Quit();
    }
}
