using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private bool _actived = false;

    void OnTriggerEnter(Collider other)
    {
        if (_actived) return;

        if (other.CompareTag("Player"))
        {
            PlayerDeadHandler deadHandler = other.GetComponent<PlayerDeadHandler>();
            if (deadHandler != null )
            {
                deadHandler.RespawnPoint = this.gameObject;
                _actived = true;
                Debug.Log("���X�|�[���n�_���X�V:" + this.name);
            }
        }
    }
}
