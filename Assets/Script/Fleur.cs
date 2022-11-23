using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fleur : MonoBehaviour
{

    private GameObject Flower;
    private GameObject Mario;
    private Renderer Casquetterenderer;
    private Renderer Pullrenderer;
    private Renderer Salopetterenderer;
    private GameObject casquette;
    private GameObject pull;
    private GameObject salopette;

    [SerializeField]
    private Texture[] textures;

    // Start is called before the first frame update
    void Start()
    {
        Flower = GameObject.Find("FireFlower");
        Mario = GameObject.Find("Mario");
        casquette = GameObject.Find("casquette");
        pull = GameObject.Find("pull");
        salopette = GameObject.Find("salopette");
        Casquetterenderer = casquette.GetComponent<Renderer>();
        Pullrenderer = pull.GetComponent<Renderer>();
        Salopetterenderer = salopette.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        Mario.transform.localScale = new Vector3(25,25,25);
        Flower.transform.localScale = new Vector3(0,0,0);
        Casquetterenderer.material.SetTexture("_MainTex", textures[0]);
        Pullrenderer.material.SetTexture("_MainTex", textures[1]);
        Salopetterenderer.material.SetTexture("_MainTex", textures[2]);
    }
}
