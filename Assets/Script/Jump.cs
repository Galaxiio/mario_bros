using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    //Pour Jump
    public float speedJ = 5f;
    public float jumpForce = 5f;
    private Rigidbody rb;
    private GameObject preffireball;
    private GameObject Mario;
    public bool FlowerOn = false;

    public LayerMask groundLayer;
    public float raycastDistance = 0.6f;
    
    //private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        preffireball = Resources.Load("Prefabs/Fireball") as GameObject;

        Mario = GameObject.Find("Mario");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance, groundLayer)){
            //isGrounded = true;
        }
        else {
            //isGrounded = false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if(FlowerOn) {
                Shoot();
            }
        }
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
        }
    }
}
