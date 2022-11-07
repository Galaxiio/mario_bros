using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleMario : MonoBehaviour
{
    private Animator ani;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        ani = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
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

        if(Input.GetKey(KeyCode.Space))
        {
            //rb.AddForce(Vector3.up * 10);
            ani.SetBool("isFalling", true);
        }

        ani.SetFloat("Speed", vitesse);
    }
}
