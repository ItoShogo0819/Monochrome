using UnityEngine;

public class ColorSwitch : MonoBehaviour
{
    public ColorDeathObject Target;  // �A�g�I�u�W�F�N�g

    private bool _isPressed = false;     // �v���C���[������Ă��邩
    private bool _hasFlipped = false;    // ���]�ς݂�

    void Update()
    {
        if (_isPressed && Target != null && !_hasFlipped)
        {
            Target.ToggleColor();  // ��񂾂����]
            _hasFlipped = true;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (!col.gameObject.CompareTag("Player")) return;

        _isPressed = true;
        _hasFlipped = false; // ���ނ��тɃt���O���Z�b�g
    }

    void OnCollisionExit(Collision col)
    {
        if (!col.gameObject.CompareTag("Player")) return;

        _isPressed = false;

        if (Target != null)
        {
            Target.ResetInitialColor();  // ���ꂽ�猳�ɖ߂�
        }
    }
}
