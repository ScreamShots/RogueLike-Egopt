using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManaging : MonoBehaviour
{
    public bool gameIsPaused;
    public bool gameIsRunning;
    public bool inHUB;

    private MenuManager menuStuff;

    // Start is called before the first frame update
    void Start()
    {
        menuStuff = GetComponent<MenuManager>();
    }

    private void FixedUpdate()
    {
        NewGameSceneLoad();
    }
    public void NewGameSceneLoad()
    {
        if (Input.GetKeyDown(KeyCode.A) && !gameIsPaused)
        {
            SceneManager.LoadScene("TestGameScene", LoadSceneMode.Single);
            gameIsRunning = true;
            inHUB = false;
            Debug.Log("Scene is loaded");
        }
    }

    public void CloseGame()
    {
        Debug.Log("Game is closed");
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void LoadHUB()
    {
        Debug.Log("Here is the HUB");
        gameIsRunning = true;
        inHUB = true;
        gameIsPaused = false;
        SceneManager.LoadScene("HUBScene");
    }
}
