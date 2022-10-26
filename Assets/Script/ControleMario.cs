using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleMario : MonoBehaviour
{
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {


        if(Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Rotate(0, 2*Time.deltaTime*100.0f, 0);
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Rotate(0, -2*Time.deltaTime*100.0f, 0);
        }
    }
}
