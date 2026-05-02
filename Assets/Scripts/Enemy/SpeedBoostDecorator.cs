using UnityEngine;

public class SpeedBoostDecorator : EnemyDecorator
{
    [SerializeField] private float speedMultiplier = 2f;

    public void Apply()
    {
        DirectMoveStrategy strategy = wrappedEnemy.GetComponent<DirectMoveStrategy>();
        if (strategy != null)
        {
            strategy.SetSpeed(strategy.GetSpeed() * speedMultiplier);
        }
    }
}