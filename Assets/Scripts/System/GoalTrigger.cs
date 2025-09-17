using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public TimerUI Timer;

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player")) return;

        float finalTime = Timer.GetElapsedTime();
        Timer.StopTimer();
        Debug.Log($"�N���A�^�C��:{finalTime:F2}�b");

        float bestTime = PlayerPrefs.GetFloat("BestTime", 9999f);
        if(finalTime < bestTime)
        {
            PlayerPrefs.SetFloat("BestTime",finalTime);
            Debug.Log("�V�L�^�I�ۑ����܂����B");
        }
    }
}
