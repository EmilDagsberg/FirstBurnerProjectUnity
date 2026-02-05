using UnityEngine;

[DisallowMultipleComponent]
public class ZombieDamage : MonoBehaviour
{
    [SerializeField] private int damage = 1;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Zombie hit: " + other.name);
        if (!other.CompareTag("Player")) return;

        PlayerHealth health = other.GetComponentInParent<PlayerHealth>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }
    }
}