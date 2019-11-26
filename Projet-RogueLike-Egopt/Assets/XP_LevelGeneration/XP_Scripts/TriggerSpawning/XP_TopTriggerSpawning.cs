using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP_TopTriggerSpawning : MonoBehaviour
{
    public GameObject leftTrigger;
    public GameObject rightTrigger;
    public GameObject bottomTrigger;


    public Transform[] points;


    //Pour la Liste
    public List<GameObject> enemies = new List<GameObject>();

    int randEnemy;

    private void Awake()
    {
        //récupérer les points de spawn dans la zone.
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            for (int i = 0; i < points.Length; i++)
            {
                //Augmenter la Range en fonction du nombre d'ennemis.
                randEnemy = Random.Range(0, 2);
                //Faire apparaitre un ennemi aléatoire en fonction du nombre sortie à la position du waypoint.
                Instantiate(enemies[randEnemy], points[i].transform.position, transform.rotation);
                Debug.Log(enemies);
            }

            //Destroy(leftTrigger);
            //Destroy(rightTrigger);
            //Destroy(bottomTrigger);
            //Destroy(gameObject);
        }
    }
 
}
