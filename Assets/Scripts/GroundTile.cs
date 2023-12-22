
using UnityEngine;


public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;

    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        //SpawnObstacle();
    }
    private void OnTriggerExit(Collider other)
    {
        groundSpawner.Spawn(200);
        Destroy(gameObject, 20);
    }
    public GameObject obstaclePrefab;
    public GameObject highObstaclePrefab;
    public GameObject FireObstacle;
    public GameObject secondHighObstaclePrefab;


    public void SpawnObstacle()
    {
        
            int obstaclePositionIndex = Random.Range(3, 7);
            int randomObstacle = Random.Range(0, 4);
        Debug.Log(randomObstacle);

            Transform spawnPoint = transform.GetChild(obstaclePositionIndex).transform;

            if (randomObstacle == 0)
            {
                Vector3 newSpawnPoints = new Vector3(0.14f, 2.14f, spawnPoint.position.z);
                Instantiate(obstaclePrefab, newSpawnPoints, Quaternion.identity, transform);
            }
            else if (randomObstacle == 1)
            {
                Vector3 newSpawnPoints = new Vector3(0.14f, 6.9f, spawnPoint.position.z);
                Instantiate(highObstaclePrefab, newSpawnPoints, Quaternion.identity, transform);
            }
            else if (randomObstacle == 2)
            {
                Vector3 newSpawnPoints = new Vector3(0.14f, 2.14f, spawnPoint.position.z);
                Instantiate(FireObstacle, newSpawnPoints, Quaternion.identity, transform);
            }
            else if(randomObstacle == 3)
        {

            Vector3 newSpawnPoints = new Vector3(0.14f, 6.9f, spawnPoint.position.z);
            Instantiate(secondHighObstaclePrefab, newSpawnPoints, Quaternion.identity, transform);
            
        }
           

       
    }
}
