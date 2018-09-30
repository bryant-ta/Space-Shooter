using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Destroy object if contacting. Used with enemy projectile. Also handles Player invicibility

public class DestroyByContactEnemy : MonoBehaviour {

    private IEnumerator cor;

    //On contact. Requires one collider to be marked 'isTrigger'.

    void Start()
    {
        cor = Invincible();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Check tagged as Player and Player is not invincible
        if (other.tag == "Player" && !GameObject.FindWithTag("Player").GetComponent<PlayerController>().invin)
        {
            GlobalVariables.lives -= 1;
            if (GlobalVariables.lives > 0)
            {
                if (this.tag != "Boss")
                {
                    this.GetComponent<SpriteRenderer>().enabled = false;
                    this.GetComponent<Collider2D>().enabled = false;
                }
                StartCoroutine(cor);
            } else {
                Destroy(other.gameObject);
                Destroy(this.gameObject);
            }
        }
        
        //Check tagged as a wall and this is not an enemy body.
        if ((other.tag == "Wall" || other.tag == "LaserWall") && this.tag != "Enemy")
        {
            //Destroy this object.
            Destroy(this.gameObject);
        }
        
    }

    //Player invincibility
    IEnumerator Invincible()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().invin = true;

        //Flashing player effect
        for (int i = 0; i < 5; i++)
        {
            GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(0.2f);
            GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.2f);
        }
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().invin = false;
        if (this.tag != "Boss")
        {
            Destroy(this.gameObject);
        }
    }
}
