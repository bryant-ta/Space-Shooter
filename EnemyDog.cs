using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Type Dog Enemy. Define Dog Enemy behavior.

public class EnemyDog : MonoBehaviour
{
    public float speed = 1.0f;
    public float variationTime = 1.0f;

    private IEnumerator cor;
    private Rigidbody2D rb;
    private Animator anim;

    //Reference vectors for movement
    private Vector2 dir1 = new Vector2(-1, 0);          //left
    private Vector2 dir2 = new Vector2(-1, 1);          //upLeft
    private Vector2 dir3 = new Vector2(-1, -1);         //downLeft

    //Create with velocity going forward with factor 'speed'
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cor = Action();
        StartCoroutine(cor);
        anim = GetComponent<Animator>();
    }

    //Keep this object in play area
    void Update()
    {
        rb.position = new Vector2(rb.position.x, Mathf.Clamp(rb.position.y, -6, 6));
    }

    //Flip this object if exit play area
    void OnTriggerExit2D (Collider2D other)
    {
        //On hitting wall, flip all dir vectors (e.g. left -> right)
        if (other.tag == "LevelSpace")
        {
            dir2 = -dir2;
            dir1 = -dir1;
            dir3 = -dir3;
            transform.right = -transform.right;
        }
    }

    //Move Dog Enemu in zig-zag pattern. Pattern size determined by 'variationTime' and 'speed'
    private IEnumerator Action()
    {
        //Change diretion in zig-zag after 'variationTime'
        while (true)
        {
            yield return new WaitForSeconds(variationTime);
            rb.velocity = dir2 * speed * GlobalVariables.globalSpeed;
            anim.Play("dog_left_walk");
            yield return new WaitForSeconds(variationTime);
            rb.velocity = dir1 * speed * GlobalVariables.globalSpeed;
            anim.Play("dog_left_walk");
            yield return new WaitForSeconds(variationTime);
            rb.velocity = dir3 * speed * GlobalVariables.globalSpeed;
            anim.Play("dog_left_walk");
            yield return new WaitForSeconds(variationTime);
            rb.velocity = dir1 * speed * GlobalVariables.globalSpeed;
            anim.Play("dog_left_walk");
        }
    }
}
