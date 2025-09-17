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
        _objRend = GetComponent<Renderer>();
        _initialType = CurrentType; // 最初の色を記録
        ApplyColor();
    }

    // 現在の色をレンダーに反映
    void ApplyColor()
    {
        if (_objRend != null)
        {
            if (CurrentType == PlayerColorType.Black)
            {
                _objRend.material.color = ColorA;
            }
            else
            {
                _objRend.material.color = ColorB;
            }
        }
    }

    // 色を反転させる
    public void ToggleColor()
    {
        if (CurrentType == PlayerColorType.Black)
        {
            CurrentType = PlayerColorType.White;
        }
        else
        {
            CurrentType = PlayerColorType.Black;
        }
        ApplyColor();
    }

    // 元の色に戻す
    public void ResetInitialColor()
    {
        CurrentType = _initialType;
        ApplyColor();
    }

    void OnCollisionEnter(Collision col)
    {
        if (!col.gameObject.CompareTag("Player")) return;

        PlayerColor pc = col.gameObject.GetComponent<PlayerColor>();
        if (pc == null) return;

        // 同色なら死亡
        if (pc.playerColor == CurrentType)
        {
            DeadManager.Instance.Die(col.gameObject);
        }
    }

    void OnCollisionStay(Collision col)
    {
        if (!col.gameObject.CompareTag("Player")) return;

        PlayerColor pc = col.gameObject.GetComponent<PlayerColor>();
        if (pc == null) return;

        // 同色なら死亡（色が変化した場合に対応）
        if (pc.playerColor == CurrentType)
        {
            DeadManager.Instance.Die(col.gameObject);
        }
    }
}
