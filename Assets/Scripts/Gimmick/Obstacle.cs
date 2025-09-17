using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Obstacle : MonoBehaviour
{
    public PlayerColorType ObstacleColor;

    void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Player")) return;  // プレイヤー以外無視

        PlayerColor pc = other.gameObject.GetComponent<PlayerColor>();  // プレイヤーの色取得
        if (pc != null && pc.playerColor == ObstacleColor)               // 同色判定
        {
            if (DeadManager.Instance != null)                           // DeadManager 経由で死亡処理
            {
                DeadManager.Instance.Die(other.gameObject);
            }
        }
    }
}
