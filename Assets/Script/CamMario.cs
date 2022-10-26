using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMario : MonoBehaviour
{
    private Vector3 decalage;
    private GameObject Mario;
    // Start is called before the first frame update
    void Start()
    {
        Mario = GameObject.Find("Mario");
        decalage = Mario.transform.position - this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Mario.transform.position - decalage;
    }
}
