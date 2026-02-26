using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float health = 3f;

    [Header("Combat")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float minFireRate = 2f;
    [SerializeField] private float maxFireRate = 7f;
    [SerializeField] private float projectileSpeed = 8f;

    private float nextFireTime;

    private void Start()
    {
        nextFireTime = Time.time + Random.Range(minFireRate, maxFireRate);
    }

    private void Update()
    {
        if (Time.time >= nextFireTime)
        {
            FireProjectile();
            nextFireTime = Time.time + Random.Range(minFireRate, maxFireRate);
        }
    }

    void FireProjectile()
    {
        GameObject spawnedProjectile =Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        Projectile pScript = spawnedProjectile.GetComponent<Projectile>();
        if (pScript != null)
        {
            pScript.direction = Vector2.down;
        } 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerProjectile"))
        {
            TakeDamage(1);
            Destroy(other.gameObject);
        }
    }

    void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
