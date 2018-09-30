using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handles Player animation
public class PlayerAnimation : MonoBehaviour {

    Animator anim;
    bool movingUp;
    int d = 0;
    int frame = 0;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    void Update() { 
       
        frame++;

        //up
        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {

            d = 1;
            anim.Play("player_walk", -1);
        }

        //left
        else if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {

            d = 2;
            anim.Play("player_left_walk", -1);
        }

        //down
        else if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {

            d = 3;
            anim.Play("player_walk", -1);
        }

        //right
        else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A))
        {

            d = 4;
            anim.Play("player_walk", -1);
        }

        //up and left
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {

            d = 5;
            anim.Play("player_walk", -1);
        }

        //up and right
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A))
        {

            d = 6;
            anim.Play("player_walk", -1);
        }

        //right and down
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W))
        {

            d = 7;
            anim.Play("player_walk", -1);
        }

        //left and down
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.D))
        {

            d = 8;
            anim.Play("player_walk", -1);
        }

        else {

            if (d != 2)
            anim.Play("player_idle", -1);
            else
            {
                anim.Play("player_left_idle", -1);
            }
        }
    }
}
