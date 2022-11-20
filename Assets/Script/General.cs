using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class General : MonoBehaviour
{
    private GameObject Champignon;
    private GameObject Mario;

    private GameObject Fleur;

    // Start is called before the first frame update
    void Start()
    {
        Champignon = GameObject.Find("Champignon");
        Mario = GameObject.Find("Mario");
        Fleur = GameObject.Find("FireFlower");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
