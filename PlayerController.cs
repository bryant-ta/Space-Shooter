using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player movement. No slide.

public class PlayerController : MonoBehaviour {

    public float speed;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;
    public float fireRate;

    public float xPos;
    public float yPos;
    public bool invin;

    public GameObject blast;
    public Transform blastSpawn;

    private Rigidbody2D rb;
    private float nextFire;
    private AudioSource aud;

    //Assigning component
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        aud = GetComponent<AudioSource>();
    }

    //Movement using velocity manipulation, updates every frame
    void Update()
    {
        //Check assigned movement keys. Uses GetAxisRaw instead of GetAxis to stop player immediately if not pressing keys
        float moveHor = Input.GetAxisRaw("Horizontal");
        float moveVer = Input.GetAxisRaw("Vertical");

        //Create vector from pressed keys and translate to movement with factor 'speed'
        Vector2 move = new Vector2(moveHor, moveVer);
        rb.velocity = move * speed;

        //Strafing by turning player 90 degrees.
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            transform.Rotate(0, 0, -90);

        } else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            transform.Rotate(0, 0, 90);
        }

        Fire();

        //Previous attempts at player movement

        /*
        if (move != Vector2.zero)
        {
            transform.right = move;
        }
        */

        /*
        //Restrict movement in area
        rb.position = new Vector2(Mathf.Clamp(rb.position.x, xMin, xMax), Mathf.Clamp(rb.position.y, yMin, yMax));
        */

        /*
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            rb.MovePosition(transform.position + new Vector3(0.1f, 0.0f, 0.0f));
            blastSpawn.transform.localPosition = new Vector3(0.57f, 0.38f);
        }
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            rb.MovePosition(transform.position + new Vector3(-0.1f, 0.0f, 0.0f));
            blastSpawn.transform.localPosition = new Vector3(-0.57f, 0.38f);
        }
        if (Input.GetAxisRaw("Vertical") == 1)
        {
            rb.MovePosition(transform.position + new Vector3(0.0f, 0.1f, 0.0f));
            blastSpawn.transform.localPosition = new Vector3(-0.45f, 0.57f);
        }
        if (Input.GetAxisRaw("Vertical") == -1)
        {
            rb.MovePosition(transform.position + new Vector3(0.0f, -0.1f, 0.0f));
            blastSpawn.transform.localPosition = new Vector3(0.57f, 0.38f);
        }
        */

        /*
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            rb.MovePosition(transform.position + new Vector3(0.1f, 0.0f, 0.0f));
            rb.MoveRotation(0.0f);
        }
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            rb.MovePosition(transform.position + new Vector3(-0.1f, 0.0f, 0.0f));
            rb.MoveRotation(180.0f);
        }
        if (Input.GetAxisRaw("Vertical") == 1)
        {
            rb.MovePosition(transform.position + new Vector3(0.0f, 0.1f, 0.0f));
            rb.MoveRotation(90.0f);
        }
        if (Input.GetAxisRaw("Vertical") == -1)
        {
            rb.MovePosition(transform.position + new Vector3(0.0f, -0.1f, 0.0f));
            rb.MoveRotation(270.0f);
        }*/
    }

    //Launch projectile by creating 'blast' which is given velocity in GoForward.cs
    void Fire()
    {
        //Check if space key is pressed
        bool fire = Input.GetKey(KeyCode.Space);

        //Check 'fire' and if current time is greater than time of next fire
        if (fire && Time.time > nextFire)
        {
            //Set time of next fire using rate of fire in seconds
            nextFire = Time.time + fireRate;

            //Create instance of 'blast' object at position of GameObject blastSpawn, located in front of GameObject Player, with original object's rotation
            aud.Play();
            Instantiate(blast, blastSpawn.position, transform.rotation);
        }
    }
}
