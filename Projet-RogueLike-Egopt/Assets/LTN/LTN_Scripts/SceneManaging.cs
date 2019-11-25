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

    public GameObject PauseUI;
    public GameObject OptionsUI;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        NewGameSceneLoad();
        PauseGame();
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
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsRunning = true;
        inHUB = true;
        gameIsPaused = false;
        SceneManager.LoadScene("HUBScene");
    }

    public void LoadOptions()
    {
        OptionsUI.SetActive(true);
        Time.timeScale = 0f;
        //SceneManager.LoadScene("SettingScene", LoadSceneMode.Additive);
        Debug.Log("Options opened");
    }

    public void QuitOptions()
    {
        OptionsUI.SetActive(false);
        //SceneManager.UnloadSceneAsync("SettingScene");
        Debug.Log("Options closed");
    }

    public void PauseGame()
    {
        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7)) && !gameIsPaused && gameIsRunning)
        {
            Time.timeScale = 0f;
            gameIsPaused = true;
            Debug.Log("Game is pausing");
            PauseUI.SetActive(true);
            //SceneManager.LoadScene("PauseScreenScene", LoadSceneMode.Additive);
            Debug.Log("Game paused");
        }
        else if (gameIsPaused && gameIsRunning)
        {
            UnloadPauseButton();
        }
        else if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7)) && gameIsPaused)
        {
            UnloadPauseButton();
        }
    }

    public void UnloadPauseButton()
    {
        gameIsPaused = false;
        Debug.Log("Unpausing game");
        PauseUI.SetActive(false);
        //SceneManager.UnloadSceneAsync("PauseScreenScene");
        Time.timeScale = 1f;
        Debug.Log("Game playing");
    }

    public void ReturnToTitle()
    {
        gameIsPaused = false;
        inHUB = false;
        Debug.Log("Unpausing and getting back to title");
        PauseUI.SetActive(false);
        //SceneManager.UnloadSceneAsync("PauseScreenScene");
        gameIsRunning = false;
        SceneManager.LoadScene("TitleScreenScene");
        Time.timeScale = 1f;
        Debug.Log("You're back to title");
    }
}
