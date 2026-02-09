
using TMPro;
using UnityEngine;

public class HealthTextUI : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private TMP_Text healthText;

    private void Start()
    {
        if (playerHealth == null || healthText == null)
        {
            Debug.LogError("HealthTextUI: Assign PlayerHealth and TMP_Text.");

            enabled = false;
            return;
        }

        UpdateText();
    }

    private void Update()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        healthText.text = $"{playerHealth.CurrentHealth}/{ playerHealth.MaxHealth}";
      }
}