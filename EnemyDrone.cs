using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrone : MonoBehaviour {

    public float speed = 1.0f;
    public float variationTime = 1.0f;
    public int spawnCount = 1;

    public GameObject rocket;
    public Transform blastSpawn;

    private IEnumerator cor;
    private Rigidbody2D rb;

    //Reference vectors for movement
    private Vector2 dir1 = Vector2.up;

    //Create with velocity going forward with factor 'speed'
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cor = Action();
        StartCoroutine(cor);
    }

    void Update()
    {
        //Rotating drone effect
        transform.Rotate(Vector3.forward * speed/5);
        //Keeps drone in play area
        rb.position = new Vector2(rb.position.x, Mathf.Clamp(rb.position.y, -4, 4));
    }

    //Move Drone Enemy in vertical pattern. Spawns rocket when changing direction
    private IEnumerator Action()
    {
        while (true)
        {
            //move up
            rb.velocity = dir1 * speed * GlobalVariables.globalSpeed;
            for (int i = 0; i < spawnCount; i++)
            {
                Instantiate(rocket, blastSpawn.position, Quaternion.identity);
            }

            //Wait, move down
            yield return new WaitForSeconds(variationTime);
            rb.velocity = -dir1 * speed * GlobalVariables.globalSpeed;
            for (int i = 0; i < spawnCount; i++)
            {
                Instantiate(rocket, blastSpawn.position, Quaternion.LookRotation(GameObject.FindWithTag("Player").transform.position));
            }
            yield return new WaitForSeconds(variationTime);

        }
    }
}
