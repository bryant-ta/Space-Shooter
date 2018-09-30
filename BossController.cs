using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Boss script
public class BossController : MonoBehaviour
{
    public bool playerIsHere = false;
    public bool going = true;

    public GameObject bossBlast;
    public GameObject bossRocket;

    public GameObject bossBlastSpawn0;
    public GameObject bossBlastSpawn1;
    public GameObject bossBlastSpawn2;
    public GameObject bossBlastSpawn3;
    public GameObject bossBlastSpawn4;
    public GameObject bossBlastSpawn5;
    public GameObject bossBlastSpawn6;
    public GameObject bossBlastSpawn7;
    public GameObject bossBlastSpawn8;
    public GameObject bossBlastSpawn9;

    public GameObject bossRocketSpawn0;
    public GameObject bossRocketSpawn1;
    public GameObject bossRocketSpawn2;
    public GameObject bossRocketSpawn3;
    public GameObject bossRocketSpawn4;
    public GameObject bossRocketSpawn5;
    public GameObject bossRocketSpawn6;
    public GameObject bossRocketSpawn7;

    public int bossHealth = 30;
    private bool triggeredOnce = false;
    private bool firstBossStartUp = true;
    private IEnumerator cor;
    private IEnumerator cor2;
    private GameObject[] blastSpawn;
    private GameObject[] rocketSpawn;
    private Animator anim;
    private AudioSource aud;

    void Start()
    {
        cor = Action();
        cor2 = Laser();
        anim = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();

        //Load projectile spawn locations
        blastSpawn = new GameObject[] { bossBlastSpawn0, bossBlastSpawn1, bossBlastSpawn2, bossBlastSpawn3, bossBlastSpawn4, bossBlastSpawn5, bossBlastSpawn6, bossBlastSpawn7, bossBlastSpawn8, bossBlastSpawn9 };
        rocketSpawn = new GameObject[] { bossRocketSpawn0, bossRocketSpawn1, bossRocketSpawn2, bossRocketSpawn3, bossRocketSpawn4, bossRocketSpawn5, bossRocketSpawn6, bossRocketSpawn7 };
    }

    void Update()
    {
        //Activate Boss when player arrives
        if (playerIsHere && !triggeredOnce)
        {
            StartCoroutine(cor);
            StartCoroutine(cor2);
            triggeredOnce = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Boss Health system
        if (other.tag == "Projectile")
        {
            bossHealth -= 1;
            if (bossHealth <= 0)
            {
                going = false;
                StopCoroutine(cor);
                StopCoroutine(cor2);
                anim.Play("boss_powerdown", -1);
            }
        }
    }

    //Projectile spawn sequence
    IEnumerator Action()
    {
        yield return new WaitForSeconds(7);
        while (going)
        {

            for (int i = 0; i < 3; i++)
            {
                yield return new WaitForSeconds(1);
                for (int j = 0; j < blastSpawn.Length; j += 2)
                {
                    Instantiate(bossBlast, blastSpawn[j].transform.position, Quaternion.identity);
                }
            }

            for (int i = 0; i < 3; i++)
            {
                yield return new WaitForSeconds(1);
                for (int j = 1; j < blastSpawn.Length; j += 2)
                {
                    Instantiate(bossBlast, blastSpawn[j].transform.position, Quaternion.identity);

                }
            }

            for (int i = 0; i < 3; i++)
            {
                yield return new WaitForSeconds(1);
                for (int j = 1; j < blastSpawn.Length; j += 2)
                {
                    Instantiate(bossBlast, blastSpawn[j].transform.position, Quaternion.identity);
                    if (i % 2 == 0)
                    {
                        yield return new WaitForSeconds(1);
                        for (int k = 0; k < rocketSpawn.Length; k += 4)
                        {
                            Instantiate(bossRocket, rocketSpawn[k].transform.position, Quaternion.identity);
                        }
                    }
                }
            }
        }
    }

    //Laser sequence. WaitForSeconds methods to sync script timing with animation and sound.
    IEnumerator Laser()
    {
        while (going)
        {
            yield return new WaitForSeconds(2);
            if (firstBossStartUp)
                anim.Play("boss_startup", -1);
            firstBossStartUp = false;
            yield return new WaitForSeconds(5);
            anim.Play("laser_fire", -1);

            yield return new WaitForSeconds(1);
            aud.Play();
            GetComponent<BoxCollider2D>().enabled = true;
            yield return new WaitForSeconds(3);
            anim.Play("boss_idle", -1);
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
