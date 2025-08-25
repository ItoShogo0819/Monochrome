using UnityEngine;

public class FallDeath : MonoBehaviour
{
    public float FallLimitY = -3;
    private PlayerDeadHandler deadHandler;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        deadHandler = GetComponent<PlayerDeadHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!deadHandler.IsDead && transform.position.y < FallLimitY)
        {
            deadHandler.Die();
        }
    }
}
