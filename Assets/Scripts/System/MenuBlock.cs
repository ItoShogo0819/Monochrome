using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBlock : MonoBehaviour
{
    [SerializeField] private string _sceneToLoad = "Stage1";
    [SerializeField] private FadeController _fadeCont;

    private bool _triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (_triggered) return;                               // ���ɏ����ς݂Ȃ疳��
        if (!other.CompareTag("Player")) return;             // �v���C���[�̂ݔ���

        _triggered = true;
        // �t�F�[�h�A�E�g��Ɏw��V�[�������[�h
        StartCoroutine(_fadeCont.FadeOut(() => { SceneManager.LoadScene(_sceneToLoad); }));
    }
}
