using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManaging : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public static bool gameIsRunning = false;
    public static bool inHUB = false;

    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            NewGameSceneLoad();
        }
        else
        {

        }
    }
    public void NewGameSceneLoad()
    {
        SceneManager.LoadScene("TestGameScene", LoadSceneMode.Single);
        gameIsRunning = true;
        inHUB = false;
        Debug.Log("Scene is loaded");
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
