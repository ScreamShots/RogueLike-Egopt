using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcherMovement : MonoBehaviour
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
    public Transform playerTransform;

    private void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }
    private void FixedUpdate()
    {
        horizontalMoove = playerTransform.position.x - transform.position.x;
        verticalMoove = playerTransform.position.y - transform.position.y;
        move = new Vector3(horizontalMoove, verticalMoove, 0);
        move.Normalize();

        if (Vector2.Distance(transform.position, playerTransform.position) > stoppingDistance)
        {
            rb.velocity = move * speed * Time.deltaTime;
        }
        else if (Vector2.Distance(transform.position, playerTransform.position) < stoppingDistance && Vector2.Distance(transform.position, playerTransform.position) > retreatDistance)
        {

            rb.velocity = new Vector3(0, 0, 0);
        }
        else if (Vector2.Distance(transform.position, playerTransform.position) < retreatDistance)
        {
            rb.velocity = move * -speed * Time.deltaTime;
        }
    }
}
