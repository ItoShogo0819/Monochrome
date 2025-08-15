using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject SabCamera;

    public PlayerMove BlackPlayerMove;
    public PlayerMove WhitePlayerMove;

    public PlayerJump BlackPlayerJump;
    public PlayerJump WhitePlayerJump;

    // Update is called once per frame
    void Update()
    {
        if (MainCamera.activeSelf)
        {
            BlackPlayerMove.IsControllable = true;
            WhitePlayerMove.IsControllable = false;

            BlackPlayerJump.JumpControl = true;
            WhitePlayerJump.JumpControl = false;
        }
        else if (SabCamera.activeSelf)
        {
            BlackPlayerMove.IsControllable = false;
            WhitePlayerMove.IsControllable = true;

            BlackPlayerJump.JumpControl = false;
            WhitePlayerJump.JumpControl = true;
        }
    }
}
