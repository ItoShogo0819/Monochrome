using UnityEngine;

public class ColorDeathObject : MonoBehaviour
{
    public PlayerColorType CurrentType = PlayerColorType.Black; // ���݂̐F
    public Color ColorA = Color.black;
    public Color ColorB = Color.white;

    private PlayerColorType _initialType; // �����F��ێ�
    private Renderer _objRend;

    void Start()
    {
        _objRend = GetComponent<Renderer>();
        _initialType = CurrentType; // �ŏ��̐F���L�^
        ApplyColor();
    }

    // ���݂̐F�������_�[�ɔ��f
    void ApplyColor()
    {
        if (_objRend != null)
        {
            if (CurrentType == PlayerColorType.Black)
            {
                _objRend.material.color = ColorA;
            }
            else
            {
                _objRend.material.color = ColorB;
            }
        }
    }

    // �F�𔽓]������
    public void ToggleColor()
    {
        if (CurrentType == PlayerColorType.Black)
        {
            CurrentType = PlayerColorType.White;
        }
        else
        {
            CurrentType = PlayerColorType.Black;
        }
        ApplyColor();
    }

    // ���̐F�ɖ߂�
    public void ResetInitialColor()
    {
        CurrentType = _initialType;
        ApplyColor();
    }

    void OnCollisionEnter(Collision col)
    {
        if (!col.gameObject.CompareTag("Player")) return;

        PlayerColor pc = col.gameObject.GetComponent<PlayerColor>();
        if (pc == null) return;

        // ���F�Ȃ玀�S
        if (pc.playerColor == CurrentType)
        {
            DeadManager.Instance.Die(col.gameObject);
        }
    }

    void OnCollisionStay(Collision col)
    {
        if (!col.gameObject.CompareTag("Player")) return;

        PlayerColor pc = col.gameObject.GetComponent<PlayerColor>();
        if (pc == null) return;

        // ���F�Ȃ玀�S�i�F���ω������ꍇ�ɑΉ��j
        if (pc.playerColor == CurrentType)
        {
            DeadManager.Instance.Die(col.gameObject);
        }
    }
}
