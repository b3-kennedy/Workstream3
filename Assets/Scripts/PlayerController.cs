using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public float speed = 2f;

    public float timer = 0;


    public Rigidbody rbody;
    bool isAlive = true;
    bool isGrounded = true;

    [SerializeField] float jumpForce = 100f;
    [SerializeField] LayerMask groundMask;

    public PlayerControls playerControls;

    public Animator animator;

    public BoxCollider collider;
    float colliderOriginalY;
    float colliderOriginalCenter;

    public ParticleSystem hitParticleSystem;

    //public delegate void HitAction();
    //public static event HitAction hitActionHappened;


    public GameObject gameManager;

    public GameObject HealthBarUI;

    
    private void Awake()
    {
        playerControls = new PlayerControls();
        colliderOriginalY = collider.size.y;
        colliderOriginalCenter = collider.center.y;

        

    }

    private void OnEnable()
    {
        playerControls.Enable();
        playerControls.Player.Crouch.started += ctx =>
        {
            animator.SetBool("Crouch_b", true);
            collider.size = new Vector3(collider.size.x, 1, collider.size.z);
            collider.center = new Vector3(collider.center.x, 0.5f, collider.center.z);
        };
        playerControls.Player.Crouch.canceled += ctx =>
        {
            collider.size = new Vector3(collider.size.x, colliderOriginalY, collider.size.z);
            collider.center = new Vector3(collider.center.x, colliderOriginalCenter, collider.center.z);
            animator.SetBool("Crouch_b", false);
        };
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public void FixedUpdate()
    {
        if (!isAlive) return;
        timer += Time.deltaTime;
        if (timer > 10)
        {
            Debug.Log(timer);
            IncreseSpeedByTime();
            timer = 0;
        }
        animator.SetFloat("Speed_f", Mathf.Abs(speed));
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        rbody.MovePosition(rbody.position + forwardMove);
        



    }
    void IncreseSpeedByTime()
    {
        speed += 0.4f;
    }

    public void Die()
    {
        gameManager.GetComponent<LevelManager>().DamageOnHit();
        int hearts = 5;
        if (gameManager.GetComponent<LevelManager>().Hearts <= 0)
        {
            isAlive = false;
            animator.SetBool("Death_b", true);
            Invoke("RestartGame", 1);
        }
        else
        {
            isAlive = false;
            animator.SetFloat("Speed_f", 0);
            rbody.MovePosition(rbody.position - new Vector3(0, 0, 2.4f));
            ParticleSystem hit = Instantiate(hitParticleSystem, new Vector3(0, 2, transform.position.z), Quaternion.identity);
            Destroy(hit, 1.5f);
            hit.GetComponent<AudioSource>().Play();
            Invoke("TakeHit", 1.5f);

        }

    }
    void TakeHit()
    {
        isAlive = true;

        Debug.Log("Hearts: " + gameManager.GetComponent<LevelManager>().Hearts);

        speed = 5;

    }
    void RestartGame()
    {
        animator.SetBool("Death_b", false);

    }
    public void Jump()
    {
        float height = GetComponent<Collider>().bounds.size.y;

        isGrounded = (transform.position.y < 1);
        Debug.Log(isGrounded);
        if (isGrounded)
        {
            rbody.AddForce(Vector3.up * jumpForce);
            animator.SetBool("Jump_b", true);
        }
        else
        {
            animator.SetBool("Jump_b", false);
        }
    }
  

    void Update()
    {

        //    if(playerControls.Player.DancePadJump.triggered){
        if (playerControls.Player.Jump.triggered)
        {
            Jump();
        }
        else if (transform.position.y < 1)
        {
            animator.SetBool("Jump_b", false);
        }
    

    }
}
