using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayMusic : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // float timer = 3f;
    void Start()
    {
        AudioManager.Instance.PlayBGM("quiz");
    }

    /*void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            AudioManager.Instance.PlayBGM("paper_tear");
            timer = 3f;
        }
    }*/
}
