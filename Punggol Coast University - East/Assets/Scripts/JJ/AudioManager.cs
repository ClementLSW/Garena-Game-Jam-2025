using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance
    {
        get { return instance; }
    }

    public AudioAssets BGM; // required manual assignment
    public AudioAssets SFX; // required manual assignment

    AudioSource bgmAudioSource; // assignment not required
    AudioSource sfxAudioSource; // assignment not required

    void Awake()
    {
        DontDestroyOnLoad(this);

        if (AudioManager.instance == null)
        {
            AudioManager.instance = this;

            bgmAudioSource = new GameObject("bgmAudioSource", typeof(AudioSource)).GetComponent<AudioSource>();
            bgmAudioSource.transform.SetParent(transform);
            bgmAudioSource.loop = true;

            sfxAudioSource = new GameObject("sfxAudioSource", typeof(AudioSource)).GetComponent<AudioSource>();
            sfxAudioSource.transform.SetParent(transform);
        }

        else
        {
            Debug.LogWarning("Duplicate AudioManager found! Destroying this gameObject.");
            Destroy(gameObject);
        }
    }

    public void PlaySFX(string name)
    {
        bool found = false;
        foreach (AudioAssets.AudioData audioData in SFX.audioClips)
        {
            if (name == audioData.name)
            {
                found = true;
                sfxAudioSource.PlayOneShot(audioData.clip);
            }
        }
        if (!found)
        {
            Debug.Log("String not found!");
        }
    }

    public void StopSFX()
    {
        sfxAudioSource.Stop();
    }

    public void PlayBGM(string name)
    {
        StopBGM();
        bool found = false;
        foreach (AudioAssets.AudioData audioData in BGM.audioClips)
        {
            if (name == audioData.name)
            {
                found = true;
                bgmAudioSource.clip = audioData.clip;
                bgmAudioSource.Play();
            }
        }
        if (!found)
        {
            Debug.Log("String not found!");
        }
    }

    public void StopBGM()
    {
        bgmAudioSource.Stop();
    }
}
