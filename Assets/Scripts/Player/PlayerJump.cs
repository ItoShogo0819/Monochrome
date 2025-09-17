using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    Rigidbody rb;
    public float JumpForce = 5f;
    public bool IsGrounded = true;
    public bool JumpControl = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnJump(InputValue value)
    {
        if (!JumpControl) return;

        if(IsGrounded && value.isPressed)
        {
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            IsGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("MoveGround"))
        {
            IsGrounded = true;
        }
    }
}
