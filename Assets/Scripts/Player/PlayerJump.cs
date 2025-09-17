using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    Rigidbody rb;
    public float JumpForce = 5f;
    public bool IsGrounded = true;
    public bool JumpControl = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbody�擾
    }

    public void OnJump(InputValue value)
    {
        if (!JumpControl) return;         // �W�����v�������͏������Ȃ�

        if (IsGrounded && value.isPressed) // �n�ʂɂ��� & ���͂���
        {
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse); // ������ɗ͂�������
            IsGrounded = false;            // �󒆔���ɕύX
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // �n�ʂ܂��͉����ɐڐG������ڒn����
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("MoveGround"))
        {
            IsGrounded = true;
        }
    }
}
