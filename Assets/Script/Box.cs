using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private GameObject Champi;
    private GameObject Flower;


    // Start is called before the first frame update
    void Start()
    {
        Champi = Resources.Load("Champi") as GameObject;
        Flower = Resources.Load("Flower") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Mario"))
        {
            int rdm = Random.Range(0, 2);
            switch (rdm)
            {
                case 0:
                    GameObject champi = Instantiate(Champi);
                    champi.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1f, this.transform.position.z);
                    break;
                case 1:
                    GameObject flower = Instantiate(Flower, this.transform.parent);
                    flower.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1f, this.transform.position.z);
                    break;
                case 2:
                    break;
            }

            Debug.Log("dsqd");
        }
    }
}
