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
        float mouseX = _lookInput.x * mouseSensitivity * Time.deltaTime;  // …•½•ûŒü‰ñ“]—Ê
        float mouseY = _lookInput.y * mouseSensitivity * Time.deltaTime;  // ‚’¼•ûŒü‰ñ“]—Ê

        _xRotation -= mouseY;                  // ã‰º‰ñ“]”½‰f
        _xRotation = Mathf.Clamp(_xRotation, -80f, 80f); // ‰ñ“]§ŒÀ

        transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);   // ƒJƒƒ‰ã‰º‰ñ“]
        playerBody.Rotate(Vector3.up * mouseX);                           // ƒvƒŒƒCƒ„[¶‰E‰ñ“]
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        _lookInput = context.ReadValue<Vector2>(); // “ü—Í’lXV
    }
}
