using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public TimerUI Timer;

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player")) return;

        float finalTime = Timer.GetElapsedTime();
        Timer.StopTimer();
        Debug.Log($"クリアタイム:{finalTime:F2}秒");

        float bestTime = PlayerPrefs.GetFloat("BestTime", 9999f);
        if(finalTime < bestTime)
        {
            PlayerPrefs.SetFloat("BestTime",finalTime);
            Debug.Log("新記録！保存しました。");
        }
    }
}
