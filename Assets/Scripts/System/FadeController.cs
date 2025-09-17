using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeController : MonoBehaviour
{
    [SerializeField] private Image _fadeImage;
    [SerializeField] private float _fadeTime = 1f;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeIn()
    {
        float t = 0;
        Color c = _fadeImage.color;
        c.a = 1;
        _fadeImage.color = c;

        while(t < _fadeTime)
        {
            t += Time.deltaTime;
            c.a = Mathf.Lerp(1, 0, t / _fadeTime);
            _fadeImage.color = c;
            yield return null;
        }

        c.a = 0;
        _fadeImage.color = c;
    }

    public IEnumerator FadeOut(System.Action onComplete)
    {
        float t = 0;
        Color c = _fadeImage.color;
        c.a = 0;
        _fadeImage.color = c;

        while(t < _fadeTime)
        {
            t += Time.deltaTime;
            c.a = Mathf.Lerp(0,1,t / _fadeTime);
            _fadeImage.color = c;
            yield return null;
        }

        c.a = 1;
        _fadeImage.color = c;

        if(onComplete != null)
        {
            onComplete();
        }
    }
}
