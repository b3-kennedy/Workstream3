using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 2f;

    public Rigidbody rbody;
    bool isAlive = true;
    bool isGrounded = true;

    [SerializeField] float jumpForce = 100f;
    [SerializeField] LayerMask groundMask ;

    public PlayerControls playerControls;

    public Animator animator;

    public BoxCollider collider;
    float colliderOriginalY;
    float colliderOriginalCenter;
    
    private void Awake() {
        playerControls = new PlayerControls();
        colliderOriginalY = collider.size.y;
        colliderOriginalCenter = collider.center.y;
    }

    private void OnEnable() {
        playerControls.Enable();
         playerControls.Player.Crouch.started += ctx => {
            animator.SetBool("Crouch_b",true);
            collider.size = new Vector3(collider.size.x, 1, collider.size.z);
            collider.center = new Vector3(collider.center.x, 0.5f, collider.center.z);
            };
         playerControls.Player.Crouch.canceled += ctx =>{
            collider.size = new Vector3(collider.size.x, colliderOriginalY, collider.size.z);
            collider.center = new Vector3(collider.center.x, colliderOriginalCenter, collider.center.z);
             animator.SetBool("Crouch_b",false);};
    }

    private void OnDisable() {
        playerControls.Disable();
    }

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
    // public void Crouch()
    // {
    //      if(playerControls.Player.Crouch.triggered && !isCrouching)
    //    {
    //     Debug.Log("crouching");
    //      animator.SetBool("Crouch_b",true);
    //     isCrouching=true;
    //     } else if (playerControls.Player.Crouch.phase == InputActionPhase.Canceled)
    //     {
    //         // Debug.Log("key released");
    //         isCrouching=false;
    //         animator.SetBool("Crouch_b",false);
    //     }
    // }
    // void OnCrouchPerformed(InputAction.CallbackContext context)
    // {
       
       
    //          Debug.Log("key released");
    //         isCrouching=false;
    //         animator.SetBool("Crouch_b",false);

    // }
    
    void Update()
    {
    
    //    if(playerControls.Player.DancePadJump.triggered){
       if(playerControls.Player.Jump.triggered){
        Jump();
       }
       else if(transform.position.y<1){
        animator.SetBool("Jump_b",false); 
       }
        // if(playerControls.Player.Crouch.triggered && !isCrouching){
        // Crouch();
    //    } else {
    //         // isCrouching=false;
    //         // animator.SetBool("Crouch_b",false);
    //    }
       
    }
}
