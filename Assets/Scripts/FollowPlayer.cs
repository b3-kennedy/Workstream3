
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    
    
    public GameObject player;
   

    void LateUpdate()
    {
        
        float z = player.transform.position.z - 2;
        transform.position = new Vector3(transform.position.x , transform.position.y, z);

    }
}
