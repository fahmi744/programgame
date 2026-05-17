using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Attack Setting")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float jarak = 0.4f;

    void Shoot()
    {
        Vector3 posisiMenembak = firePoint.position + transform.up * jarak;
        Instantiate(bulletPrefab, posisiMenembak, transform.rotation);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
}