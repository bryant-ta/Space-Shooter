using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Destroy object if existence time exceeds a time.

public class DestroyByTime : MonoBehaviour {

    //Time before destroying object
    public float lifetime;

    //Object created with lifetime (sec)
    void Start()
    {
        //Destroy that object after 'lifetime'
        Destroy(gameObject, lifetime);
    }
}
