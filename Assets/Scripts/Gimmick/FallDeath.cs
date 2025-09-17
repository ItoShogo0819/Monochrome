using UnityEngine;

public class FallDeath : MonoBehaviour
{
    public float FallLimitY = -3;

    private PlayerColor _playerColor; // プレイヤー判定用（オプション）

    void Start()
    {
        _playerColor = GetComponent<PlayerColor>();
    }

    void Update()
    {
        if (transform.position.y < FallLimitY)
        {
            // DeadManager の Singleton 経由で死亡処理
            if (DeadManager.Instance != null)
            {
                DeadManager.Instance.Die(gameObject);
            }
        }
    }
}
