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
        CameraActionRef.action.performed += OnCameraSwitch; // 入力イベント登録
        CameraActionRef.action.Enable();                     // InputActionを有効化
    }

    private void OnDisable()
    {
        CameraActionRef.action.performed -= OnCameraSwitch; // 入力イベント解除
        CameraActionRef.action.Disable();                   // InputActionを無効化
    }

    private void OnCameraSwitch(InputAction.CallbackContext context)
    {
        _isMainActive = !_isMainActive;              // カメラのアクティブ状態を切替
        MainCanera.SetActive(_isMainActive);        // メインカメラを切替
        SubCamera.SetActive(!_isMainActive);        // サブカメラを切替
    }
}
