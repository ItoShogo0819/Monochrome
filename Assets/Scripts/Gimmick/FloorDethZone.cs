using UnityEngine;

public class FloorDethZone : MonoBehaviour
{
    private FloorColor _floorColor;

    void Start()
    {
        _floorColor = GetComponent<FloorColor>();  // FloorColor �R���|�[�l���g�擾
    }

    void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Player")) return;  // �v���C���[�ȊO�͖���

        PlayerColor playerColor = other.gameObject.GetComponent<PlayerColor>();  // �v���C���[�̐F���擾
        if (playerColor != null && playerColor.playerColor == _floorColor.floorColor)
        {
            // �v���C���[�F�Ə��̐F����v�����玀�S����
            if (DeadManager.Instance != null)
            {
                DeadManager.Instance.Die(other.gameObject);  // ���S�����Ăяo��
            }
        }
    }
}
