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
        if (MainCamera.activeSelf)          // ���C���J�������A�N�e�B�u
        {
            BlackPlayerMove.IsControllable = true;   // �������
            WhitePlayerMove.IsControllable = false;  // ������s��

            BlackPlayerJump.JumpControl = true;      // ���W�����v��
            WhitePlayerJump.JumpControl = false;    // ���W�����v�s��
        }
        else if (SabCamera.activeSelf)      // �T�u�J�������A�N�e�B�u
        {
            BlackPlayerMove.IsControllable = false;  // ������s��
            WhitePlayerMove.IsControllable = true;   // �������

            BlackPlayerJump.JumpControl = false;     // ���W�����v�s��
            WhitePlayerJump.JumpControl = true;      // ���W�����v��
        }
    }
}
