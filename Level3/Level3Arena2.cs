using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Arena2 : MonoBehaviour
{

    public int spawnNum;
    public float spawnRate;
    public float waveRate;
    public float cameraOffset;

    public GameObject enemyDog;
    public GameObject enemyMan;
    public GameObject enemyDrone;
    public GameObject laserWall;
    public Transform spawnLoc1;
    public Transform spawnLoc2;
    public Transform spawnLoc3;
    public GameObject levelSpace;
    public GameObject laserTileLeft;
    public GameObject laserTileRight;

    private IEnumerator cor;
    private bool triggeredOnce = true;
    private bool done = false;

    void Start()
    {
        cor = Spawn();
    }

    void Update()
    {
        if (done && GameObject.FindWithTag("Enemy") == null)
        {
            GlobalVariables.lives += 1;
            laserTileLeft.GetComponent<Animator>().Play("laser_off");
            laserTileRight.GetComponent<Animator>().Play("laser_off");
            Destroy(GameObject.FindWithTag("LaserWall"));
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            /* Use colliders to control player movement instead
            if (triggeredOnce)              //NOTE: For some reason, coroutine will not start again(never reaches Spawn() after first time)
            {                               //Look in into ending coroutines or simliar
                camera.GetComponent<CameraController>().enabled = false;
                camera.transform.position = new Vector3(transform.position.x, camera.transform.position.y, camera.transform.position.z);
                triggeredOnce = false;
            }
            */
            if (triggeredOnce)
            {
                triggeredOnce = false;
                Instantiate(levelSpace, new Vector3(transform.position.x + 10F, transform.position.y, transform.position.z), Quaternion.identity);
                Instantiate(laserWall, new Vector3(transform.position.x - 11.5215F, transform.position.y, transform.position.z), Quaternion.identity);
                laserTileLeft.GetComponent<Animator>().Play("laser_on");
                laserTileRight.GetComponent<Animator>().Play("laser_on");
                StartCoroutine(cor);
            }
        }
    }

    IEnumerator Spawn()
    {

        int separation = 0;

        for (int i = 0; i < spawnNum; i++)
        {
            yield return new WaitForSeconds(0);
            Instantiate(enemyDrone, new Vector3(spawnLoc1.position.x, spawnLoc1.position.y, -1), Quaternion.AngleAxis(180, Vector3.forward));
    
        }

        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0);
            Instantiate(enemyMan, new Vector3(spawnLoc1.position.x - 1.5F, spawnLoc1.position.y + 3 - (separation), -1), Quaternion.AngleAxis(180, Vector3.forward));
            separation++;
        }

        yield return new WaitForSeconds(5);

        for (int i = 0; i < spawnNum; i++)
        {
            yield return new WaitForSeconds(0);
            Instantiate(enemyDrone, new Vector3(spawnLoc2.position.x, spawnLoc2.position.y, -1), Quaternion.AngleAxis(180, Vector3.forward));

        }

        separation = 0;

        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0);
            Instantiate(enemyMan, new Vector3(spawnLoc2.position.x + 1.5F, spawnLoc2.position.y + 3 - (separation), -1), Quaternion.AngleAxis(0, Vector3.forward));
            separation++;
        }

        yield return new WaitForSeconds(5);

        for (int i = 0; i < spawnNum; i++)
        {
            yield return new WaitForSeconds(0);
            Instantiate(enemyDrone, new Vector3(spawnLoc1.position.x, spawnLoc2.position.y, -1), Quaternion.AngleAxis(180, Vector3.forward));

        }

        separation = 0;

        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0);
            Instantiate(enemyMan, new Vector3(spawnLoc1.position.x - 1.5F, spawnLoc2.position.y + 3 - (separation), -1), Quaternion.AngleAxis(180, Vector3.forward));
            separation++;
        }

        yield return new WaitForSeconds(5);

        for (int i = 0; i < spawnNum; i++)
        {
            yield return new WaitForSeconds(0);
            Instantiate(enemyDrone, new Vector3(spawnLoc2.position.x, spawnLoc1.position.y, -1), Quaternion.AngleAxis(180, Vector3.forward));

        }

        separation = 0;

        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0);
            Instantiate(enemyMan, new Vector3(spawnLoc2.position.x + 1.5F, spawnLoc1.position.y + 3 - (separation), -1), Quaternion.AngleAxis(0, Vector3.forward));
            separation++;
        }

        for (int i = 0; i < 8; i++) {

            yield return new WaitForSeconds(.5F);
            Instantiate(enemyDog, new Vector3(spawnLoc3.position.x, spawnLoc3.position.y, -1), Quaternion.AngleAxis(0, Vector3.forward));
            separation++;
        }

        done = true;
    }
}
