using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Give object velocity in forward direction, dependent on rotation. For Enemy to respond to slow time.
public class GoFowardEnemy : MonoBehaviour {

    public float speed;

    private Rigidbody2D rb;

    //Create with velocity going forward with factor 'speed'
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed * GlobalVariables.globalSpeed;
    }
}
