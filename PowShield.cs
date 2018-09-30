using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Gives player shield.
public class PowShield : MonoBehaviour {

    public float powTime = 1.0f;
    public float powEffect = 2.0f;

    public GameObject player;
    public GameObject shieldObject;

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
        Instantiate (shieldObject, player.GetComponent<Transform>().position, Quaternion.identity);
        GameObject.FindWithTag("Shield").transform.parent = player.transform;
        yield return new WaitForSeconds(powTime);
        if (GameObject.FindWithTag("Shield") != null) {
            Destroy(GameObject.FindWithTag("Shield"));
        }
        Destroy(this.gameObject);
    }
}
