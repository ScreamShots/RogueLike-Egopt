using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager gameManager;

    public int score;
    public int gold;

    // Start is called before the first frame update
    void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        score = 0;
        gold = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(string source)
    {
        switch (source)
        {
            case "Golem":
                score += 350;
                break;
            case "Skeleton":
                score += 220;
                break;
            case "Scorpion":
                score += 200;
                break;
            default:
                break;
        }
    }
}
