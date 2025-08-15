using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    Rigidbody rb;

    Vector3 moveInput;

    public float RunSpeed = 8f;
    public bool IsControllable = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector3>();
    }

    void FixedUpdate()
    {
        if (!IsControllable) return;

        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y).normalized;
        rb.MovePosition(rb.position + move * RunSpeed * Time.fixedDeltaTime);
    }
}
