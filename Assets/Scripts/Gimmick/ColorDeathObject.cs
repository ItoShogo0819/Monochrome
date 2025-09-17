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
        _objRend = GetComponent<Renderer>();                    // �����_���[�擾
        _initialType = CurrentType;                              // �����F���L�^
        ApplyColor();                                            // �F���f
    }

    // ���݂̐F�������_�[�ɔ��f
    void ApplyColor()
    {
        if (_objRend != null)
        {
            if (CurrentType == PlayerColorType.Black)
            {
                _objRend.material.color = ColorA;               // ���ɐݒ�
            }
            else
            {
                _objRend.material.color = ColorB;               // ���ɐݒ�
            }
        }
    }

    // �F�𔽓]������
    public void ToggleColor()
    {
        if (CurrentType == PlayerColorType.Black)
        {
            CurrentType = PlayerColorType.White;               // ���ɕύX
        }
        else
        {
            CurrentType = PlayerColorType.Black;               // ���ɕύX
        }
        ApplyColor();                                          // �����_���[�X�V
    }

    // ���̐F�ɖ߂�
    public void ResetInitialColor()
    {
        CurrentType = _initialType;                            // �����F�ɖ߂�
        ApplyColor();                                          // �����_���[�X�V
    }

    void OnCollisionEnter(Collision col)
    {
        if (!col.gameObject.CompareTag("Player")) return;      // �v���C���[�ȊO����

        PlayerColor pc = col.gameObject.GetComponent<PlayerColor>();
        if (pc == null) return;

        // ���F�Ȃ玀�S
        if (pc.playerColor == CurrentType)
        {
            DeadManager.Instance.Die(col.gameObject);          // ���S�����Ăяo��
        }
    }

    void OnCollisionStay(Collision col)
    {
        if (!col.gameObject.CompareTag("Player")) return;      // �v���C���[�ȊO����

        PlayerColor pc = col.gameObject.GetComponent<PlayerColor>();
        if (pc == null) return;

        // �F���ω������ꍇ�����S����
        if (pc.playerColor == CurrentType)
        {
            DeadManager.Instance.Die(col.gameObject);          // ���S����
        }
    }
}
