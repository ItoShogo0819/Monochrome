using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("AudioSources")]
    public AudioSource BGMSource;
    public AudioSource SESource;

    [Header("���ʐݒ�")]
    [Range(0f, 1f)] public float BGMVolume = 1f;
    [Range(0f, 1f)] public float SEVolume = 1f;

    void Awake()
    {
        if (Instance == null)                  // �V���O���g��������
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);   // �V�[���ׂ��Ŕj������Ȃ�
        }
        else
        {
            Destroy(gameObject);             // ���ɑ��݂���ꍇ�͔j��
        }
    }

    public void PlayBGM(AudioClip clip, bool loop = true)
    {
        BGMSource.clip = clip;               // �N���b�v�Z�b�g
        BGMSource.loop = loop;               // ���[�v�ݒ�
        BGMSource.volume = BGMVolume;        // ���ʐݒ�
        BGMSource.Play();                    // �Đ�
    }

    public void StopBGM()
    {
        BGMSource.Stop();                    // ��~
        BGMSource.clip = null;               // �N���b�v�N���A
    }

    public void PlaySE(AudioClip clip)
    {
        SESource.volume = SEVolume;          // ���ʐݒ�
        SESource.PlayOneShot(clip);          // ���ʉ��Đ�
    }

    public void SetBGMVol(float volume)
    {
        BGMVolume = volume;
        BGMSource.volume = BGMVolume;        // BGM���ʔ��f
    }

    public void SetSEVol(float volume)
    {
        SEVolume = volume;                   // SE���ʔ��f
    }
}
