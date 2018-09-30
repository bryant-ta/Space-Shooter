using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3ArenaBoss : MonoBehaviour
{
    public GameObject laserWall;
    public GameObject laserTileLeft;
    public GameObject laserTileRight;
    
    private bool triggeredOnce = true;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && triggeredOnce)
        {
            triggeredOnce = false;
            Instantiate(laserWall, new Vector3(transform.position.x - 11.5215F, transform.position.y, transform.position.z), Quaternion.identity);
            laserTileLeft.GetComponent<Animator>().Play("laser_on");
            laserTileRight.GetComponent<Animator>().Play("laser_on");
            GameObject.FindWithTag("Boss").GetComponent<BossController>().playerIsHere = true;
        }
    }
}

