using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 2f;
    public Rigidbody rbody;
    bool isAlive = true;
    bool isGrounded = true;
    [SerializeField] float jumpForce = 100f;
    [SerializeField] LayerMask groundMask ;

    public Animator animator;
    
    
    public void FixedUpdate(){
        if(!isAlive) return;
        animator.SetFloat("Speed_f", Mathf.Abs(speed));
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        rbody.MovePosition(rbody.position + forwardMove);
        
        
    }
   
    public void Die()
    {
        isAlive = false;
        animator.SetBool("Death_b",true);
        Invoke("RestartGame",1);
    }
    void RestartGame(){
        animator.SetBool("Death_b",false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void Jump()
    {
        float height = GetComponent<Collider>().bounds.size.y;
      
        isGrounded = (transform.position.y < 1);
        Debug.Log(isGrounded);
        if(isGrounded){
        rbody.AddForce(Vector3.up*jumpForce);
        animator.SetBool("Jump_b",true);  
        } else {
           animator.SetBool("Jump_b",false);  
        }
    }
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.UpArrow)){
        Jump();
       }
       else if(transform.position.y<1){
        animator.SetBool("Jump_b",false); 
       }
    }
}
