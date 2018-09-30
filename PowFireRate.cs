using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Increase fire rate powerup
public class PowFireRate : MonoBehaviour {

    public float powTime = 1.0f;
    public float powEffect = 2.0f;

    public GameObject player;

    private IEnumerator cor;

    void Start()
    {
        cor = powerFireRate();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(cor);
        }
    }

    IEnumerator powerFireRate()
    {
        this.GetComponent<SpriteRenderer>().enabled = false;
        player.GetComponent<PlayerController>().fireRate /= powEffect;
        yield return new WaitForSeconds(powTime);
        player.GetComponent<PlayerController>().fireRate *= powEffect;
        Destroy(this.gameObject);
    }
}
