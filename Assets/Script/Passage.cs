using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passage : MonoBehaviour
{
    private GameObject Tuyau;
    private GameObject Tuyau2;
    private GameObject Mario;
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        Tuyau = GameObject.Find("Tuyau");
        Mario = GameObject.Find("Mario");
        Tuyau2 = GameObject.Find("Tuyau2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        Mario.transform.position = new Vector3(Tuyau2.transform.position.x+2,Tuyau2.transform.position.y,Tuyau2.transform.position.z);
    }
}
