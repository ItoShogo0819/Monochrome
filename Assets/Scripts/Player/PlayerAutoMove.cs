using UnityEngine;

public class PlayerAutoMove : MonoBehaviour
{
    private Rigidbody rb;
    private MovingObject currentPlatform;
    private bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();    // Rigidbodyæ“¾
    }

    void FixedUpdate()
    {
        if (isDead) return;                // €–S’†‚Í“®‚©‚³‚È‚¢
        if (currentPlatform == null) return; // æ‚Á‚Ä‚¢‚È‚¢ê‡‚àˆ—•s—v

        Vector3 velocity = currentPlatform.GetCurrentVelocity(); // ‰Â“®°‘¬“xæ“¾
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime); // ƒvƒŒƒCƒ„[’Ç]
    }

    void OnCollisionEnter(Collision col)
    {
        if (isDead) return;

        if (col.gameObject.CompareTag("MoveGround")) // ‰Â“®°”»’è
        {
            MovingObject mo = col.gameObject.GetComponent<MovingObject>();
            if (mo != null) currentPlatform = mo;    // ’Ç]‘ÎÛİ’è
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("MoveGround"))
            currentPlatform = null;  // —£‚ê‚½‚ç’Ç]‰ğœ
    }

    // €–Só‘Ô‚ÌØ‚è‘Ö‚¦
    public void SetDead(bool dead)
    {
        isDead = dead;
        if (dead) currentPlatform = null; // €–S‚Í’Ç]‰ğœ
    }
}

