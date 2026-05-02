using UnityEngine;

public class DirectMoveStrategy : MonoBehaviour, IEnemyStrategy
{
    [SerializeField] private float speed = 3f;

    public void Execute(Transform enemy, Transform target)
    {
        Vector3 direction = (target.position - enemy.position).normalized;
        enemy.position += direction * speed * Time.deltaTime;
        enemy.LookAt(target);
    }

    public float GetSpeed() => speed;
    public void SetSpeed(float newSpeed) => speed = newSpeed;
}