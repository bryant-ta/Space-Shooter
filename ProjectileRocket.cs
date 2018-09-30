using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handle homing missle. Allows player to attempt to dodge missle instead of shooting it.
public class ProjectileRocket : MonoBehaviour {

    public float speed;
    public float minDistance;

    private Rigidbody2D rb;
    private bool homing = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //Keep current velocity if no player. Used on GameOver screen
        if (GameObject.FindWithTag("Player") == null)
        {
            return;
        }

        //If farther than minDistance from player, turn towards player and travel forward. Else travel forward. Gives player option to dodge missle.
        if (homing && Vector2.Distance(GameObject.FindWithTag("Player").transform.position, transform.position) > minDistance)
        {
            transform.right = GameObject.FindWithTag("Player").transform.position - transform.position;
            rb.velocity = transform.right * speed * GlobalVariables.globalSpeed;
        } else
        {
            rb.velocity = transform.right * speed * GlobalVariables.globalSpeed;
            homing = false;
        }
    }
}
