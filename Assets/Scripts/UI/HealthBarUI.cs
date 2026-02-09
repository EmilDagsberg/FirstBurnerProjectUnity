using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Slider slider;

    void Start()
    {
        // 1. Check for nulls first
        if (playerHealth == null || slider == null)
        {
            Debug.LogError("HealthBarUI: Assign PlayerHealth and Slider.");
            enabled = false;
            return; // Stops here if missing
        }

        // 2. This runs only if references exist
        UpdateBar();
    }

    void Update()
    {
        UpdateBar();
    } // 3. Closed Update here

    private void UpdateBar()
    {
        // Ensure floating point division
        slider.value = (float)playerHealth.CurrentHealth / playerHealth.MaxHealth;
    }
}