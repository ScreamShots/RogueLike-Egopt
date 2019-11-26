using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    private SceneManaging sceneStuff;

    public GameObject pauseMenu;
    public GameObject optionMenu;
    public GameObject titleMenu;

    // Start is called before the first frame update
    void Start()
    {
        sceneStuff = GetComponent<SceneManaging>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7)) && !sceneStuff.gameIsPaused && sceneStuff.gameIsRunning)
        {
            Time.timeScale = 0f;
            sceneStuff.gameIsPaused = true;
            Debug.Log("Game is pausing");
            pauseMenu.SetActive(true);
            //SceneManager.LoadScene("PauseScreenScene", LoadSceneMode.Additive);
            Debug.Log("Game paused");
        }
        else if (sceneStuff.gameIsPaused && sceneStuff.gameIsRunning)
        {
            UnloadPauseButton();
        }
        else if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7)) && sceneStuff.gameIsPaused)
        {
            UnloadPauseButton();
        }
    }

    public void UnloadPauseButton()
    {
        sceneStuff.gameIsPaused = false;
        Debug.Log("Unpausing game");
        pauseMenu.SetActive(false);
        //SceneManager.UnloadSceneAsync("PauseScreenScene");
        Time.timeScale = 1f;
        Debug.Log("Game playing");
    }

    public void LoadOptions()
    {
        optionMenu.SetActive(true);
        pauseMenu.SetActive(false);
        titleMenu.SetActive(false);
        Time.timeScale = 0f;
        //SceneManager.LoadScene("SettingScene", LoadSceneMode.Additive);
        Debug.Log("Options opened");
    }

    public void QuitOptionsPause()
    {
        optionMenu.SetActive(false);
        pauseMenu.SetActive(true);
        //SceneManager.UnloadSceneAsync("SettingScene");
        Debug.Log("Options closed");
    }

    public void QuitOptionsTitle()
    {
        optionMenu.SetActive(false);
        titleMenu.SetActive(true);
        Debug.Log("Options closed");
    }
    public void ReturnToTitle()
    {
        sceneStuff.gameIsPaused = false;
        sceneStuff.inHUB = false;
        Debug.Log("Unpausing and getting back to title");
        pauseMenu.SetActive(false);
        //SceneManager.UnloadSceneAsync("PauseScreenScene");
        sceneStuff.gameIsRunning = false;
        SceneManager.LoadScene("TitleScreenScene");
        Time.timeScale = 1f;
        Debug.Log("You're back to title");
    }
}
