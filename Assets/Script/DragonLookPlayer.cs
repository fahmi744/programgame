using UnityEngine;

public class DragonLookPlayer : MonoBehaviour
{
    public Transform player;

    Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        if (player.position.x < transform.position.x)
        {
            // Player di kiri → naga lihat kiri
            transform.localScale = new Vector3(
                -Mathf.Abs(originalScale.x),
                originalScale.y,
                originalScale.z
            );
        }
        else
        {
            // Player di kanan → naga lihat kanan
            transform.localScale = new Vector3(
                Mathf.Abs(originalScale.x),
                originalScale.y,
                originalScale.z
            );
        }
    }
}