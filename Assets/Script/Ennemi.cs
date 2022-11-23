using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent goomba;
    private UnityEngine.AI.NavMeshAgent koopa;
    private GameObject Mario;

    // Start is called before the first frame update
    void Start()
    {
        goomba = GameObject.Find("Goomba").GetComponent<UnityEngine.AI.NavMeshAgent>();
        koopa = GameObject.Find("Koopa").GetComponent<UnityEngine.AI.NavMeshAgent>();
        Mario = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        goomba.destination = Mario.transform.position;
        koopa.destination = Mario.transform.position;
    }
}
