using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerGlitchJumpForwardTest : MonoBehaviour
{
    private Rigidbody rb;

    [Header("グリッチジャンプ設定")]
    public float jumpForce = 15f;
    public float upwardFactor = 0.8f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionStay(Collision col)
    {
        if (!col.gameObject.CompareTag("MoveGround")) return;

        MovingObject mo = col.gameObject.GetComponent<MovingObject>();
        if (mo == null) return;

        Vector3 platformVelocity = mo.GetCurrentVelocity();

        // 前方向に動いているときだけ発動
        if (platformVelocity.z > 0.5f) // z方向が前に進んでいるか
        {
            Vector3 jumpDirection = transform.forward + Vector3.up * upwardFactor;
            rb.isKinematic = false; // 念のため
            rb.linearVelocity = jumpDirection.normalized * jumpForce;
            Debug.Log("前方向グリッチジャンプ発動！");
        }
    }
}