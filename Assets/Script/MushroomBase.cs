using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomBase : MonoBehaviour
{
    private GameObject Champignon;
    private GameObject Mario;
    // Start is called before the first frame update
    void Awake()
    {
        Mario = GameObject.Find("Mario");

        this.transform.position = new Vector3(0f, 20f, 0f);
    }

    public void Init(Vector3 pos, float ang)
    {
        this.transform.position = pos;
    }


    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        Mario.transform.localScale = new Vector3(25, 25, 25);
        Destroy(this.gameObject);
    }
}
