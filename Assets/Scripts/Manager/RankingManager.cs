using UnityEngine;
using TMPro;
using System.Linq;

public class RankingManager : MonoBehaviour
{
    public TMP_Text[] RankingTxets;
    private float[] _bestTimes = new float[5];

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadRanking();
        UpdateUI();
    }

    public void AddTime(float newTime)
    {
        for(int i = 0;  i < _bestTimes.Length; i++)
        {
            if (_bestTimes[i] == 0 || newTime < _bestTimes[i])
            {
                for(int j = _bestTimes.Length - 1; j > i; j--)
                {
                    _bestTimes[j] = _bestTimes[j - 1];
                }

                _bestTimes[i] = newTime;
                break;
            }
        }

        SaveRanking();
        UpdateUI();
    }

    void SaveRanking()
    {
        for(int i = 0; i < _bestTimes.Length; i++)
        {
            PlayerPrefs.SetFloat($"BestTime{i}",_bestTimes[i]);
        }
        PlayerPrefs.Save();
    }

    void LoadRanking()
    {
        for(int i = 0; i < RankingTxets.Length; i++)
        {
            _bestTimes[i] = PlayerPrefs.GetFloat($"BestTime{i}", 0f);
        }
    }

    void UpdateUI()
    {
        for(int i = 0; i < RankingTxets.Length; i++)
        {
            if (_bestTimes[i] > 0)
            {
                RankingTxets[i].text = $"{i + 1}: {_bestTimes[i]:F2}s";
            }
            else
            {
                RankingTxets[i].text = $"{i + 1}: ---";
            }
        }
    }
}
