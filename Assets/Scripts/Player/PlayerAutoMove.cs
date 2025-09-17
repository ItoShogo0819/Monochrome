using UnityEngine;

public class PlayerAutoMove : MonoBehaviour
{
    private Rigidbody rb;
    private MovingObject currentPlatform;
    private bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();    // Rigidbody�擾
    }

    void FixedUpdate()
    {
        if (isDead) return;                // ���S���͓������Ȃ�
        if (currentPlatform == null) return; // ����Ă��Ȃ��ꍇ�������s�v

        Vector3 velocity = currentPlatform.GetCurrentVelocity(); // �������x�擾
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime); // �v���C���[�Ǐ]
    }

    void OnCollisionEnter(Collision col)
    {
        if (isDead) return;

        if (col.gameObject.CompareTag("MoveGround")) // ��������
        {
            MovingObject mo = col.gameObject.GetComponent<MovingObject>();
            if (mo != null) currentPlatform = mo;    // �Ǐ]�Ώېݒ�
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("MoveGround"))
            currentPlatform = null;  // ���ꂽ��Ǐ]����
    }

    // ���S��Ԃ̐؂�ւ�
    public void SetDead(bool dead)
    {
        isDead = dead;
        if (dead) currentPlatform = null; // ���S���͒Ǐ]����
    }
}

