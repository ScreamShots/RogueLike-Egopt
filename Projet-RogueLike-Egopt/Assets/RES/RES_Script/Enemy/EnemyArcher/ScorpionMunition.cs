using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionMunition : MonoBehaviour
{
    private Rigidbody2D munitionRgb;
    private Transform playerTransform;
    private Vector3 targetedPosition;

    [SerializeField] private float speed;
    [SerializeField] private float dmg;

    public bool isDestructible;

    private void Start()
    {
        munitionRgb = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.FindWithTag("Player").transform;
        isDestructible = false;

        targetedPosition = -(transform.position - playerTransform.position).normalized;
    }

    private void FixedUpdate()
    {
        float timer = 0.2f;

        munitionRgb.velocity = targetedPosition * speed * Time.fixedDeltaTime;

        timer -= Time.fixedDeltaTime;

        if (timer <= 0 )
        {
            isDestructible = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Walls" || collision.gameObject.tag == "Props")
        {
            if(isDestructible == true)
            {
                Destroy(this.gameObject);
            }                    
        }
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealthSystem>().IsTakingDmg(dmg);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Walls" || collision.gameObject.tag == "Props")
        {
            isDestructible = true;
        }
    }
}
