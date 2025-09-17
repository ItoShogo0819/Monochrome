using UnityEngine;

public class FallDeath : MonoBehaviour
{
    public float FallLimitY = -3;

    private PlayerColor _playerColor; // プレイヤー判定用（オプション）

    void Start()
    {
        _playerColor = GetComponent<PlayerColor>();  // PlayerColor コンポーネント取得
    }

    void Update()
    {
        // Y座標が落下限界を下回ったら死亡
        if (transform.position.y < FallLimitY)
        {
            if (DeadManager.Instance != null)
            {
                DeadManager.Instance.Die(gameObject);  // 死亡処理呼び出し
            }
        }
    }
}
