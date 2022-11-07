using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleMario : MonoBehaviour
{
    private Animator ani;
    private Rigidbody rb;

    private CharacterController controller;
    private float verticalVelocity;
    private float gravity = 7.0f;
    private float jumpForce = 13.0f;

    // Start is called before the first frame update
    void Start()
    {
        ani = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float vitesse = 0;

        if(ani.GetBool("isFalling"))
        {
            ani.SetBool("isFalling", false);
        }

        if(Input.GetKey(KeyCode.UpArrow))
        {
            vitesse = 1;
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Rotate(0, 2*Time.deltaTime*75.0f, 0);
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Rotate(0, -2*Time.deltaTime*75.0f, 0);
        }

        if (controller.isGrounded) {
            verticalVelocity = -gravity * Time.deltaTime;
            if(Input.GetKeyDown(KeyCode.Space)) {
                verticalVelocity = jumpForce;
            }
        }
        else {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        Vector3 moveVector = new Vector3(0,verticalVelocity,0);
        controller.Move(moveVector * Time.deltaTime);

        ani.SetFloat("Speed", vitesse);
    }
}
