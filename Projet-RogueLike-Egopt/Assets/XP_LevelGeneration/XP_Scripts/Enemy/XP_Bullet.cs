using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP_Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;

    public Rigidbody2D rb;

    private Transform player;
    


    public Vector3 targetPosition;
    public float HtargetMove;
    public float VtargetMove;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        HtargetMove = player.position.x - transform.position.x;
        VtargetMove = player.position.y - transform.position.y;

        targetPosition = new Vector3(HtargetMove, VtargetMove, 0);
        targetPosition.Normalize();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        rb.velocity = targetPosition * speed * Time.fixedDeltaTime;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Mettre les Degats
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Walls")
        {
           
            Destroy(gameObject);
        }
    }
}
