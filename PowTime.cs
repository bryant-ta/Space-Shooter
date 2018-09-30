using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Slow time powerup
public class PowTime : MonoBehaviour {

    public float powTime = 1.0f;
    public float powEffect = 2.0f;

    public GameObject player;

    private IEnumerator cor;
    private 

    void Start()
    {
        cor = powerTime();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(cor);
        }
    }

    //Change global speed of enemies
    IEnumerator powerTime()
    {
        this.GetComponent<SpriteRenderer>().enabled = false;
        GlobalVariables.globalSpeed /= powEffect;
        yield return new WaitForSeconds(powTime);
        GlobalVariables.globalSpeed *= powEffect;
        Destroy(this.gameObject);
    }
}
