using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Obstacle : MonoBehaviour
{
    public PlayerColorType ObstacleColor;

    void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Player")) return;  // �v���C���[�ȊO����

        PlayerColor pc = other.gameObject.GetComponent<PlayerColor>();  // �v���C���[�̐F�擾
        if (pc != null && pc.playerColor == ObstacleColor)               // ���F����
        {
            if (DeadManager.Instance != null)                           // DeadManager �o�R�Ŏ��S����
            {
                DeadManager.Instance.Die(other.gameObject);
            }
        }
    }
}
