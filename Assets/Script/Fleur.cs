using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fleur : MonoBehaviour
{

    private GameObject Flower;
    private GameObject Mario;
    private Renderer Mariorenderer;

    [SerializeField]
    private Texture[] textures;

    // Start is called before the first frame update
    void Start()
    {
        Flower = GameObject.Find("FireFlower");
        Mario = GameObject.Find("Mario");
        Mariorenderer = Mario.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        Mario.transform.localScale = new Vector3(25,25,25);
        Flower.transform.localScale = new Vector3(0,0,0);
        Mariorenderer.material.SetTexture("_MainTex", textures[0]);
    }
}
