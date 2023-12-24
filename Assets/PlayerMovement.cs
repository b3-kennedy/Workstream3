using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    public float timer = 0;


    public Rigidbody rbody;
    bool isAlive = true;
    bool isGrounded = true;

    [SerializeField] float jumpForce = 100f;
    [SerializeField] LayerMask groundMask;

    public PlayerControls playerControls;

    public Animator animator;

    public CapsuleCollider collider;
    float colliderOriginalY;
    float colliderOriginalCenter;

    public TMP_Text highcoreUIText;
    public TMP_Text scoreUIText;
    public static int score = 0;

    public AudioSource HitSound;
    public AudioSource JumpSound;


    public GameObject gameManager;

    public GameObject HealthBarUI;


    private void Awake()
    {
        score = 0;
        playerControls = new PlayerControls();
        colliderOriginalY = collider.height;
        colliderOriginalCenter = collider.center.y;



    }

    private void OnEnable()
    {
        playerControls.Enable();
        playerControls.Player.Crouch.started += ctx =>
        {
            animator.SetBool("Crouch_b", true);
            collider.height = 1.5f;
            //collider.center = new Vector3(collider.center.x, 0.5f, collider.center.z);
        };
        playerControls.Player.Crouch.canceled += ctx =>
        {
            collider.height = 1.97f;
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
        if (timer > 30)
        {
           
            IncreseSpeedByTime();
            timer = 0;
        }
       animator.SetBool("Run_b", true);
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        rbody.MovePosition(rbody.position + forwardMove);
        score += Mathf.RoundToInt(Time.deltaTime * 10*speed);

        scoreUIText.text = "Score : " + score;

        if(PlayerPrefs.GetInt("HighScore", 0)< score)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
        highcoreUIText.text ="High Score : "+ PlayerPrefs.GetInt("HighScore",0);





    }
    void IncreseSpeedByTime()
    {
        speed += 0.15f;
    }

    public void Die()
    {
        gameManager.GetComponent<LevelManager>().DamageOnHit();
        int hearts = 5;

        animator.SetBool("Death_b", true);
        if (gameManager.GetComponent<LevelManager>().Hearts <= 0)
        {
            isAlive = false;

            Invoke("RestartGame", 1);
        }
        else
        {
            isAlive = false;

            HitSound.Play();

            rbody.MovePosition(rbody.position + new Vector3(0, 0, 2f));

            Invoke("TakeHit", 1.5f);

        }

    }
    void TakeHit()
    {
        isAlive = true;

        if(speed>7)
            speed -= 1;
        animator.SetBool("Death_b", false);

    }
    void RestartGame()
    {
        //animator.SetBool("Death_b", false);

    }
    public void Jump()
    {
        
        Debug.Log("jump");
        isGrounded = (transform.position.y < 5);
        Debug.Log(transform.position.y);
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
