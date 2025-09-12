using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player"))return;

        DeadManager deadManager = FindAnyObjectByType<DeadManager>();
        if(deadManager != null)
        {
            deadManager.UpdateRespawnPoint(other.gameObject, transform.position);
            Debug.Log($"{other.name}のリスポーン地点を更新:{transform.position}");
        }
    }
}
