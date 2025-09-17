using UnityEngine;

public class ColorChangeDead : MonoBehaviour
{
    [Header("êFê›íË")]
    public Color colorA = Color.white;
    public Color colorB = Color.black;
    public PlayerColorType TypeA = PlayerColorType.White;
    public PlayerColorType TypeB = PlayerColorType.Black;

    [Header("êÿë÷ê›íË")]
    public float Interval = 1f;
    private float _timer;
    private bool _isColorA = true;

    private Renderer _rend;

    void Start()
    {
        _rend = GetComponent<Renderer>();
        _rend.material.color = colorA;
        _timer = Interval;
    }

    void Update()
    {
        _timer -= Time.deltaTime;
        if(_timer <= 0f)
        {
            _isColorA = !_isColorA;
            
            if( _isColorA)
            {
                _rend.material.color = colorA;
            }
            else
            {
                _rend.material.color = colorB;
            }

            _timer = Interval;
        }
    }

    void OnCollisionStay(Collision other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        PlayerColor pc = other.gameObject.GetComponent<PlayerColor>();
        if (pc == null) return;

        if ((_isColorA && pc.playerColor == TypeA) || (!_isColorA && pc.playerColor == TypeB))
        {
            if (DeadManager.Instance != null)
            {
                DeadManager.Instance.Die(other.gameObject);
            }
        }
    }
}
