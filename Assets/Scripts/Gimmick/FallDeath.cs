using UnityEngine;

public class FallDeath : MonoBehaviour
{
    public float FallLimitY = -3;

    private PlayerColor _playerColor; // �v���C���[����p�i�I�v�V�����j

    void Start()
    {
        _playerColor = GetComponent<PlayerColor>();  // PlayerColor �R���|�[�l���g�擾
    }

    void Update()
    {
        // Y���W���������E����������玀�S
        if (transform.position.y < FallLimitY)
        {
            if (DeadManager.Instance != null)
            {
                DeadManager.Instance.Die(gameObject);  // ���S�����Ăяo��
            }
        }
    }
}
