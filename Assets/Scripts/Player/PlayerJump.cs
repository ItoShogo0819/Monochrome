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
        rb = GetComponent<Rigidbody>(); // Rigidbody取得
    }

    public void OnJump(InputValue value)
    {
        if (!JumpControl) return;         // ジャンプ無効時は処理しない

        if (IsGrounded && value.isPressed) // 地面にいる & 入力あり
        {
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse); // 上方向に力を加える
            IsGrounded = false;            // 空中判定に変更
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // 地面または可動床に接触したら接地判定
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("MoveGround"))
        {
            IsGrounded = true;
        }
    }
}
