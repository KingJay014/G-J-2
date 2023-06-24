using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject groundPrefab;
    [SerializeField] GameObject treePrefab;

    private GameObject previousGround = null;
    private Vector3 nextPosition = Vector3.zero;
    private int initialSpawnAmount = 3;
    private int maxTreePerTile = 10;

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

    public void SpawnTreeTile()
    {
        GameObject temp = Instantiate(groundPrefab, previousGround == null ? nextPosition : previousGround.transform.GetChild(1).transform.position, groundPrefab.transform.rotation);
        for (int i = 0; i < maxTreePerTile; i++)
        {
            SpawnTree(temp.transform);
        }
        previousGround = temp;
    }

    private void SpawnTree(Transform parent)
    {
        GameObject tree = Instantiate(treePrefab, parent, false);
        float xRand = Random.Range(-20f, 20f);
        float zRand = Random.Range(0f, 250f);
        tree.transform.localPosition = new Vector3(xRand, 0, zRand);
    }
}
