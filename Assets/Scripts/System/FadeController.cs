using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeController : MonoBehaviour
{
    [SerializeField] private Image _fadeImage;
    [SerializeField] private float _fadeTime = 1f;

    void Start()
    {
        StartCoroutine(FadeIn());  // 開始時にフェードイン
    }

    public IEnumerator FadeIn()
    {
        float t = 0;
        Color c = _fadeImage.color;
        c.a = 1;                    // 初期は黒
        _fadeImage.color = c;

        while (t < _fadeTime)         // フェードイン処理
        {
            t += Time.deltaTime;
            c.a = Mathf.Lerp(1, 0, t / _fadeTime);  // 不透明→透明
            _fadeImage.color = c;
            yield return null;
        }

        c.a = 0;
        _fadeImage.color = c;        // 完全透明
    }

    public IEnumerator FadeOut(System.Action onComplete)
    {
        float t = 0;
        Color c = _fadeImage.color;
        c.a = 0;                     // 初期は透明
        _fadeImage.color = c;

        while (t < _fadeTime)         // フェードアウト処理
        {
            t += Time.deltaTime;
            c.a = Mathf.Lerp(0, 1, t / _fadeTime);   // 透明→不透明
            _fadeImage.color = c;
            yield return null;
        }

        c.a = 1;
        _fadeImage.color = c;        // 完全不透明

        if (onComplete != null)       // コールバック呼び出し
        {
            onComplete();
        }
    }
}
