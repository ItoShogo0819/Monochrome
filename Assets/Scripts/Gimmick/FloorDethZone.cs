using UnityEngine;

public class FloorDethZone : MonoBehaviour
{
    private FloorColor _floorColor;

    void Start()
    {
        _floorColor = GetComponent<FloorColor>();
    }

    void OnCollisionEnter(Collision other)
    {
        if(!other.gameObject.CompareTag("Player"))return;

        PlayerColor playerColor = other.gameObject.GetComponent<PlayerColor>();
        if(playerColor != null && playerColor.playerColor == _floorColor.floorColor)
        {
            DeadManager dm = FindAnyObjectByType<DeadManager>();
            if(dm != null)
            {
                dm.Die(other.gameObject);
            }
        }
    }
}
