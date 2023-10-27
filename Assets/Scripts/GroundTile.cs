
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
       Invoke("SpawnObstacle",1);
    }
     private void OnTriggerExit(Collider other) {
        groundSpawner.Spawn();
         Destroy(gameObject,4);
    }
  public GameObject obstaclePrefab;

  void SpawnObstacle (){
    int obstaclePositionIndex = Random.Range(3,5);
    Transform spawnPoint = transform.GetChild(obstaclePositionIndex).transform;
    
    Instantiate(obstaclePrefab,spawnPoint.position,Quaternion.identity,transform);
  }
}
