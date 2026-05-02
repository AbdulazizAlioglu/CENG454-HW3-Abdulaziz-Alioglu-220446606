using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance { get; private set; }

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int bulletPoolSize = 20;
    [SerializeField] private int enemyPoolSize = 10;

    private Queue<GameObject> bulletPool = new Queue<GameObject>();
    private Queue<GameObject> enemyPool = new Queue<GameObject>();

    void Awake() 
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        InitPool(bulletPrefab, bulletPool, bulletPoolSize);
        InitPool(enemyPrefab, enemyPool, enemyPoolSize);
    }

    private void InitPool(GameObject prefab, Queue<GameObject> pool, int size)
    {
        for (int i = 0; i < size; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public GameObject GetBullet(Vector3 pos, Quaternion rot)
    {
        return GetFromPool(bulletPool, bulletPrefab, pos, rot);
    }

    public GameObject GetEnemy(Vector3 pos, Quaternion rot)
    {
        return GetFromPool(enemyPool, enemyPrefab, pos, rot);
    }

    private GameObject GetFromPool(Queue<GameObject> pool, GameObject prefab, Vector3 pos, Quaternion rot)
    {
        GameObject obj;
        if (pool.Count > 0)
            obj = pool.Dequeue();
        else
            obj = Instantiate(prefab);

        obj.transform.position = pos;
        obj.transform.rotation = rot;
        obj.SetActive(true);
        return obj;
    }

    public void ReturnBullet(GameObject obj)
    {
        obj.SetActive(false);
        bulletPool.Enqueue(obj);
    }

    public void ReturnEnemy(GameObject obj)
    {
        obj.SetActive(false);
        enemyPool.Enqueue(obj);
    }
}