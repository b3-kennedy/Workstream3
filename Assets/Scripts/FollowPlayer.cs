
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    
    // private Vector3 offset = new Vector3(10,1,-8);
    public GameObject player;
    // public float xMin = -2;
    // public float xMax = 2000;
    // public float yMin = -2;
    // public float yMax=2000;

    void LateUpdate()
    {
        
        float z = player.transform.position.z - 2;
        transform.position = new Vector3(transform.position.x , transform.position.y, z);

    }
}
