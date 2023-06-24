using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject groundPrefab;
    private GameObject previousGround = null;
    private Vector3 nextPosition = Vector3.zero;
    private int initialSpawnAmount = 5;

    void Start()
    {
        for (int i = 0; i < initialSpawnAmount; i++)
        {
            SpawnTile();
        }
    }

    public void SpawnTile()
    {
        GameObject temp = Instantiate(groundPrefab, previousGround == null ? nextPosition : previousGround.transform.GetChild(1).transform.position, groundPrefab.transform.rotation);
        previousGround = temp;
    }
}
