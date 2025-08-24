using UnityEngine;
using UnityEngine.InputSystem;

public class CameraChange : MonoBehaviour
{
    public GameObject MainCanera;
    public GameObject SubCamera;
    private bool _isMainActive = true;

    [Header("Input")]
    public InputActionReference CameraActionRef;

    private void OnEnable()
    {
        CameraActionRef.action.performed += OnCameraSwitch;
        CameraActionRef.action.Enable();
    }

    private void OnDisable()
    {
        CameraActionRef.action.performed -= OnCameraSwitch;
        CameraActionRef.action.Disable();
    }

    private void OnCameraSwitch(InputAction.CallbackContext context)
    {
        _isMainActive = !_isMainActive;
        MainCanera.SetActive(_isMainActive);
        SubCamera.SetActive(!_isMainActive);
    }
}
