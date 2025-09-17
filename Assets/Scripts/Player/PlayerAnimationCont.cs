using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerAnimationCont : MonoBehaviour
{
    private Animator _anim;
    private PlayerMove _move;
    private PlayerJump _jump;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _move = GetComponent<PlayerMove>();
        _jump = GetComponent<PlayerJump>();
    }

    void Update()
    {
        if (_move.IsControllable) // �� �����ő��쒆������
        {
            // ���͒l�̑傫������Speed�v�Z
            float inputMagnitude = _move.MoveInput.magnitude * _move.RunSpeed;
            _anim.SetFloat("Speed", inputMagnitude);

            // �W�����v����
            _anim.SetBool("IsJumping", !_jump.IsGrounded);
        }
        else
        {
            // ���삵�ĂȂ��v���C���[��Idle�Œ�
            _anim.SetFloat("Speed", 0);
            _anim.SetBool("IsJumping", false);
        }
    }
}
