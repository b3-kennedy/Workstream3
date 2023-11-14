
using UnityEngine;

public class Obstacle : MonoBehaviour
{
PlayerController playerController;
    void Start()
    {
        playerController= GameObject.FindObjectOfType<PlayerController>();

    }
    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.name=="Player")
        {
            playerController.Die();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
