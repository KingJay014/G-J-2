using UnityEngine;

public class GroundTile : MonoBehaviour
{
    SpawnManager spawnManager;

    float speed = 20f;
    //bool nextSpawned = false;
    float travelMax = 300f;


    void Start() 
    {
        spawnManager = GameObject.FindObjectOfType<SpawnManager>();
    }

    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed, Space.Self);
        if (transform.position.y > travelMax)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            spawnManager.SpawnTile();
        }
    }
}
