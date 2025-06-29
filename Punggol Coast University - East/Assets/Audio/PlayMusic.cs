using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayMusic : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // float timer = 3f; test works
    public string musicTrack;
    public bool loop;
    void OnEnable()
    {
        AudioManager.Instance.PlayBGM(musicTrack);
        AudioManager.Instance.bgmAudioSource.loop = loop;
    }

    /*void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            AudioManager.Instance.PlaySFX("paper");
            AudioManager.Instance.PlaySFX("table_hit");
            timer = 3f;
        }
    }*/
}