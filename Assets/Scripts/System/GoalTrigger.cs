using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GoalTrigger : MonoBehaviour
{
    public TimerUI Timer;
    public FadeController Fade;
    public string NextSceneName;

    private bool _goalTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (_goalTriggered) return;       // ���ɃS�[���ς݂Ȃ疳��

        // �v���C���[������
        if (other.CompareTag("Player"))
        {
            _goalTriggered = true;

            float finalTime = Timer.GetElapsedTime(); // �o�ߎ��Ԏ擾
            Timer.StopTimer();                        // �^�C�}�[��~
            Debug.Log("�N���A�^�C��: " + finalTime.ToString("F2") + "�b");

            float bestTime = PlayerPrefs.GetFloat("BestTime", 9999f);  // �����x�X�g�^�C��
            if (finalTime < bestTime)                                   // �V�L�^�Ȃ�ۑ�
            {
                PlayerPrefs.SetFloat("BestTime", finalTime);
                Debug.Log("�V�L�^�I�ۑ����܂����B");
            }

            StartCoroutine(FadeOutAndLoad());  // �t�F�[�h�A�E�g���V�[���؂�ւ�
        }
    }

    private IEnumerator FadeOutAndLoad()
    {
        if (Fade != null)                     // �t�F�[�h������ꍇ
        {
            yield return StartCoroutine(Fade.FadeOut(LoadNextScene));  // �t�F�[�h��Ƀ��[�h
        }
        else
        {
            LoadNextScene();                  // �t�F�[�h�Ȃ��Ń��[�h
        }
    }

    private void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(NextSceneName))  // �J�ڐ悪�ݒ肳��Ă���ꍇ
            SceneManager.LoadScene(NextSceneName);
        else
            Debug.LogWarning("NextSceneName ���ݒ肳��Ă��܂���B");
    }
}
