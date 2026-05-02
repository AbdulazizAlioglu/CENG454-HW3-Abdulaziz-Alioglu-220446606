using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotateSpeed = 10f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    private void Update()
    {
        HandleMovement();
        HandleShooting();
    }

    private void HandleMovement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(h, 0, v) * moveSpeed * Time.deltaTime;
        transform.Translate(move, Space.World);

        if (move != Vector3.zero)
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(move), rotateSpeed * Time.deltaTime);
    }

    private void HandleShooting()
{
    if (Input.GetKeyDown(KeyCode.Space))
    {
        if (firePoint != null)
        {
            GameObject b = ObjectPool.Instance.GetBullet(firePoint.position, firePoint.rotation);
            b.GetComponent<Bullet>().OnSpawn();
        }
    }
}
}