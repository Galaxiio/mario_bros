using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private GameObject champi;
    private GameObject fleur;


    // Start is called before the first frame update
    void Start()
    {
        champi = Resources.Load("Prefabs/Champi") as GameObject;
        fleur = Resources.Load("Prefabs/FireFlower") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawn()
    {
        int rdm = Random.Range(0, 2);
        switch (rdm)
        {
            case 0:
                GameObject p1 = Instantiate(champi);
                p1.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1f, this.transform.position.z);
                break;
            case 1:
                GameObject p2 = Instantiate(fleur);
                p2.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1f, this.transform.position.z);
                break;
            case 2:
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        /*int rdm = Random.Range(0, 2);
        switch (rdm)
        {
            case 0:
                GameObject champi = Instantiate(Champi);
                champi.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1f, this.transform.position.z);
                break;
            case 1:
                GameObject flower = Instantiate(Flower);
                flower.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1f, this.transform.position.z);
                break;
            case 2:
                break;
        }*/
        spawn();
        Destroy(this.gameObject);
    }


}
