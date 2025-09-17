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
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        _respawnPoints[BlackPlayer] = BlackPlayer.transform.position;
        _respawnPoints[WhitePlayer] = WhitePlayer.transform.position;

        _isDead[BlackPlayer] = false;
        _isDead[WhitePlayer] = false;
    }

    public void Die(GameObject player)
    {
        if (_isDead[player]) return;
        _isDead[player] = true;

        // 追従停止
        PlayerAutoMove autoMove = player.GetComponent<PlayerAutoMove>();
        if (autoMove != null) autoMove.SetDead(true);

        StartCoroutine(RespawnRoutine(player));
    }

    private IEnumerator RespawnRoutine(GameObject player)
    {
        Rigidbody rb = player.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        player.SetActive(false);

        yield return new WaitForSeconds(RespawnDelay);

        if (_respawnPoints.TryGetValue(player, out Vector3 respawnPos))
            player.transform.position = respawnPos;

        player.SetActive(true);

        // 再び床に接触するまで追従しない
        PlayerAutoMove autoMove2 = player.GetComponent<PlayerAutoMove>();
        if (autoMove2 != null) autoMove2.SetDead(false);

        _isDead[player] = false;
    }

    // チェックポイント用
    public void UpdateRespawnPoint(GameObject player, Vector3 newPoint)
    {
        _respawnPoints[player] = newPoint;
        Debug.Log($"{player.name}のリスポーン地点を更新:{newPoint}");
    }
}
