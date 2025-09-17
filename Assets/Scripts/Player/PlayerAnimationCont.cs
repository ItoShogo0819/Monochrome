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
        if (_move.IsControllable) // ← ここで操作中か判定
        {
            // 入力値の大きさからSpeed計算
            float inputMagnitude = _move.MoveInput.magnitude * _move.RunSpeed;
            _anim.SetFloat("Speed", inputMagnitude);

            // ジャンプ判定
            _anim.SetBool("IsJumping", !_jump.IsGrounded);
        }
        else
        {
            // 操作してないプレイヤーはIdle固定
            _anim.SetFloat("Speed", 0);
            _anim.SetBool("IsJumping", false);
        }
    }
}
