using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeadManager : MonoBehaviour
{
    public static DeadManager Instance { get; private set; }

    [Header("プレイヤー設定")]
    public GameObject BlackPlayer;
    public GameObject WhitePlayer;

    [Header("リスポーン設定")]
    public float RespawnDelay = 0.5f;

    private Dictionary<GameObject, Vector3> _respawnPoints = new();
    private Dictionary<GameObject, bool> _isDead = new();

    void Awake()
    {
        if (Instance == null) Instance = this;  // Singleton設定
        else Destroy(gameObject);
    }

    void Start()
    {
        // 初期リスポーン位置を記録
        _respawnPoints[BlackPlayer] = BlackPlayer.transform.position;
        _respawnPoints[WhitePlayer] = WhitePlayer.transform.position;

        _isDead[BlackPlayer] = false;
        _isDead[WhitePlayer] = false;
    }

    public void Die(GameObject player)
    {
        if (_isDead[player]) return;  // 既に死亡していたら処理しない
        _isDead[player] = true;

        // PlayerAutoMove 追従停止
        PlayerAutoMove autoMove = player.GetComponent<PlayerAutoMove>();
        if (autoMove != null) autoMove.SetDead(true);

        StartCoroutine(RespawnRoutine(player));
    }

    private IEnumerator RespawnRoutine(GameObject player)
    {
        Rigidbody rb = player.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;   // 移動停止
            rb.angularVelocity = Vector3.zero;  // 回転停止
        }

        // PlayerMove の入力リセット
        PlayerMove move = player.GetComponent<PlayerMove>();
        if (move != null)
        {
            move.ResetInput();
        }

        player.SetActive(false);  // 非表示

        yield return new WaitForSeconds(RespawnDelay);  // 待機

        if (_respawnPoints.TryGetValue(player, out Vector3 respawnPos))
            player.transform.position = respawnPos;  // リスポーン位置に移動

        player.SetActive(true);  // 表示

        // 追従制御解除
        PlayerAutoMove autoMove2 = player.GetComponent<PlayerAutoMove>();
        if (autoMove2 != null) autoMove2.SetDead(false);

        _isDead[player] = false;  // 死亡状態解除
    }

    // チェックポイント更新
    public void UpdateRespawnPoint(GameObject player, Vector3 newPoint)
    {
        _respawnPoints[player] = newPoint;
        Debug.Log($"{player.name}のリスポーン地点を更新:{newPoint}");
    }
}
