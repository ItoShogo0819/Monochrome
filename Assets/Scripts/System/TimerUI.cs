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
        if (!_isRunning || _isPaused) return;

        _elapsedTime += Time.deltaTime;
        TimerText.text = $"{_elapsedTime:F2}•b";
    }

    public void StopTimer()
    {
        _isRunning = false;
    }

    public float GetElapsedTime()
    {
        return _elapsedTime;
    }

    public void PauseTimer()
    {
        _isPaused = true;
    }

    public void ResumeTimer()
    {
        _isPaused = false;
    }
}
