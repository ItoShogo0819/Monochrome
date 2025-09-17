using UnityEngine;

public class ColorDeathObject : MonoBehaviour
{
    public PlayerColorType CurrentType = PlayerColorType.Black; // 現在の色
    public Color ColorA = Color.black;
    public Color ColorB = Color.white;

    private PlayerColorType _initialType; // 初期色を保持
    private Renderer _objRend;

    void Start()
    {
        _objRend = GetComponent<Renderer>();                    // レンダラー取得
        _initialType = CurrentType;                              // 初期色を記録
        ApplyColor();                                            // 色反映
    }

    // 現在の色をレンダーに反映
    void ApplyColor()
    {
        if (_objRend != null)
        {
            if (CurrentType == PlayerColorType.Black)
            {
                _objRend.material.color = ColorA;               // 黒に設定
            }
            else
            {
                _objRend.material.color = ColorB;               // 白に設定
            }
        }
    }

    // 色を反転させる
    public void ToggleColor()
    {
        if (CurrentType == PlayerColorType.Black)
        {
            CurrentType = PlayerColorType.White;               // 白に変更
        }
        else
        {
            CurrentType = PlayerColorType.Black;               // 黒に変更
        }
        ApplyColor();                                          // レンダラー更新
    }

    // 元の色に戻す
    public void ResetInitialColor()
    {
        CurrentType = _initialType;                            // 初期色に戻す
        ApplyColor();                                          // レンダラー更新
    }

    void OnCollisionEnter(Collision col)
    {
        if (!col.gameObject.CompareTag("Player")) return;      // プレイヤー以外無視

        PlayerColor pc = col.gameObject.GetComponent<PlayerColor>();
        if (pc == null) return;

        // 同色なら死亡
        if (pc.playerColor == CurrentType)
        {
            DeadManager.Instance.Die(col.gameObject);          // 死亡処理呼び出し
        }
    }

    void OnCollisionStay(Collision col)
    {
        if (!col.gameObject.CompareTag("Player")) return;      // プレイヤー以外無視

        PlayerColor pc = col.gameObject.GetComponent<PlayerColor>();
        if (pc == null) return;

        // 色が変化した場合も死亡判定
        if (pc.playerColor == CurrentType)
        {
            DeadManager.Instance.Die(col.gameObject);          // 死亡処理
        }
    }
}
