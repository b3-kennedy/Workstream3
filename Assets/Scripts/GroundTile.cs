
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnObstacle();
    }
     private void OnTriggerExit(Collider other) {
        groundSpawner.Spawn();
         Destroy(gameObject,4);
    }
  public GameObject obstaclePrefab;
  public GameObject highObstaclePrefab;

  void SpawnObstacle (){
    int randomObstacleChoice = Random.Range(0,2);
    int obstaclePositionIndex = Random.Range(3,5);
    Transform spawnPoint = transform.GetChild(obstaclePositionIndex).transform;
    if(randomObstacleChoice==1){
    Instantiate(obstaclePrefab,spawnPoint.position,Quaternion.identity,transform);
    }
    else {
          Instantiate(highObstaclePrefab,spawnPoint.position,Quaternion.identity,transform);
    }
  }
}
