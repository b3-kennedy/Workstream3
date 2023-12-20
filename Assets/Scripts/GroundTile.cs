
using UnityEngine;


public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;

    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnObstacle();
    }
    private void OnTriggerExit(Collider other)
    {
        groundSpawner.Spawn();
        Destroy(gameObject, 4);
    }
    public GameObject obstaclePrefab;
    public GameObject highObstaclePrefab;
    public GameObject FireObstacle;

    void SpawnObstacle()
    {

        int obstaclePositionIndex = Random.Range(3, 5);
        int randomObstacle = Random.Range(0, 3);

        Transform spawnPoint = transform.GetChild(obstaclePositionIndex).transform;

        if (randomObstacle == 0)
        {
            Vector3 newSpawnPoints = new Vector3(0.14f, 1.41f, spawnPoint.position.z);
            Instantiate(obstaclePrefab, newSpawnPoints, Quaternion.identity, transform);
        }
        else if (randomObstacle == 1)
        {
            Vector3 newSpawnPoints = new Vector3(0.14f, 6f, spawnPoint.position.z);
            Instantiate(highObstaclePrefab, newSpawnPoints, Quaternion.identity, transform);
        }
        else if (randomObstacle == 2)
        {
            Vector3 newSpawnPoints = new Vector3(0.14f, 1.41f, spawnPoint.position.z); 
            Instantiate(FireObstacle, newSpawnPoints, Quaternion.identity, transform);
        }
    }
}
