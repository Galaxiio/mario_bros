using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballBase : MonoBehaviour
{
    private float vitesse;
    private Vector3 direction;

    // Start is called before the first frame update
    void Awake()
    {
        this.transform.position = new Vector3(0f, 20f, 0f);
        direction = this.transform.forward;
        vitesse = 5;
    }

    public void Init(Vector3 pos, float ang)
    {
        this.transform.position = pos;   
    }


    // Update is called once per frame
    void Update()
    {
        this.transform.position += direction * Time.deltaTime*vitesse;
    }

    private void OnCollisionEnter(Collision collision)
    {

    }
}
