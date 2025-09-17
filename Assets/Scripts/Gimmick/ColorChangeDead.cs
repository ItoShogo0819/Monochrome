using UnityEngine;

public class ColorChangeDead : MonoBehaviour
{
    [Header("色設定")]
    public Color colorA = Color.white;
    public Color colorB = Color.black;
    public PlayerColorType TypeA = PlayerColorType.White;
    public PlayerColorType TypeB = PlayerColorType.Black;

    [Header("切替設定")]
    public float Interval = 1f;
    private float _timer;
    private bool _isColorA = true;

    private Renderer _rend;

    void Start()
    {
        _rend = GetComponent<Renderer>();  // レンダラー取得
        _rend.material.color = colorA;     // 初期色設定
        _timer = Interval;                 // タイマー初期化
    }

    void Update()
    {
        _timer -= Time.deltaTime;          // タイマー減算
        if (_timer <= 0f)
        {
            _isColorA = !_isColorA;        // 色切替

            if (_isColorA)
            {
                _rend.material.color = colorA; // 色Aに変更
            }
            else
            {
                _rend.material.color = colorB; // 色Bに変更
            }

            _timer = Interval;             // タイマーリセット
        }
    }

    void OnCollisionStay(Collision other)
    {
        if (!other.gameObject.CompareTag("Player")) return; // プレイヤー以外は無視

        PlayerColor pc = other.gameObject.GetComponent<PlayerColor>();
        if (pc == null) return; // PlayerColorコンポーネントがなければ無視

        // 現在の色とプレイヤー色が一致したら死亡処理
        if ((_isColorA && pc.playerColor == TypeA) || (!_isColorA && pc.playerColor == TypeB))
        {
            if (DeadManager.Instance != null)
            {
                DeadManager.Instance.Die(other.gameObject); // 死亡処理呼び出し
            }
        }
    }
}
