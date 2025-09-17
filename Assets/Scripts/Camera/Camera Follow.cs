using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    [Header("追跡対象")]
    public Transform Target;

    [Header("カメラ位置オフセット")]
    public Vector3 Offset = new Vector3(0, 2.8f, -2.8f);

    [Header("追従速度")]
    public float FollowSpeed = 10f;

    [Header("回転スムーズ速度")]
    public float RotationSpeed = 10f;

    [Header("マウス感度")]
    public float MouseSensitivity = 1f;

    [Header("上下回転制限")]
    public float MinPitch = -40f;
    public float MaxPitch = 80f;

    private float yaw = 0f;   // 左右回転
    private float pitch = 0f; // 上下回転

    private InputAction lookAction;

    void Awake()
    {
        // マウスとゲームパッド右スティック両対応
        lookAction = new InputAction("Look", binding: "<Mouse>/delta");
        lookAction.AddBinding("<Gamepad>/rightStick");
        lookAction.Enable();
    }

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        yaw = angles.y;
        pitch = angles.x;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        if (Target == null) return;

        // 入力取得
        Vector2 lookInput = lookAction.ReadValue<Vector2>();
        yaw += lookInput.x * MouseSensitivity;
        pitch -= lookInput.y * MouseSensitivity;
        pitch = Mathf.Clamp(pitch, MinPitch, MaxPitch);

        // カメラ位置計算
        Vector3 desiredPos = Target.position + Quaternion.Euler(pitch, yaw, 0) * Offset;
        transform.position = Vector3.Lerp(transform.position, desiredPos, FollowSpeed * Time.deltaTime);

        // 注視点
        Vector3 lookPoint = Target.position + Vector3.up * 1.5f;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookPoint - transform.position), RotationSpeed * Time.deltaTime);
    }
}
