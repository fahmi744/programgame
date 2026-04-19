using UnityEngine;

public class DragonPatrol : MonoBehaviour
{
    public float speed = 2f;
    public float leftLimit = -4f;
    public float rightLimit = 4f;

    bool moveRight = true;

    Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        if (moveRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            transform.localScale = new Vector3(
                Mathf.Abs(originalScale.x),
                originalScale.y,
                originalScale.z
            );

            if (transform.position.x >= rightLimit)
                moveRight = false;
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);

            transform.localScale = new Vector3(
                -Mathf.Abs(originalScale.x),
                originalScale.y,
                originalScale.z
            );

            if (transform.position.x <= leftLimit)
                moveRight = true;
        }
    }
}