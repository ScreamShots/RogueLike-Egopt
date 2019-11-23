using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManaging : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool GameIsRunning = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        PauseGame();
    }
    public void NewGameSceneLoad()
    {
        SceneManager.LoadScene("TestGameScene", LoadSceneMode.Single);
        GameIsRunning = true;
        Debug.Log("Scene is loaded");
    }

    public void CloseGame()
    {
        Debug.Log("Game is closed");
        Application.Quit();
    }

    public void PauseGame()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && GameIsPaused == false && GameIsRunning == true)
        {
            Time.timeScale = 0f;
            GameIsPaused = true;
            Debug.Log("Game is pausing");
            SceneManager.LoadScene("PauseScreenScene", LoadSceneMode.Additive);
            Debug.Log("Game paused");
        }
        else if(GameIsPaused == true && GameIsRunning == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GameIsPaused = false;
                Debug.Log("Game unpausing");
                SceneManager.UnloadSceneAsync("PauseScreenScene");
                Time.timeScale = 1f;
                Debug.Log("Game playing");
            }
            else
            {
                UnloadPauseButton();
            }
        }
    }

    public void UnloadPauseButton()
    {
        GameIsPaused = false;
        Debug.Log("Unpausing game");
        SceneManager.UnloadSceneAsync("PauseScreenScene");
        Time.timeScale = 1f;
        Debug.Log("Game playing");
    }

    public void ReturnToTitle()
    {
        GameIsPaused = false;
        GameIsRunning = false;
        Debug.Log("Unpausing and getting back to title");
        SceneManager.UnloadSceneAsync("PauseScreenScene");
        SceneManager.LoadScene("TitleScreenScene");
        Time.timeScale = 1f;
        Debug.Log("You're back to title");
    }

}
