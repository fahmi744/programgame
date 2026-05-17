using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Setting")]
    public float speed = 10f;
    public float durasi = 1f;
    public float damage = 0.2f;

    private void Start()
    {
        // Ignore collision sama player
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            Physics2D.IgnoreCollision(
                GetComponent<Collider2D>(),
                player.GetComponent<Collider2D>()
            );
        }

        Destroy(gameObject, durasi);
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth eh = collision.gameObject.GetComponent<EnemyHealth>();
            if (eh != null)
            {
                eh.TakeDamage(damage);
            }
        }
        Destroy(gameObject);
    }
}