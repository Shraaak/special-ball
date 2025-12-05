using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("音频资源表 ")]
    public AudioData audioData;

    //音频资源
    private AudioSource bgmSource;
    private AudioSource sfxSource;

    [Header("音量大小设置")]
    [Range(0, 1)] public float bgmVolume = 1f;
    [Range(0, 1)] public float sfxVolume = 1f;

    private void Awake()
    {
        // 单例设置
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        UpdateVolumes();
    }

    // ======== BGM 播放（使用 key） ========

    public void PlayBGM(string key, bool loop = true)
    {
        AudioClip clip = audioData.GetClip(key);
        if (clip == null) return;

        bgmSource.clip = clip;
        bgmSource.loop = loop;
        bgmSource.volume = bgmVolume;
        bgmSource.Play();
    }

    public void StopBGM()
    {
        bgmSource.Stop();
    }

    // ======== SFX 播放（使用 key） ========

    public void PlaySFX(string key)
    {
        AudioClip clip = audioData.GetClip(key);
        if (clip != null)
        {
            sfxSource.PlayOneShot(clip, sfxVolume);
        }
    }

    // ======== 更新音量 ========

    public void UpdateVolumes()
    {
        bgmSource.volume = bgmVolume;
        sfxSource.volume = sfxVolume;
    }
}