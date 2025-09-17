using UnityEngine;

public class PlayerAutoMove : MonoBehaviour
{
    private Rigidbody rb;
    private MovingObject currentPlatform;
    private bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (isDead) return;
        if (currentPlatform == null) return;

        Vector3 velocity = currentPlatform.GetCurrentVelocity();
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }

    void OnCollisionEnter(Collision col)
    {
        if (isDead) return;

        if (col.gameObject.CompareTag("MoveGround"))
        {
            MovingObject mo = col.gameObject.GetComponent<MovingObject>();
            if (mo != null) currentPlatform = mo;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("MoveGround"))
            currentPlatform = null;
    }

    // €–Só‘Ô‚ÌØ‚è‘Ö‚¦
    public void SetDead(bool dead)
    {
        isDead = dead;
        if (dead) currentPlatform = null; // €–S‚Í’Ç]‰ğœ
    }
}

