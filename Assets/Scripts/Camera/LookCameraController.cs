using UnityEngine;
using UnityEngine.InputSystem;

public class LookCameraController : MonoBehaviour
{
    [SerializeField] Transform playerBody;
    [SerializeField] float mouseSensitivity = 100f;

    private Vector2 _lookInput;
    private float _xRotation = 0f;

    void Update()
    {
        float mouseX = _lookInput.x * mouseSensitivity * Time.deltaTime;
        float mouseY = _lookInput.y * mouseSensitivity * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -80f, 80f);

        transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        _lookInput = context.ReadValue<Vector2>();
    }
}
