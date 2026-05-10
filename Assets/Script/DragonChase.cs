using UnityEngine;

public class DragonChase : MonoBehaviour
{
    [Header("Patrol Setting")]
    public float patrolSpeed = 2f;
    public float leftLimit = -4f;
    public float rightLimit = 4f;

    [Header("Chase Setting")]
    public float chaseSpeed = 4f;
    public float detectionRange = 6f;
    public float stopRange = 1f;

    [Header("References")]
    public Transform player; // sekarang muncul di Inspector, drag player ke sini

    bool moveRight = true;
    bool isChasing = false;
    Vector3 originalScale;
    Rigidbody2D rb;

    void Start()
    {
        originalScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.freezeRotation = true;

        // Auto cari player kalau slot kosong
        if (player == null)
        {
            GameObject p = GameObject.FindWithTag("Player");
            if (p != null) 
            {
                player = p.transform;
                Debug.Log("Player ditemukan otomatis!");
            }
            else 
            {
                Debug.LogError("Player tidak ditemukan! Cek tag Player atau drag manual!");
            }
        }
    }

    void Update()
    {
        if (player == null) return;

        float dist = Vector2.Distance(transform.position, player.position);
        isChasing = dist <= detectionRange;

        if (isChasing) ChasePlayer();
        else Patrol();
    }

    void Patrol()
    {
        Vector2 direction = moveRight ? Vector2.right : Vector2.left;
        rb.velocity = direction * patrolSpeed;

        transform.localScale = new Vector3(
            moveRight ? Mathf.Abs(originalScale.x) : -Mathf.Abs(originalScale.x),
            originalScale.y, originalScale.z);

        if (transform.position.x >= rightLimit) moveRight = false;
        if (transform.position.x <= leftLimit) moveRight = true;
    }

    void ChasePlayer()
    {
        float dist = Vector2.Distance(transform.position, player.position);
        if (dist <= stopRange) { rb.velocity = Vector2.zero; return; }

        Vector2 direction = (player.position - transform.position).normalized;
        rb.velocity = direction * chaseSpeed;

        transform.localScale = new Vector3(
            direction.x > 0 ? Mathf.Abs(originalScale.x) : -Mathf.Abs(originalScale.x),
            originalScale.y, originalScale.z);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stopRange);
    }
}