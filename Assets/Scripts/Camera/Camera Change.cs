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
        CameraActionRef.action.performed += OnCameraSwitch; // ���̓C�x���g�o�^
        CameraActionRef.action.Enable();                     // InputAction��L����
    }

    private void OnDisable()
    {
        CameraActionRef.action.performed -= OnCameraSwitch; // ���̓C�x���g����
        CameraActionRef.action.Disable();                   // InputAction�𖳌���
    }

    private void OnCameraSwitch(InputAction.CallbackContext context)
    {
        _isMainActive = !_isMainActive;              // �J�����̃A�N�e�B�u��Ԃ�ؑ�
        MainCanera.SetActive(_isMainActive);        // ���C���J������ؑ�
        SubCamera.SetActive(!_isMainActive);        // �T�u�J������ؑ�
    }
}
