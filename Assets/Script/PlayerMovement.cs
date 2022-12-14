using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    private bool Grand = false;

    [HideInInspector] public float walkSpeed;
    [HideInInspector] public float sprintSpeed;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;
    private GameObject Mario;

    //animation Mario
    private Animator ani;
    float courrir = 0;

    //Pouvoir
    private GameObject preffireball;
    public bool FlowerOn = false;

    
    private Renderer Casquetterenderer;
    private Renderer Pullrenderer;
    private Renderer Salopetterenderer;
    private GameObject casquette;
    private GameObject pull;
    private GameObject salopette;

    [SerializeField]
    private Texture[] textures;

    private void Start()
    {
        Mario = GameObject.Find("Mario");
        ani = Mario.GetComponent<Animator>();

        rb = GetComponent<Rigidbody>();

        preffireball = Resources.Load("Prefabs/Fireball") as GameObject;

        rb.freezeRotation = true;

        readyToJump = true;

        Mario = GameObject.Find("Mario");
        casquette = GameObject.Find("casquette");
        pull = GameObject.Find("pull");
        salopette = GameObject.Find("salopette");
        Casquetterenderer = casquette.GetComponent<Renderer>();
        Pullrenderer = pull.GetComponent<Renderer>();
        Salopetterenderer = salopette.GetComponent<Renderer>();
    }

    private void Update()
    {
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.1f, whatIsGround);

        MyInput();
        SpeedControl();

        // handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;

        //animation
        /*if (Input.GetKey(KeyCode.W))
            courrir = 1;
        else
            courrir = 0;*/
        ani.SetFloat("Speed", courrir);

        //Lancer boule de feu
        if (Input.GetMouseButtonDown(0))
        {
            if (FlowerOn)
            {
                Shoot();
            }
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // on ground
        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        // in air
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);

    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }

    private void Shoot()
    {
        // Instanciation du pr�fab, en pr�cisant son parent
        GameObject p1 = Instantiate(preffireball);

        // Placement : un peu "devant" le joueur
        p1.transform.position = new Vector3(Mario.transform.position.x, Mario.transform.position.y + 0.5f, Mario.transform.position.z);
        //p1.transform.Translate(Mario.transform.forward * 0.1f);
        //p1.transform.Translate(Mario.transform.right * 1.0f);

        // Propulsion
        p1.GetComponent<Rigidbody>().AddForce(Mario.transform.forward * 700);
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Flower")) {
            FlowerOn = true;
            Grand = true;
        }

        if(collision.gameObject.CompareTag("Champi")) {
            Grand = true;
        }

        if(collision.gameObject.CompareTag("Goomba")) {
            if(FlowerOn) {
                Casquetterenderer.material.SetTexture("_MainTex", textures[0]);
                Pullrenderer.material.SetTexture("_MainTex", textures[1]);
                Salopetterenderer.material.SetTexture("_MainTex", textures[2]);
                FlowerOn = false;
            }
            else if(Grand) {
                Mario.transform.localScale = new Vector3(20,20,20);
                Grand = false;
            }
            else {
                Time.timeScale = 0;
            }
        }

        if(collision.gameObject.CompareTag("Koopa")) {
            if(FlowerOn) {
                Casquetterenderer.material.SetTexture("_MainTex", textures[0]);
                Pullrenderer.material.SetTexture("_MainTex", textures[1]);
                Salopetterenderer.material.SetTexture("_MainTex", textures[2]);
                FlowerOn = false;
            }
            else if(Grand) {
                Mario.transform.localScale = new Vector3(20,20,20);
                Grand = false;
            }
            else {
                Time.timeScale = 0;
            }
        }
    }
}