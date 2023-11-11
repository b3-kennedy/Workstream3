using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTile;
    Vector3 nextPoint;

    public void Spawn(){
        GameObject temp =  Instantiate(groundTile,nextPoint, Quaternion.identity);
        nextPoint = temp.transform.GetChild(1).transform.position;
    }
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
        Spawn();
        }
        
    }
    
}
