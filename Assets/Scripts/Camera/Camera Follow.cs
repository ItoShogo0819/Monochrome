using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    [Header("�ǐՑΏ�")]
    public Transform Target;                  

    [Header("�J�����ʒu�I�t�Z�b�g")]
    public Vector3 Offset = new Vector3(0, 2.8f, -2.8f); 

    [Header("�Ǐ]���x")]
    public float FollowSpeed = 10f;           

    [Header("��]�X���[�Y���x")]
    public float RotationSpeed = 10f;         

    [Header("�}�E�X���x")]
    public float MouseSensitivity = 1f;       

    [Header("�㉺��]����")]
    public float MinPitch = -40f;             
    public float MaxPitch = 80f;              

    private float yaw = 0f;                   
    private float pitch = 0f;                 

    private InputAction lookAction;           

    void Awake()
    {
        // �}�E�X�ƃQ�[���p�b�h�E�X�e�B�b�N���Ή�
        lookAction = new InputAction("Look", binding: "<Mouse>/delta"); // �}�E�X
        lookAction.AddBinding("<Gamepad>/rightStick");                  // �Q�[���p�b�h�E�X�e�B�b�N
        lookAction.Enable();                                             // ���͗L����
    }

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        yaw = angles.y;      // ���������p�x
        pitch = angles.x;    // ���������p�x

        Cursor.lockState = CursorLockMode.Locked; // �J�[�\������ʒ����ɌŒ�
        Cursor.visible = false;                   // �J�[�\����\��
    }

    void LateUpdate()
    {
        if (Target == null) return; // �^�[�Q�b�g���ݒ�Ȃ珈���I��

        // ���͎擾
        Vector2 lookInput = lookAction.ReadValue<Vector2>();
        yaw += lookInput.x * MouseSensitivity;    // ������]
        pitch -= lookInput.y * MouseSensitivity;  // ������]
        pitch = Mathf.Clamp(pitch, MinPitch, MaxPitch); // �㉺��]����

        // �J�����ʒu�v�Z
        Vector3 desiredPos = Target.position + Quaternion.Euler(pitch, yaw, 0) * Offset;
        transform.position = Vector3.Lerp(transform.position, desiredPos, FollowSpeed * Time.deltaTime);

        // �J������]�i�^�[�Q�b�g�����j
        Vector3 lookPoint = Target.position + Vector3.up * 1.5f; // �����_�̓^�[�Q�b�g�̍����␳
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookPoint - transform.position), RotationSpeed * Time.deltaTime);
    }
}
