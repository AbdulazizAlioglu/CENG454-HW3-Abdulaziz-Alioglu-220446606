using UnityEngine;

public interface IEnemyStrategy
{
    void Execute(Transform enemy, Transform target);
}