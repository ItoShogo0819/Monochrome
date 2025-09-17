using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    [Header("ポーズUI")]
    public GameObject PauseUI;

    private bool _isPaused = false;

    void Start()
    {
        if (PauseUI != null)
        {
            PauseUI.SetActive(false); // ゲーム開始時は非表示
        }
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (!context.performed) return; // 入力が確定したときのみ

        if (_isPaused) ResumeGame();  // 既にポーズ中なら再開
        else PauseGame();              // ポーズ中でなければ停止
    }

    private void PauseGame()
    {
        _isPaused = true;
        Time.timeScale = 0f; // ゲーム全体停止
        if (PauseUI != null) PauseUI.SetActive(true); // UI表示

        TimerUI timer = FindAnyObjectByType<TimerUI>();
        if (timer != null)
        {
            timer.PauseTimer(); // タイマーも停止
        }
    }

    private void ResumeGame()
    {
        _isPaused = false;
        Time.timeScale = 1f; // ゲーム再開
        if (PauseUI != null) PauseUI.SetActive(false); // UI非表示

        TimerUI timer = FindAnyObjectByType<TimerUI>();
        if (timer != null)
        {
            timer.ResumeTimer(); // タイマー再開
        }
    }
}
