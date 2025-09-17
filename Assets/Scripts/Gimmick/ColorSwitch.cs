using UnityEngine;

public class ColorSwitch : MonoBehaviour
{
    public ColorDeathObject Target;  // 連携オブジェクト

    private bool _isPressed = false;     // プレイヤーが乗っているか
    private bool _hasFlipped = false;    // 反転済みか

    void Update()
    {
        if (_isPressed && Target != null && !_hasFlipped)
        {
            Target.ToggleColor();  // 一回だけ反転
            _hasFlipped = true;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (!col.gameObject.CompareTag("Player")) return;

        _isPressed = true;
        _hasFlipped = false; // 踏むたびにフラグリセット
    }

    void OnCollisionExit(Collision col)
    {
        if (!col.gameObject.CompareTag("Player")) return;

        _isPressed = false;

        if (Target != null)
        {
            Target.ResetInitialColor();  // 離れたら元に戻す
        }
    }
}
