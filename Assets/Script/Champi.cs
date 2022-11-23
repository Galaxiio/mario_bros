using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Champi : MonoBehaviour
{
    private GameObject Champignon;
    private GameObject Mario;

    // Start is called before the first frame update

    private void Awake()
    {
        Champignon = GameObject.Find("Champi");
        Mario = GameObject.Find("Mario");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision) {
        
        if (collision.gameObject.CompareTag("Mario"))
        {
            Mario.transform.localScale = new Vector3(25,25,25);
            Destroy(this.gameObject);
        }
    }
}
