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

    private float yaw = 0f;                   
    private float pitch = 0f;                 

    private InputAction lookAction;           

    void Awake()
    {
        // マウスとゲームパッド右スティック両対応
        lookAction = new InputAction("Look", binding: "<Mouse>/delta"); // マウス
        lookAction.AddBinding("<Gamepad>/rightStick");                  // ゲームパッド右スティック
        lookAction.Enable();                                             // 入力有効化
    }

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        yaw = angles.y;      // 初期水平角度
        pitch = angles.x;    // 初期垂直角度

        Cursor.lockState = CursorLockMode.Locked; // カーソルを画面中央に固定
        Cursor.visible = false;                   // カーソル非表示
    }

    void LateUpdate()
    {
        if (Target == null) return; // ターゲット未設定なら処理終了

        // 入力取得
        Vector2 lookInput = lookAction.ReadValue<Vector2>();
        yaw += lookInput.x * MouseSensitivity;    // 水平回転
        pitch -= lookInput.y * MouseSensitivity;  // 垂直回転
        pitch = Mathf.Clamp(pitch, MinPitch, MaxPitch); // 上下回転制限

        // カメラ位置計算
        Vector3 desiredPos = Target.position + Quaternion.Euler(pitch, yaw, 0) * Offset;
        transform.position = Vector3.Lerp(transform.position, desiredPos, FollowSpeed * Time.deltaTime);

        // カメラ回転（ターゲット注視）
        Vector3 lookPoint = Target.position + Vector3.up * 1.5f; // 注視点はターゲットの高さ補正
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookPoint - transform.position), RotationSpeed * Time.deltaTime);
    }
}
