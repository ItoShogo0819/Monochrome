using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBlock : MonoBehaviour
{
    [SerializeField] private string _sceneToLoad = "Stage1";
    [SerializeField] private FadeController _fadeCont;

    private bool _triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (_triggered) return;
        if (!other.CompareTag("Player")) return;

        _triggered = true;
        StartCoroutine(_fadeCont.FadeOut(() => { SceneManager.LoadScene(_sceneToLoad); }));
    }
}
