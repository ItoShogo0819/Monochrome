using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeadManager : MonoBehaviour
{
    [Header("プレイヤー設定")]
    public GameObject BlackPlayer;
    public GameObject WhitePlayer;

    [Header("リスポーン設定")]
    public float RespawnDelay = 0.5f;
    public GameObject AbsorbEffectPrefab;

    private Dictionary<GameObject, Vector3> _respawnPoints = new Dictionary<GameObject, Vector3>();
    private Dictionary<GameObject, bool> _isDead = new Dictionary<GameObject, bool>();

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

        StartCoroutine(RespawnRoutine(player));
    }

    public void UpdateRespawnPoint(GameObject player, Vector3 newPoint)
    {
        _respawnPoints[player] = newPoint;

        if (AbsorbEffectPrefab)
        {
            Instantiate(AbsorbEffectPrefab, newPoint, Quaternion.identity);
        }
    }

    private IEnumerator RespawnRoutine(GameObject player)
    {
        if (AbsorbEffectPrefab)
        {
            Instantiate(AbsorbEffectPrefab, player.transform.position, Quaternion.identity);
        }

        TogglePlayerControl(player, false);
        player.SetActive(false);

        yield return new WaitForSeconds(RespawnDelay);

        if (_respawnPoints.TryGetValue(player, out Vector3 respawnPos))
        {
            player.transform.position = respawnPos;
        }

        player.SetActive(true);
        TogglePlayerControl(player, true);

        _isDead[player] = false;
    }

    private void TogglePlayerControl(GameObject player, bool enable)
    {
        player.GetComponent<PlayerMove>().enabled = enable;
        player.GetComponent<PlayerJump>().enabled = enable;
    }
}
