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
        rb = GetComponent<Rigidbody>(); // Rigidbody�擾
    }

    public void OnMove(InputValue value)
    {
        if (!IsControllable)             // ����s�Ȃ���̓��Z�b�g
        {
            moveInput = Vector2.zero;
            return;
        }

        moveInput = value.Get<Vector2>(); // ���͎擾
    }

    void FixedUpdate()
    {
        if (!IsControllable) return;      // ����s�Ȃ�ړ��������Ȃ�

        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y).normalized * RunSpeed; // �ړ��x�N�g��
        rb.MovePosition(rb.position + move * Time.fixedDeltaTime);                      // Rigidbody�ړ�
    }

    public void ResetInput()
    {
        moveInput = Vector2.zero;         // ���̓��Z�b�g
    }

    public void SetDead(bool dead)
    {
        IsControllable = !dead;           // ���S���͑���s��
        if (dead)
        {
            ResetInput();                 // ���̓��Z�b�g
        }
    }
}
