using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Scrollbar hpBar;
    private float maxHp = 1f;

    void Start()
    {
        if (hpBar != null)
            hpBar.size = maxHp;
    }

    public void TakeDamage(float amount)
    {
        if (hpBar == null) return;

        hpBar.size -= amount;
        hpBar.size = Mathf.Clamp(hpBar.size, 0f, 1f);

        if (hpBar.size <= 0f)
        {
            hpBar.size = 0f; // paksa jadi 0 persis
            Debug.Log("Enemy Mati!");
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        // Sembunyikan HP bar ketika enemy dihancurkan
        if (hpBar != null)
            hpBar.gameObject.SetActive(false);
    }
}