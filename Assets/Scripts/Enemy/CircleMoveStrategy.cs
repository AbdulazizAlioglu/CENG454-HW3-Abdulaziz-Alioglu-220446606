using UnityEngine;

public class CircleMoveStrategy : MonoBehaviour, IEnemyStrategy
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float circleRadius = 5f;
    private float angle = 0f;

    public void Execute(Transform enemy, Transform target)
    {
        angle += speed * Time.deltaTime;
        float x = target.position.x + Mathf.Cos(angle) * circleRadius;
        float z = target.position.z + Mathf.Sin(angle) * circleRadius;
        enemy.position = Vector3.Lerp(enemy.position, new Vector3(x, enemy.position.y, z), Time.deltaTime * speed);
        enemy.LookAt(target);
    }
}