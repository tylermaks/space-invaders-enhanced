using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;
    [Range(0.1f, 1.0f)] [SerializeField] private float boundaryPadding = 0.15f;

    [Header("Combat")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    
    private float xMin, xMax, yMax;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        CalculateBounds();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void CalculateBounds()
    {
        Camera cam = Camera.main;
        float screenHeight = cam.orthographicSize * 2f;
        float screenWidth = screenHeight * cam.aspect;
        float halfScreenWidth = screenWidth / 2f;
        float halfPlayerWidth = 0f;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            halfPlayerWidth = sr.bounds.extents.x;
        }

        float camX = cam.transform.position.x;
        float camY = cam.transform.position.y;

        xMin = camX - halfScreenWidth + halfPlayerWidth + boundaryPadding;
        xMax = camX + halfScreenWidth - halfPlayerWidth - boundaryPadding;
        yMax = camY + cam.orthographicSize;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, 0);
        float clampedX = Mathf.Clamp(transform.position.x, xMin, xMax);
        transform.position = new Vector2(clampedX, transform.position.y);
    }

    void OnFire(InputValue value)
    {
        if (value.isPressed)
        {
            GameObject newBullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            newBullet.GetComponent<Bullet>().SetLimit(yMax);
        }
    }
}