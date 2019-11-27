using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewSceneManager : MonoBehaviour
{
    public static bool gameIsRunning;
    public static bool gameIsPaused;

    public Transform titleMenu;
    public Transform pauseMenu;
    public Transform optionsMenu;

    // Start is called before the first frame update
    void Start()
    {
        titleMenu = this.gameObject.transform.GetChild(0);
        pauseMenu = this.gameObject.transform.GetChild(1);
        optionsMenu = this.gameObject.transform.GetChild(2);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PauseMenu();
    }

    public void LoadTitle()
    {
        Debug.Log("Back to title");
        pauseMenu.gameObject.SetActive(false);
        optionsMenu.gameObject.SetActive(false);
        titleMenu.gameObject.SetActive(true);
        gameIsRunning = false;
    }

    public void LoadHUB()
    {
        Debug.Log("HUB is loaded");
        SceneManager.LoadScene("HUBScene", LoadSceneMode.Single);
        titleMenu.gameObject.SetActive(true);
        pauseMenu.gameObject.SetActive(false);
        optionsMenu.gameObject.SetActive(false);
        gameIsRunning = true;
        Time.timeScale = 1f;
    }
    public void LoadHUBFirst()
    {
        Debug.Log("HUB is loaded");
        titleMenu.gameObject.SetActive(false);
        pauseMenu.gameObject.SetActive(false);
        optionsMenu.gameObject.SetActive(false);
        gameIsRunning = true;
        Time.timeScale = 1f;
    }
    public void CloseGame()
    {
        Debug.Log("Game is closed");
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void ClosePause()
    {
        pauseMenu.gameObject.SetActive(false);
        gameIsPaused = false;
        Time.timeScale = 1f;
        Debug.Log("Game is unpaused");
    }

    public void PauseMenu()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7) && !gameIsPaused && gameIsRunning)
        {
            pauseMenu.gameObject.SetActive(true);
            gameIsPaused = true;
            Time.timeScale = 0f;
            Debug.Log("Game paused");
        }
        else if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7) && gameIsPaused && gameIsRunning)
        {
            ClosePause();
        }
    }

    public void BackToTitle()
    {
        //SceneManager.LoadScene("TitleScreenScene", LoadSceneMode.Single);
        gameIsPaused = false;
        gameIsRunning = false;
        pauseMenu.gameObject.SetActive(false);
        titleMenu.gameObject.SetActive(true);
        Debug.Log("Back to title");
        Destroy(this.gameObject);
    }

    public void OptionsMenu()
    {
        if (!gameIsRunning)
        {
            optionsMenu.gameObject.SetActive(true);
            titleMenu.gameObject.SetActive(false);
            Debug.Log("Options opened from title");
        }
        else if (gameIsPaused)
        {
            optionsMenu.gameObject.SetActive(true);
            pauseMenu.gameObject.SetActive(false);
            Debug.Log("Options opened from Pause");
        }
    }

    public void CloseOptions()
    {
        if (gameIsPaused)
        {
            pauseMenu.gameObject.SetActive(true);
            optionsMenu.gameObject.SetActive(false);
        }
        else if (!gameIsRunning)
        {
            titleMenu.gameObject.SetActive(true);
            optionsMenu.gameObject.SetActive(false);
        }
    }
}
