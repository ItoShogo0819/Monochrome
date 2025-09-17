using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    [Header("�|�[�YUI")]
    public GameObject PauseUI;

    private bool _isPaused = false;

    void Start()
    {
        if (PauseUI != null)
        {
            PauseUI.SetActive(false); // �Q�[���J�n���͔�\��
        }
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (!context.performed) return; // ���͂��m�肵���Ƃ��̂�

        if (_isPaused) ResumeGame();  // ���Ƀ|�[�Y���Ȃ�ĊJ
        else PauseGame();              // �|�[�Y���łȂ���Β�~
    }

    private void PauseGame()
    {
        _isPaused = true;
        Time.timeScale = 0f; // �Q�[���S�̒�~
        if (PauseUI != null) PauseUI.SetActive(true); // UI�\��

        TimerUI timer = FindAnyObjectByType<TimerUI>();
        if (timer != null)
        {
            timer.PauseTimer(); // �^�C�}�[����~
        }
    }

    private void ResumeGame()
    {
        _isPaused = false;
        Time.timeScale = 1f; // �Q�[���ĊJ
        if (PauseUI != null) PauseUI.SetActive(false); // UI��\��

        TimerUI timer = FindAnyObjectByType<TimerUI>();
        if (timer != null)
        {
            timer.ResumeTimer(); // �^�C�}�[�ĊJ
        }
    }
}
