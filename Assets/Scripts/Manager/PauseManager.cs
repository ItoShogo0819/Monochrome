using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    [Header("É|Å[ÉYUI")]
    public GameObject PauseUI;

    private bool _isPaused = false;

    void Start()
    {
        if(PauseUI != null)
        {
            PauseUI.SetActive(false);
        }
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        if (_isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    private void PauseGame()
    {
        _isPaused = true;
        Time.timeScale = 0f;
        if (PauseUI != null)
        {
            PauseUI.SetActive(true);
        }

        TimerUI timer = FindAnyObjectByType<TimerUI>();
        if(timer != null)
        {
            timer.PauseTimer();
        }
    }

    private void ResumeGame()
    {
        _isPaused = false;
        Time.timeScale = 1f;
        if (PauseUI != null)
        {
            PauseUI.SetActive(false);
        }

        TimerUI timer = FindAnyObjectByType<TimerUI>();
        if (timer != null)
        {
            timer.ResumeTimer();
        }
    }
}
