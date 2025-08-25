using UnityEngine;

public class Obstacle : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerDeadHandler deadHandler = other.GetComponent<PlayerDeadHandler>();
        if(deadHandler != null)
        {
            deadHandler.Die();
        }
    }
}
