using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class General : MonoBehaviour
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
        Debug.Log("Fonction trigger");
        Debug.Log(other.gameObject.name);
    }
}
