using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private HashSet<GameObject> _activatedPlayers = new HashSet<GameObject>();

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (_activatedPlayers.Contains(other.gameObject)) return;

        PlayerDeadHandler deadHandler = other.GetComponent<PlayerDeadHandler>();
        if (deadHandler != null)
        {
            deadHandler.RespawnPoint = this.gameObject;
            _activatedPlayers.Add(other.gameObject); // このプレイヤーだけフラグ立てる
            Debug.Log("リスポーン地点を更新: " + this.name);
        }
    }
}
