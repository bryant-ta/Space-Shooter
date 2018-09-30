using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Destroy object if contacting. Used with player projectile.

public class DestroyByContact : MonoBehaviour
{

    //On contact. Requires one collider to be marked 'isTrigger'.
    void OnTriggerEnter2D(Collider2D other)
    {
        //Check tagged as Enemy.
        if (other.tag == "Enemy")
        {
            //Destroy both objects.
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

        //Check tagged as Rocket. Does not give points.
        if (other.tag == "Rocket")
        {
            //Destroy both objects.
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

        if (other.tag == "Boss")
        {
            //Destroy both objects.
            Destroy(this.gameObject);
        }

        //Check tagged as Wall.
        if (other.tag == "Wall" || other.tag == "LaserWall")
        {
            //Destroy this object.
            Destroy(this.gameObject);
        }
    }
}