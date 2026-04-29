using UnityEngine;

public class Bullet : MonoBehaviour, IPoolable
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifetime = 3f;
    private float timer;

    public void OnSpawn()
    {
        timer = lifetime;
    }

    public void OnDespawn()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        timer -= Time.deltaTime;
        if (timer <= 0)
            OnDespawn();
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(10f);
            OnDespawn();
        }
    }
}