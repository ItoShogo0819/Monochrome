using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("AudioSources")]
    public AudioSource BGMSource;
    public AudioSource SESource;

    [Header("音量設定")]
    [Range(0f, 1f)] public float BGMVolume = 1f;
    [Range(0f, 1f)] public float SEVolume = 1f;

    void Awake()
    {
        if (Instance == null)                  // シングルトン初期化
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);   // シーン跨ぎで破棄されない
        }
        else
        {
            Destroy(gameObject);             // 既に存在する場合は破棄
        }
    }

    public void PlayBGM(AudioClip clip, bool loop = true)
    {
        BGMSource.clip = clip;               // クリップセット
        BGMSource.loop = loop;               // ループ設定
        BGMSource.volume = BGMVolume;        // 音量設定
        BGMSource.Play();                    // 再生
    }

    public void StopBGM()
    {
        BGMSource.Stop();                    // 停止
        BGMSource.clip = null;               // クリップクリア
    }

    public void PlaySE(AudioClip clip)
    {
        SESource.volume = SEVolume;          // 音量設定
        SESource.PlayOneShot(clip);          // 効果音再生
    }

    public void SetBGMVol(float volume)
    {
        BGMVolume = volume;
        BGMSource.volume = BGMVolume;        // BGM音量反映
    }

    public void SetSEVol(float volume)
    {
        SEVolume = volume;                   // SE音量反映
    }
}
