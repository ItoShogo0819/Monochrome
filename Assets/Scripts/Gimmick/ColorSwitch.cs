using UnityEngine;

public class ColorSwitch : MonoBehaviour
{
    public ColorDeathObject Target;  // �A�g�I�u�W�F�N�g

    private bool _isPressed = false;     // �v���C���[������Ă��邩
    private bool _hasFlipped = false;    // ���]�ς݂�

    void Update()
    {
        // �v���C���[������Ă��Ă܂����]���Ă��Ȃ��ꍇ
        if (_isPressed && Target != null && !_hasFlipped)
        {
            Target.ToggleColor();          // ��x�����F�𔽓]
            _hasFlipped = true;           // ���]�ς݂ɂ���
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (!col.gameObject.CompareTag("Player")) return; // �v���C���[�ȊO����

        _isPressed = true;              // �v���C���[�������
        _hasFlipped = false;            // �t���O���Z�b�g���čĔ��]�\��
    }

    void OnCollisionExit(Collision col)
    {
        if (!col.gameObject.CompareTag("Player")) return; // �v���C���[�ȊO����

        _isPressed = false;             // �v���C���[�����ꂽ

        if (Target != null)
        {
            Target.ResetInitialColor();  // ���ꂽ��F�����ɖ߂�
        }
    }
}
