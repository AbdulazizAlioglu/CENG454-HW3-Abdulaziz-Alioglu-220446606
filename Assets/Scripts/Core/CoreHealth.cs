using UnityEngine;
using UnityEngine.Events;

public class CoreHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;

    public UnityEvent<float> OnHealthChanged;
    public UnityEvent OnCoreDead;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        OnHealthChanged?.Invoke(currentHealth / maxHealth);

        if (IsDead())
            OnCoreDead?.Invoke();
    }

    public bool IsDead() => currentHealth <= 0;

    public float GetHealthPercent() => currentHealth / maxHealth;
}