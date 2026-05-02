using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform coreTransform;
    [SerializeField] private float spawnInterval = 3f;
    [SerializeField] private float spawnRadius = 15f;
    [SerializeField] private int maxEnemies = 10;

    private int currentEnemies = 0;

    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            if (currentEnemies < maxEnemies)
                SpawnEnemy();
        }
    }

    private void SpawnEnemy()
{
    float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
    Vector3 spawnPos = new Vector3(
        Mathf.Cos(angle) * spawnRadius,
        0,
        Mathf.Sin(angle) * spawnRadius
    );

    GameObject enemyObj = ObjectPool.Instance.GetEnemy(spawnPos, Quaternion.identity);
    Enemy enemy = enemyObj.GetComponent<Enemy>();

    IEnemyStrategy strategy = enemyObj.GetComponent<IEnemyStrategy>();
    enemy.Initialize(coreTransform, strategy);
    enemy.OnSpawn();

    enemy.OnEnemyDied.AddListener(() =>
    {
        currentEnemies--;
        ObjectPool.Instance.ReturnEnemy(enemyObj);
    });
    currentEnemies++;

    // Her 3. düşman hızlı olsun
    if (currentEnemies % 3 == 0)
    {
        SpeedBoostDecorator decorator = enemyObj.AddComponent<SpeedBoostDecorator>();
        decorator.Init(enemy);
        decorator.Apply();
    }
}
}