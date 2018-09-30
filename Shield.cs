using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Shield object on player powerup. Shield has bigger model/trigger than player
public class Shield : MonoBehaviour {

    //Destroy this object instead of triggering player life
	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Projectile" || other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
