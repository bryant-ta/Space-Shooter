using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Give object velocity in forward direction, dependent on rotation
public class GoForward : MonoBehaviour {

    public float speed;

    private Rigidbody2D rb;

    //Create with velocity going forward with factor 'speed'
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
	}
}
