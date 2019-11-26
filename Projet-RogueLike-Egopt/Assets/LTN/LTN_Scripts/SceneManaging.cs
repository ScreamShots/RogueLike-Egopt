using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManaging : MonoBehaviour
{
    public bool gameIsPaused = false;
    public bool gameIsRunning = false;
    public bool inHUB = false;

    // Start is called before the first frame update
    void Start()
    {

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
            Time.timeScale = 1f;
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
        //PauseUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsRunning = true;
        inHUB = true;
        gameIsPaused = false;
        SceneManager.LoadScene("HUBScene");
    }
    public void ReturnToTitle()
    {
        gameIsPaused = false;
        inHUB = false;
        Debug.Log("Unpausing and getting back to title");
        //PauseUI.SetActive(false);
        SceneManager.UnloadSceneAsync("PauseScreenScene");
        gameIsRunning = false;
        SceneManager.LoadScene("TitleScreenScene");
        Time.timeScale = 1f;
        Debug.Log("You're back to title");
    }
}
