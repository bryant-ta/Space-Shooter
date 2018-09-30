
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Type Man Enemy. Define Man Enemy behavior.

public class EnemyMan : MonoBehaviour {

    public float speed = 1.0f;
    public float fireRate;

    public GameObject blast;
    public Transform blastSpawn;

    private IEnumerator coroutine;
    private Rigidbody2D rb;

    //Create with velocity going forward with factor 'speed'
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coroutine = Action();
        StartCoroutine(coroutine);
    }

    //Walk forward
    void FixedUpdate()
    {
        rb.velocity = transform.right * speed * GlobalVariables.globalSpeed;
    }

    //Flip this object if exit play area
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "LevelSpace")
        {
            transform.right = -transform.right;
        }
    }
    //Launch projectile in direction of facing. *Man Enemy movement uses 'GoForward' script
    private IEnumerator Action()
    {
        //Create instance of 'blast' object at position of GameObject blastSpawn, located in front of Man Enemy, with original object's rotation
        while (true)
        {
            yield return new WaitForSeconds(fireRate);
            Instantiate(blast, blastSpawn.position, transform.rotation);
        }
    }
}
