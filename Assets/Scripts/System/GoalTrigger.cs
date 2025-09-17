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
        if (_goalTriggered) return;       // 既にゴール済みなら無視

        // プレイヤーか判定
        if (other.CompareTag("Player"))
        {
            _goalTriggered = true;

            float finalTime = Timer.GetElapsedTime(); // 経過時間取得
            Timer.StopTimer();                        // タイマー停止
            Debug.Log("クリアタイム: " + finalTime.ToString("F2") + "秒");

            float bestTime = PlayerPrefs.GetFloat("BestTime", 9999f);  // 既存ベストタイム
            if (finalTime < bestTime)                                   // 新記録なら保存
            {
                PlayerPrefs.SetFloat("BestTime", finalTime);
                Debug.Log("新記録！保存しました。");
            }

            StartCoroutine(FadeOutAndLoad());  // フェードアウト＆シーン切り替え
        }
    }

    private IEnumerator FadeOutAndLoad()
    {
        if (Fade != null)                     // フェードがある場合
        {
            yield return StartCoroutine(Fade.FadeOut(LoadNextScene));  // フェード後にロード
        }
        else
        {
            LoadNextScene();                  // フェードなしでロード
        }
    }

    private void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(NextSceneName))  // 遷移先が設定されている場合
            SceneManager.LoadScene(NextSceneName);
        else
            Debug.LogWarning("NextSceneName が設定されていません。");
    }
}
