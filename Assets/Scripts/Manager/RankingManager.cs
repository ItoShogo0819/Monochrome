using UnityEngine;
using TMPro;
using System.Linq;

public class RankingManager : MonoBehaviour
{
    public TMP_Text[] RankingTexts;
    private float[] _bestTimes = new float[5];

    void Start()
    {
        LoadRanking();   // �ۑ��f�[�^�ǂݍ���
        UpdateUI();      // UI�X�V
    }

    public void AddTime(float newTime)
    {
        // �V�L�^�}������
        for (int i = 0; i < _bestTimes.Length; i++)
        {
            if (_bestTimes[i] == 0 || newTime < _bestTimes[i])
            {
                // ���̏��ʂ����炷
                for (int j = _bestTimes.Length - 1; j > i; j--)
                {
                    _bestTimes[j] = _bestTimes[j - 1];
                }

                _bestTimes[i] = newTime; // �V�L�^��}��
                break;
            }
        }

        SaveRanking(); // �ۑ�
        UpdateUI();    // UI���f
    }

    void SaveRanking()
    {
        for (int i = 0; i < _bestTimes.Length; i++)
        {
            PlayerPrefs.SetFloat($"BestTime{i}", _bestTimes[i]);
        }
        PlayerPrefs.Save(); // PlayerPrefs�ɕۑ�
    }

    void LoadRanking()
    {
        for (int i = 0; i < RankingTexts.Length; i++)
        {
            _bestTimes[i] = PlayerPrefs.GetFloat($"BestTime{i}", 0f); // �f�t�H���g0
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < RankingTexts.Length; i++)
        {
            if (_bestTimes[i] > 0)
            {
                RankingTexts[i].text = $"{i + 1}: {_bestTimes[i]:F2}s"; // �b�\��
            }
            else
            {
                RankingTexts[i].text = $"{i + 1}: ---"; // �L�^�Ȃ�
            }
        }
    }
}
