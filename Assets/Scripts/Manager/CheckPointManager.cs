using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;  // �v���C���[�ȊO�͖���

        DeadManager deadManager = FindAnyObjectByType<DeadManager>();  // DeadManager�擾
        if (deadManager != null)
        {
            // �v���C���[�̃��X�|�[���n�_�����̃I�u�W�F�N�g�ʒu�ɍX�V
            deadManager.UpdateRespawnPoint(other.gameObject, transform.position);
            Debug.Log($"{other.name}�̃��X�|�[���n�_���X�V:{transform.position}");  // �f�o�b�O�\��
        }
    }
}
