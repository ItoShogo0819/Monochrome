using UnityEngine;

public class ColorSwitch : MonoBehaviour
{
    public ColorDeathObject Target;  // 連携オブジェクト

    private bool _isPressed = false;     // プレイヤーが乗っているか
    private bool _hasFlipped = false;    // 反転済みか

    void Update()
    {
        // プレイヤーが乗っていてまだ反転していない場合
        if (_isPressed && Target != null && !_hasFlipped)
        {
            Target.ToggleColor();          // 一度だけ色を反転
            _hasFlipped = true;           // 反転済みにする
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (!col.gameObject.CompareTag("Player")) return; // プレイヤー以外無視

        _isPressed = true;              // プレイヤーが乗った
        _hasFlipped = false;            // フラグリセットして再反転可能に
    }

    void OnCollisionExit(Collision col)
    {
        if (!col.gameObject.CompareTag("Player")) return; // プレイヤー以外無視

        _isPressed = false;             // プレイヤーが離れた

        if (Target != null)
        {
            Target.ResetInitialColor();  // 離れたら色を元に戻す
        }
    }
}
