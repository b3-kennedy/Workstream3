
using UnityEngine;

public class Obstacle : MonoBehaviour
{
PlayerMovement playerMovement;
    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();

    }
    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Player"))
        {
            playerMovement.Die();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
