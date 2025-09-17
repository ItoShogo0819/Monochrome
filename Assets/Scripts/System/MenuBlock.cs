using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBlock : MonoBehaviour
{
    [SerializeField] private string _sceneToLoad = "Stage1";
    [SerializeField] private FadeController _fadeCont;

    private bool _triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (_triggered) return;                               // 既に処理済みなら無視
        if (!other.CompareTag("Player")) return;             // プレイヤーのみ反応

        _triggered = true;
        // フェードアウト後に指定シーンをロード
        StartCoroutine(_fadeCont.FadeOut(() => { SceneManager.LoadScene(_sceneToLoad); }));
    }
}
