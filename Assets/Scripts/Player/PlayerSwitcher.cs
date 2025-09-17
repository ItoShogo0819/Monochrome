using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject SabCamera;

    public PlayerMove BlackPlayerMove;
    public PlayerMove WhitePlayerMove;

    public PlayerJump BlackPlayerJump;
    public PlayerJump WhitePlayerJump;

    void Update()
    {
        if (MainCamera.activeSelf)          // メインカメラがアクティブ
        {
            BlackPlayerMove.IsControllable = true;   // 黒操作可
            WhitePlayerMove.IsControllable = false;  // 白操作不可

            BlackPlayerJump.JumpControl = true;      // 黒ジャンプ可
            WhitePlayerJump.JumpControl = false;    // 白ジャンプ不可
        }
        else if (SabCamera.activeSelf)      // サブカメラがアクティブ
        {
            BlackPlayerMove.IsControllable = false;  // 黒操作不可
            WhitePlayerMove.IsControllable = true;   // 白操作可

            BlackPlayerJump.JumpControl = false;     // 黒ジャンプ不可
            WhitePlayerJump.JumpControl = true;      // 白ジャンプ可
        }
    }
}
