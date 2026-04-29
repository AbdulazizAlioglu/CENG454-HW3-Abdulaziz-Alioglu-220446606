using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IDamageable, IPoolable
{
    [SerializeField] private float maxHealth = 30f;
    [SerializeField] private float damageToCore = 10f;
    private float currentHealth;

    private IEnemyStrategy moveStrategy;
    private Transform target;

    public UnityEvent OnEnemyDied;

    public void Initialize(Transform coreTransform, IEnemyStrategy strategy)
    {
        target = coreTransform;
        moveStrategy = strategy;
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (target == null || moveStrategy == null) return;
        moveStrategy.Execute(transform, target);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Core"))
        {
            IDamageable core = other.GetComponent<IDamageable>();
            if (core != null)
                core.TakeDamage(damageToCore);

            OnDespawn();
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (IsDead())
        {
            OnEnemyDied?.Invoke();
            OnDespawn();
        }
    }

    public bool IsDead() => currentHealth <= 0;

    public void OnSpawn()
    {
        currentHealth = maxHealth;
        gameObject.SetActive(true);
    }

    public void OnDespawn()
    {
        gameObject.SetActive(false);
    }
}