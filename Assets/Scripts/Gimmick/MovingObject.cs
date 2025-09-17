using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovingObject : MonoBehaviour
{
    [Header("à⁄ìÆê›íË")]
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
        _rb = GetComponent<Rigidbody>();
        _rb.isKinematic = true;
        _startPos = transform.position;
        _elapsedTime = 0f;
    }

    void FixedUpdate()
    {
        _elapsedTime += Time.fixedDeltaTime * MoveSpeed;
        Vector3 dir = MoveDirection.normalized;

        float cycle = _elapsedTime % (MoveDistance * 2f);
        float offset;
        if (cycle <= MoveDistance) offset = cycle;
        else offset = MoveDistance * 2f - cycle;

        Vector3 newPos = _startPos + dir * offset;

        _currentVelocity = (newPos - _rb.position) / Time.fixedDeltaTime;

        _rb.MovePosition(newPos);
    }
}
