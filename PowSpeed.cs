using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Speed up player powerup
public class PowSpeed : MonoBehaviour {

    public float powTime = 1.0f;
    public float powEffect = 2.0f;

    public GameObject player;
    
    private IEnumerator cor;

    void Start()
    {
        cor = powerSpeed();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(cor);
        }
    }

    IEnumerator powerSpeed()
    {
        this.GetComponent<SpriteRenderer>().enabled = false;
        player.GetComponent<PlayerController>().speed *= powEffect;
        yield return new WaitForSeconds(powTime);
        player.GetComponent<PlayerController>().speed /= powEffect;
        Destroy(this.gameObject);
    }
}
