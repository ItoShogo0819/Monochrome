using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;  // プレイヤー以外は無視

        DeadManager deadManager = FindAnyObjectByType<DeadManager>();  // DeadManager取得
        if (deadManager != null)
        {
            // プレイヤーのリスポーン地点をこのオブジェクト位置に更新
            deadManager.UpdateRespawnPoint(other.gameObject, transform.position);
            Debug.Log($"{other.name}のリスポーン地点を更新:{transform.position}");  // デバッグ表示
        }
    }
}
