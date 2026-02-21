using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 12f;
    private float yMax;

    public void SetLimit(float limit) => yMax = limit;
    
    void Start()
    {
        
    }


    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        if (transform.position.y > yMax) 
        {
            Destroy(gameObject);
        }
    }
}
