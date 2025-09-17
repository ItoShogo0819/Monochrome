using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovingObject : MonoBehaviour
{
    [Header("移動設定")]
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
        _rb = GetComponent<Rigidbody>();  // Rigidbody 取得
        _rb.isKinematic = true;           // 物理影響なしに設定
        _startPos = transform.position;   // 開始位置記録
        _elapsedTime = 0f;                // タイマー初期化
    }

    void FixedUpdate()
    {
        _elapsedTime += Time.fixedDeltaTime * MoveSpeed;  // 経過時間更新
        Vector3 dir = MoveDirection.normalized;          // 移動方向正規化

        float cycle = _elapsedTime % (MoveDistance * 2f); // 往復サイクル
        float offset;
        if (cycle <= MoveDistance) offset = cycle;        // 前方向移動
        else offset = MoveDistance * 2f - cycle;         // 戻り方向移動

        Vector3 newPos = _startPos + dir * offset;       // 新しい位置計算

        _currentVelocity = (newPos - _rb.position) / Time.fixedDeltaTime; // 速度計算

        _rb.MovePosition(newPos);  // Rigidbody 移動
    }
}
