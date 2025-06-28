using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioAssets", menuName = "Scriptable Objects/AudioAssets")]
public class AudioAssets : ScriptableObject
{
    [System.Serializable]
    public struct AudioData
    {
        public string name;
        public AudioClip clip;
    }
    public List<AudioData> audioClips = new List<AudioData>();
}
