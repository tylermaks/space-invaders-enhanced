using UnityEngine;

public class EnemyManager : MonoBehaviour
{
   [Header("Grid Setup")]
    public GameObject enemyPrefab;
    public int rows = 4;
    public int columns = 5;
    public float spacingX = 1.5f;
    public float spacingY = 1.2f;

    [Header("Movement")]
    public float moveSpeed = 1.0f;


    void Start()
    {
      SpawnGrid();   
    }

    void SpawnGrid()
    {
        float startX = -(columns - 1) * spacingX / 2f;

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                Vector3 pos = new Vector3(startX + (c * spacingX), r * spacingY + 8f, 0);
                Instantiate(enemyPrefab, pos, Quaternion.identity, transform);
            }
        }
    }


    void Update()
    {
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
    }
}
