using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Champi : MonoBehaviour
{
    private GameObject Mario;
    

    // Start is called before the first frame update
    void Start()
    {
        Mario = GameObject.Find("Mario");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        Mario.transform.localScale = new Vector3(25, 25, 25);
        Destroy(this.gameObject);
    }
}
