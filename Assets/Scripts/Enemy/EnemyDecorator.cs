using UnityEngine;

public abstract class EnemyDecorator : MonoBehaviour, IDamageable, IPoolable
{
    protected Enemy wrappedEnemy;

    public void Init(Enemy enemy)
    {
        wrappedEnemy = enemy;
    }

    public virtual void TakeDamage(float amount)
    {
        wrappedEnemy.TakeDamage(amount);
    }

    public virtual bool IsDead()
    {
        return wrappedEnemy.IsDead();
    }

    public virtual void OnSpawn()
    {
        wrappedEnemy.OnSpawn();
    }

    public virtual void OnDespawn()
    {
        wrappedEnemy.OnDespawn();
    }
}