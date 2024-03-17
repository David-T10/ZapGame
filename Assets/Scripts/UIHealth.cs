using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIHealth : MonoBehaviour
{
    private float maxHealth = 100;
    private float currentHealth;
    [SerializeField] private Image healthBarFill;
    [SerializeField] private TextMeshProUGUI healthBarText;
    [SerializeField] private Gradient colourGradient;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBarText.text = "Health: " + currentHealth;
    }

    public void UpdateHeath(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        healthBarText.text = "Health: " + currentHealth;
        UpdateHealthBarOnUI();
    }

    private void UpdateHealthBarOnUI()
    {
        float targetFillAmount = currentHealth / maxHealth;
        healthBarFill.fillAmount = targetFillAmount;
        healthBarFill.color = colourGradient.Evaluate(targetFillAmount);
    }

    public float GetCurrentHealth() 
    {
        return currentHealth;
    }
}
