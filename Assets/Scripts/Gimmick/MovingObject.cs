using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovingObject : MonoBehaviour
{
    [Header("�ړ��ݒ�")]
    public Vector3 MoveDirection = new Vector3(0f, 0f, 0f);
    public float MoveDistance = 5f;
    public float MoveSpeed = 2f;

    private Rigidbody _rb;
    private Vector3 _startPos;
    private float _elapsedTime;

    private Vector3 _currentVelocity;
    public Vector3 GetCurrentVelocity() { return _currentVelocity; }

    void Start()
    {
        _rb = GetComponent<Rigidbody>();  // Rigidbody �擾
        _rb.isKinematic = true;           // �����e���Ȃ��ɐݒ�
        _startPos = transform.position;   // �J�n�ʒu�L�^
        _elapsedTime = 0f;                // �^�C�}�[������
    }

    void FixedUpdate()
    {
        _elapsedTime += Time.fixedDeltaTime * MoveSpeed;  // �o�ߎ��ԍX�V
        Vector3 dir = MoveDirection.normalized;          // �ړ��������K��

        float cycle = _elapsedTime % (MoveDistance * 2f); // �����T�C�N��
        float offset;
        if (cycle <= MoveDistance) offset = cycle;        // �O�����ړ�
        else offset = MoveDistance * 2f - cycle;         // �߂�����ړ�

        Vector3 newPos = _startPos + dir * offset;       // �V�����ʒu�v�Z

        _currentVelocity = (newPos - _rb.position) / Time.fixedDeltaTime; // ���x�v�Z

        _rb.MovePosition(newPos);  // Rigidbody �ړ�
    }
}
