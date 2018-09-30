using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handle Boss laser animation
public class LaserAnimController : MonoBehaviour {

    Animator anim;
    void Start () {

        anim = GetComponent<Animator>();
        anim.Play("laser_off_idle", -1);
	}

    void OnTriggerEnter2D (Collider2D other) {

        anim.Play("laser_on", -1);
    }
}
