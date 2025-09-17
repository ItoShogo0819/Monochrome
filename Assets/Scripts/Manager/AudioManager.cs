using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("AudioSources")]
    public AudioSource BGMSource;
    public AudioSource SESource;

    [Header("âπó ê›íË")]
    [Range(0f, 1f)] public float BGMVolume = 1f;
    [Range(0f, 1f)] public float SEVolume = 1f;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayBGM(AudioClip clip,bool loop = true)
    {
        BGMSource.clip = clip;
        BGMSource.loop = loop;
        BGMSource.volume = BGMVolume;
        BGMSource.Play();
    }

    public void StopBGM()
    {
        BGMSource.Stop();
        BGMSource.clip = null;
    }

    public void PlaySE(AudioClip clip)
    {
        SESource.volume = SEVolume;
        SESource.PlayOneShot(clip);
    }

    public void SetBGMVol(float volume)
    {
        BGMVolume = volume;
        BGMSource.volume = BGMVolume;
    }

    public void SetSEVol(float volume)
    {
        SEVolume = volume;
    }
}
