using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioData", menuName = "Game/AudioData")]
public class AudioData : ScriptableObject
{
    [System.Serializable]
    public class AudioEntry
    {
        public string key;   //音效名字       
        public AudioClip clip;   //具体资源    
    }

    public AudioEntry[] entries;

    public AudioClip GetClip(string key)
    {
        foreach (var e in entries)
            if (e.key == key)
                return e.clip;

        Debug.LogWarning($"没有找到：{key}");
        return null;
    }
}
