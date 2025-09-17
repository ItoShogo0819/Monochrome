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
        rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        if (!IsControllable) return;

        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y).normalized * RunSpeed;
        rb.MovePosition(rb.position + move * Time.fixedDeltaTime);
    }

    public void ResetInput()
    {
        moveInput = Vector2.zero;
    }
}
