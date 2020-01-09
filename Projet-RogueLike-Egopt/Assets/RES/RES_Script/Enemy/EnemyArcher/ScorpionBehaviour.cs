using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionBehaviour : MonoBehaviour
{
    [HideInInspector] public bool isPlayerInRange;
    [HideInInspector] public bool isPlayerTooClose;

    [SerializeField] private float speed;
    [SerializeField] private float shotCd;
    public float launchingTime;
    public float spawnTime;

    public bool canShot;
    public bool isShooting;
    public bool isSpawned;


    private Rigidbody2D scorpionRgb;
    public Vector3 move;
    public Vector3 lastMove;
    public Vector3 velocity;
    [SerializeField] private GameObject scorpionsMunition;

    

    private void Start()
    {
        velocity = new Vector3(0, 0, 0);
        isSpawned = false;
        isPlayerInRange = false;
        isPlayerTooClose = false;
        isShooting = false;

        canShot = true;

        scorpionRgb = GetComponent<Rigidbody2D>();

        move = new Vector3(0, 0, 0);
        lastMove = new Vector3(0, 0, 0);

        StartCoroutine(Spawn());
    }

    private void FixedUpdate()
    {
        if (isSpawned == true && GetComponent<EnemyHealthSystem>().isDead == false)
        {
            move = -(transform.position - GameManager.gameManager.player.transform.position).normalized;


            if (isPlayerInRange == false)
            {
                scorpionRgb.velocity = move * speed * Time.fixedDeltaTime;
                
            }
            else if (isPlayerInRange == true && isPlayerTooClose == false)
            {
                scorpionRgb.velocity = new Vector3(0, 0, 0);
            }
            else if (isPlayerTooClose == true)
            {
                scorpionRgb.velocity = -move * speed * Time.fixedDeltaTime;
            }

            if (isPlayerInRange == true && isPlayerTooClose == false)
            {

                StartCoroutine(Shoot());

            }
        }
        velocity = scorpionRgb.velocity;
    }

    IEnumerator Shoot()
    {
        if (canShot == true)
        {
            lastMove = move;
            canShot = false;
            isShooting = true;

            yield return new WaitForSeconds(launchingTime);

            if (isPlayerTooClose == true)
            {
                isShooting = false;
                canShot = true;
                lastMove = new Vector3(0, 0, 0);
                yield break;
                
            }
            else
            {
                Instantiate(scorpionsMunition, transform.position, Quaternion.identity);
                isShooting = false;
            }
            
            isShooting = false;

            yield return new WaitForSeconds(shotCd);
            canShot = true;
            lastMove = new Vector3(0, 0, 0);
        }
        
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(spawnTime);

        isSpawned = true;
    }
}
