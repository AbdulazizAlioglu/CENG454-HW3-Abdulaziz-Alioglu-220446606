using UnityEngine;
using UnityEngine.Events;

public class CoreHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;

    public UnityEvent OnHealthChanged;
    public UnityEvent OnCoreDead;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        float percent = currentHealth / maxHealth;
        GameEventManager.Instance?.ReportCoreHealthChanged(percent);
        OnHealthChanged?.Invoke();

        if (IsDead())
        {
            GameEventManager.Instance?.ReportCoreDestroyed();
            OnCoreDead?.Invoke();
        }
    }

    public bool IsDead() => currentHealth <= 0;
}