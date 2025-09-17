using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public PlayerColorType ObstacleColor;

    void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        PlayerColor pc = other.gameObject.GetComponent<PlayerColor>();
        if (pc != null && pc.playerColor == ObstacleColor)
        {
            if (DeadManager.Instance != null)
            {
                DeadManager.Instance.Die(other.gameObject);
            }
        }
    }
}
