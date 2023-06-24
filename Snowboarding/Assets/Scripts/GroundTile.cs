using UnityEngine;

public class GroundTile : MonoBehaviour
{
    [SerializeField] GameObject nextTerrain;
    float speed = 5f;
    bool nextSpawned = false;

    SpawnManager spawnManager;

    void Start() 
    {
        spawnManager = GameObject.FindObjectOfType<SpawnManager>();
    }

    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed, Space.Self);
        if (transform.position.y >= 0 && !nextSpawned)
        {
            spawnManager.SpawnTile();
            nextSpawned = true;
        }
        if (transform.position.y > 25f)
        {
            Destroy(gameObject);
        }
    }
}
