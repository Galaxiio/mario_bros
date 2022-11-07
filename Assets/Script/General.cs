using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Champi : MonoBehaviour
{
    private GameObject Champignon;
    private GameObject Mario;

    // Start is called before the first frame update
    void Start()
    {
        Champignon = GameObject.Find("Champignon");
        Mario = GameObject.Find("Mario");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        Mario.transform.localScale = new Vector3(25,25,25);
        Champignon.transform.localScale = new Vector3(0,0,0);
    }
}
