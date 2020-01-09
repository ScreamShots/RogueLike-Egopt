using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager gameManager;

    public int score;
    public int gold;

    public GameObject loadingScreen;
    public Image loadingImage;
    public GameObject player;
    

    public float timer = 0;

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

    public void FixedUpdate()
    {
        loadingScreen = GameObject.FindWithTag("LoadingScreen");
        


        if(loadingScreen != null)
        {
            loadingImage = loadingScreen.GetComponentInChildren<Image>();

            if (RoomGenerationHandler.isLevelPlayable == true && loadingScreen.activeInHierarchy == true)
            {                
                    loadingScreen.SetActive(false);
            }
            else if (RoomGenerationHandler.isLevelPlayable == false)
            {
                timer = 0;
                loadingScreen.SetActive(true);
            }
        }

        if (GameObject.FindWithTag("Player") != null)
        {
            if (player == null)
            {
                player = GameObject.FindWithTag("Player");
            }
            else if (player != null && player != GameObject.FindWithTag("Player"))
            {
                Destroy(player);
                player = GameObject.FindWithTag("Player");
            }
        }
        
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

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
        score = 0;
        gold = 0;
    }
}
