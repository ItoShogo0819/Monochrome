using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    Rigidbody rb;

    Vector2 moveInput;

    public float RunSpeed = 8f;
    public bool IsControllable = true;

    public Vector2 MoveInput => moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbody取得
    }

    public void OnMove(InputValue value)
    {
        if (!IsControllable)             // 操作不可なら入力リセット
        {
            moveInput = Vector2.zero;
            return;
        }

        moveInput = value.Get<Vector2>(); // 入力取得
    }

    void FixedUpdate()
    {
        if (!IsControllable) return;      // 操作不可なら移動処理しない

        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y).normalized * RunSpeed; // 移動ベクトル
        rb.MovePosition(rb.position + move * Time.fixedDeltaTime);                      // Rigidbody移動
    }

    public void ResetInput()
    {
        moveInput = Vector2.zero;         // 入力リセット
    }

    public void SetDead(bool dead)
    {
        IsControllable = !dead;           // 死亡時は操作不可
        if (dead)
        {
            ResetInput();                 // 入力リセット
        }
    }
}
