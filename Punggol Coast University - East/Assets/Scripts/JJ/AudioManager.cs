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
    public AudioAssets SFX;

    AudioSource audioSource; // assignment not required

    void Awake()
    {
        DontDestroyOnLoad(this);

        if (AudioManager.instance == null)
        {
            AudioManager.instance = this;
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.loop = true;
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
                audioSource.PlayOneShot(audioData.clip);
                Debug.Log("hssssssst");
            }
        }
        if (!found)
        {
            Debug.Log("String not found!");
        }
    }

    public void StopSFX()
    {
        //todo
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
                audioSource.clip = audioData.clip;
                audioSource.Play();
            }
        }
        if (!found)
        {
            Debug.Log("String not found!");
        }
    }

    public void StopBGM()
    {
        audioSource.Stop();
    }
}
