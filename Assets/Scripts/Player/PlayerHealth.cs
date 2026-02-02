using UnityEngine;

[DisallowMultipleComponent]
public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private float invulnerabilitySeconds = 0.75f;

    public int CurrentHealth { get; private set; }
    public int MaxHealth => maxHealth;

    private float invulnTimer;
    private bool isDead;

    private Rigidbody rb;
    private PlayerController playerController;

    private void Awake()
    {
        CurrentHealth = maxHealth;
        rb = GetComponent<Rigidbody>();
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (invulnTimer > 0f)
            invulnTimer -= Time.deltaTime;
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;
        if (amount <= 0) return;
        if (invulnTimer > 0f) return;

        CurrentHealth -= amount;
        invulnTimer = invulnerabilitySeconds;

        Debug.Log($"Player HP: {CurrentHealth}/{maxHealth}");

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        Debug.Log("Player died!");
        
        if (playerController != null) playerController.enabled = false;
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        
    }
    
}
