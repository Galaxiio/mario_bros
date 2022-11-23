using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private GameObject goomba;
    private GameObject koopa;

    // Start is called before the first frame update
    void Start()
    {
        goomba = GameObject.Find("Goomba");
        koopa = GameObject.Find("Koopa");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Fireball")) {
            this.transform.position = new Vector3(-100,-100,-100);
        }
    }
}
