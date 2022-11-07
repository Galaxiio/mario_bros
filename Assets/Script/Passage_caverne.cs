using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passage_caverne : MonoBehaviour
{
    private GameObject Tuyau;
    private GameObject Tuyau2;
    private GameObject Mario;
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        Tuyau = GameObject.Find("Passage");
        Mario = GameObject.Find("Mario");
        Tuyau2 = GameObject.Find("Passage_caverne");
        controller = Mario.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        controller.enabled = false;
        Mario.transform.position = new Vector3(Tuyau.transform.position.x,Tuyau.transform.position.y+1,Tuyau.transform.position.z);
        controller.enabled = true;
    }
}