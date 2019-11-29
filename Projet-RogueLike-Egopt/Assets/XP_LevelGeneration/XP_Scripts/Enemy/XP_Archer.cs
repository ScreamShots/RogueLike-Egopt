using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP_Archer : MonoBehaviour
{
    //Distances
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public Rigidbody2D rb;

    //Deplacements
    public Vector3 move;
    public float horizontalMoove;
    public float verticalMoove;


    //references
    public Transform player;
    public GameObject bullet;
    //Shooting
    private float timeBtwShots;
    public float startTimeBtwShots;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMoove = player.position.x - transform.position.x;
        verticalMoove = player.position.y - transform.position.y;
        move = new Vector3(horizontalMoove, verticalMoove, 0);
        move.Normalize();

        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            rb.velocity = move * speed * Time.deltaTime;
        } else if (Vector2.Distance(transform.position,player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance){

            rb.velocity = new Vector3(0,0,0);
        } else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            rb.velocity = move * -speed * Time.deltaTime;
        }
       

        if (timeBtwShots <= 0){
            Instantiate(bullet, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }else{
            timeBtwShots -= Time.fixedDeltaTime;
        }
    }
}
