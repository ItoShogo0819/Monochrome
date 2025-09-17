using UnityEngine;

public class FloorDethZone : MonoBehaviour
{
    private FloorColor _floorColor;

    void Start()
    {
        _floorColor = GetComponent<FloorColor>();  // FloorColor コンポーネント取得
    }

    void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Player")) return;  // プレイヤー以外は無視

        PlayerColor playerColor = other.gameObject.GetComponent<PlayerColor>();  // プレイヤーの色情報取得
        if (playerColor != null && playerColor.playerColor == _floorColor.floorColor)
        {
            // プレイヤー色と床の色が一致したら死亡処理
            if (DeadManager.Instance != null)
            {
                DeadManager.Instance.Die(other.gameObject);  // 死亡処理呼び出し
            }
        }
    }
}
