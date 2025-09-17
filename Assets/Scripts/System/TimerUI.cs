using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    public TMP_Text TimerText;
   
    private float _elapsedTime = 0f;
    private bool _isRunning = true;

    private bool _isPaused = false;

    void Update()
    {
        if (!_isRunning || _isPaused) return;  // ��~����|�[�Y���͍X�V���Ȃ�

        _elapsedTime += Time.deltaTime;        // ���ԉ��Z
        TimerText.text = $"{_elapsedTime:F2}Sec"; // �\���X�V
    }

    public void StopTimer()
    {
        _isRunning = false;   // �^�C�}�[��~
    }

    public float GetElapsedTime()
    {
        return _elapsedTime;  // �o�ߎ��Ԏ擾
    }

    public void PauseTimer()
    {
        _isPaused = true;     // �|�[�Y
    }

    public void ResumeTimer()
    {
        _isPaused = false;    // �|�[�Y����
    }
}
