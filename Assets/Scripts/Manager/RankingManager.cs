using UnityEngine;
using TMPro;
using System.Linq;

public class RankingManager : MonoBehaviour
{
    public TMP_Text[] RankingTexts;
    private float[] _bestTimes = new float[5];

    void Start()
    {
        LoadRanking();   // 保存データ読み込み
        UpdateUI();      // UI更新
    }

    public void AddTime(float newTime)
    {
        // 新記録挿入処理
        for (int i = 0; i < _bestTimes.Length; i++)
        {
            if (_bestTimes[i] == 0 || newTime < _bestTimes[i])
            {
                // 下の順位をずらす
                for (int j = _bestTimes.Length - 1; j > i; j--)
                {
                    _bestTimes[j] = _bestTimes[j - 1];
                }

                _bestTimes[i] = newTime; // 新記録を挿入
                break;
            }
        }

        SaveRanking(); // 保存
        UpdateUI();    // UI反映
    }

    void SaveRanking()
    {
        for (int i = 0; i < _bestTimes.Length; i++)
        {
            PlayerPrefs.SetFloat($"BestTime{i}", _bestTimes[i]);
        }
        PlayerPrefs.Save(); // PlayerPrefsに保存
    }

    void LoadRanking()
    {
        for (int i = 0; i < RankingTexts.Length; i++)
        {
            _bestTimes[i] = PlayerPrefs.GetFloat($"BestTime{i}", 0f); // デフォルト0
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < RankingTexts.Length; i++)
        {
            if (_bestTimes[i] > 0)
            {
                RankingTexts[i].text = $"{i + 1}: {_bestTimes[i]:F2}s"; // 秒表示
            }
            else
            {
                RankingTexts[i].text = $"{i + 1}: ---"; // 記録なし
            }
        }
    }
}
