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
        if (!_isRunning || _isPaused) return;  // 停止中やポーズ中は更新しない

        _elapsedTime += Time.deltaTime;        // 時間加算
        TimerText.text = $"{_elapsedTime:F2}Sec"; // 表示更新
    }

    public void StopTimer()
    {
        _isRunning = false;   // タイマー停止
    }

    public float GetElapsedTime()
    {
        return _elapsedTime;  // 経過時間取得
    }

    public void PauseTimer()
    {
        _isPaused = true;     // ポーズ
    }

    public void ResumeTimer()
    {
        _isPaused = false;    // ポーズ解除
    }
}
