using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : MonoBehaviour
{

    // Mouvement

    public float speed;
    private Transform target;
    public float stoppingDistance;

    // Main 

    private GameObject player;
    private Rigidbody2D rb;
    private Animator anim;

    // Attaque

    private bool isAttacking = false;

    // ShockWave

    private CircleCollider2D shockWave;
    public float speedShockWave;
    public float deltaDistance;
    private bool startShockWave = false;
    


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        shockWave = GetComponent<CircleCollider2D>();        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        GolemAttack();

        if (isAttacking)
        {
            startShockWave = true;
        }
    }

    private void FixedUpdate()
    {
        if (startShockWave)
        {
            shockWave.radius += speedShockWave * Time.deltaTime;
        }

        if (shockWave.radius >= stoppingDistance + deltaDistance)
        {
            startShockWave = false;
            shockWave.radius = 0;
            isAttacking = false;
        }
    }

    private void Move()
    {
        if (Vector3.Distance(target.position, transform.position) >= stoppingDistance)
        {
            rb.velocity = (target.position - transform.position).normalized * speed;
            //anim.SetBool("isMoving", true);
        }
        else
        {
            rb.velocity = Vector2.zero;
            //anim.SetBool("isMoving", false);
        }

        if (isAttacking)
        {
            rb.velocity = Vector2.zero;
            //anim.SetBool("isMoving", false);
        }
    }

    private void GolemAttack()
    {
        if (Vector3.Distance(target.position, transform.position) <= stoppingDistance)
        {
            //SI LE COOLDOWN ATTEINT 0
            //anim.SetBool("isAttacking", true);
            isAttacking = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shockWave.radius);
    }
}
