using UnityEngine;
using System.Collections;

public class DeadHead : MonoBehaviour
{
    [Header("ê›íË")]
    public float AbsordDuration = 0.5f;
    public GameObject AbsordEffectPrefab;

    [Header("èÛë‘")]
    public bool IsDead = false;

    [Header("òAåg")]
    public GameObject RespawnPoint;
    public GameObject[] PlayerModels;

    private PlayerMove _move;
    private PlayerJump _jump;
    private PlayerSwitcher _switch;

    private int _currentIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _move = GetComponent<PlayerMove>();
        _jump = GetComponent<PlayerJump>();
        _switch = GetComponent<PlayerSwitcher>();
    }

    public void SetCurrentIndex(int index)
    {
        if(index >= 0 && index < PlayerModels.Length)
        {
            _currentIndex = index;
        }
    }

    public void Die()
    {
        if (IsDead) return;
        IsDead = true;

        if(_move) _move.enabled = false;
        if(_jump) _jump.enabled = false;
        if(_switch) _switch.enabled = false;

        StartCoroutine(AbsordAndRespawn());
    }

    IEnumerator AbsordAndRespawn()
    {
        if(AbsordEffectPrefab != null)
        {
            Instantiate(AbsordEffectPrefab,transform.position, Quaternion.identity);
        }

        if(PlayerModels != null && _currentIndex <  PlayerModels.Length && PlayerModels[_currentIndex] != null)
        {
            PlayerModels[_currentIndex].SetActive(false);
        }

        yield return new WaitForSeconds(AbsordDuration);

        if(RespawnPoint != null)
        {
            transform.position = RespawnPoint.transform.position;
        }

        if (PlayerModels != null && _currentIndex < PlayerModels.Length && PlayerModels[_currentIndex] != null)
        {
            PlayerModels[_currentIndex].SetActive(true);
        }

        if (_move) _move.enabled = true;
        if (_jump) _jump.enabled = true;
        if(_switch) _switch.enabled = true;

        IsDead = false;
    }
}
