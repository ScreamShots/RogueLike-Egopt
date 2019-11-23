using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

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
    public void PauseGame()
    {
        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7)) && gameIsPaused == false)
        {
            Time.timeScale = 0f;
            gameIsPaused = true;
            Debug.Log("Game is pausing");
            SceneManager.LoadScene("PauseScreenScene", LoadSceneMode.Additive);
            Debug.Log("Game paused");
        }
        else if (gameIsPaused == true)
        {
            UnloadPauseButton();
        }
        else if ((Input.GetKeyDown(KeyCode.Escape) || (Input.GetKeyDown(KeyCode.Joystick1Button7)) && gameIsPaused == true))
        {
            UnloadPauseButton();
        }
    }

    public void UnloadPauseButton()
    {
        gameIsPaused = false;
        Debug.Log("Unpausing game");
        SceneManager.UnloadSceneAsync("PauseScreenScene");
        Time.timeScale = 1f;
        Debug.Log("Game playing");
    }

    public void ReturnToTitle()
    {
        gameIsPaused = false;
        Debug.Log("Unpausing and getting back to title");
        SceneManager.UnloadSceneAsync("PauseScreenScene");
        SceneManager.LoadScene("TitleScreenScene");
        Time.timeScale = 1f;
        Debug.Log("You're back to title");
    }

    public void ReturntoHUB()
    {
        gameIsPaused = false;
        Debug.Log("Returning to HUB...");
        SceneManager.UnloadSceneAsync("PauseScreenScene");
        SceneManager.LoadScene("HUBScene");
        Time.timeScale = 1f;
        Debug.Log("In the HUB");
    }

}
