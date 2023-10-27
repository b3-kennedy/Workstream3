using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 2.0f;
    public Rigidbody rbody;
    bool alive = true;
    [SerializeField] float jumpForce = 400f;
    [SerializeField] LayerMask groundMask ;
    
    
    public void FixedUpdate(){
        if(!alive) return;
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        rbody.MovePosition(rbody.position + forwardMove);
    }
    
    public void Die()
    {
        alive = false;
        Invoke("RestartGame",1);
    }
    void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void Jump()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height/2) + 0.1f , groundMask);
        if(isGrounded)
        rbody.AddForce(Vector3.up* jumpForce);
    }
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.UpArrow)){
        Jump();
       }
    }
}
