using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTile;
    public Vector3 nextPoint = new Vector3(0,0,-3);

    public GameObject player;

    public void Spawn(int index){
        GameObject temp =  Instantiate(groundTile,new Vector3(0,0, nextPoint.z), Quaternion.identity);
        nextPoint = temp.transform.GetChild(1).transform.position;
        if (index != 0)
        {
            SpawnObstacles(temp.GetComponent<GroundTile>());
        }

    }
    void Start()
    {
        player.SetActive(true);
        for (int i = 0; i < 5; i++)
        {
        Spawn(i);
            
        }
        
    }
    public void SpawnObstacles(GroundTile tile)
    {
        tile.SpawnObstacle();
    }
    
}
