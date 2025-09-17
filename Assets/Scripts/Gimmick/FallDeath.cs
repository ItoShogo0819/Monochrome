using UnityEngine;

public class FallDeath : MonoBehaviour
{
    public float FallLimitY = -3;

    private PlayerColor _playerColor; // �v���C���[����p�i�I�v�V�����j

    void Start()
    {
        _playerColor = GetComponent<PlayerColor>();
    }

    void Update()
    {
        if (transform.position.y < FallLimitY)
        {
            // DeadManager �� Singleton �o�R�Ŏ��S����
            if (DeadManager.Instance != null)
            {
                DeadManager.Instance.Die(gameObject);
            }
        }
    }
}
