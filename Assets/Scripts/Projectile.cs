using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 12f;
    [SerializeField] private float lifeTime = 3f;

    public Vector2 direction = Vector2.up;
 
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }


    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
