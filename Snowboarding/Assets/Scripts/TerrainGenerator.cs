using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] GameObject nextTerrain;
    bool nextSpawned = false;

    void Start() 
    {
        Instantiate(nextTerrain, (transform.localPosition) + new Vector3(0, 0, 5), nextTerrain.transform.rotation);
    }

    // void Update()
    // {
    //     transform.Translate(Vector3.back * Time.deltaTime * 5f, Space.Self);
    //     if (transform.position.y >= 0 && !nextSpawned)
    //     {
    //         Instantiate(nextTerrain, GetComponentInChildren<Transform>().transform.position, nextTerrain.transform.rotation);
    //         nextSpawned = true;
    //     }
    // }
}
