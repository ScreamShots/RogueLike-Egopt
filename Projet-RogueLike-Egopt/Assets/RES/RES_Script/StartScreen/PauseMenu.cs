using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject[] mainButtons;
    public GameObject settingsMenu;
    public Button[] settingsButton;

    public GameObject eventSystem;
    public GameObject musicSlider;
    public GameObject effectsSlider;
    public GameObject masterSlider;

    public bool subMenuActive = false;
    public bool subSettingsMenuActive = false;
    public bool onSoundSettings = false;
    public bool pauseMenuOn;
    public bool alreadySwap = false;


    public GameObject graphicSettings;
    public GameObject soundSettings;
    public GameObject[] graphicOptions;
    public GameObject[] soundOption;

    public GameObject menu;
    public GameObject hud;



    private void Update()
    {
        if(pauseMenuOn == false)
        {
            if (Input.GetButtonDown("Menu") && RoomGenerationHandler.isLevelPlayable == true)
            {
                menu.SetActive(true);
                hud.SetActive(false);
                pauseMenuOn = true;
                StartCoroutine(ParallelUpdate());
                Time.timeScale = 0;
                eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(mainButtons[0].gameObject);
            }
        }
       
            if (Input.GetButtonDown("BackMenu"))
            {
                if (subMenuActive == true)
                {
                    foreach (GameObject button in mainButtons)
                    {
                        button.SetActive(true);
                    }

                    settingsMenu.SetActive(false);
                    eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(mainButtons[0].gameObject);

                    subMenuActive = false;
                }
                else if (subSettingsMenuActive == true)
                {
                    soundSettings.SetActive(false);
                    graphicSettings.SetActive(false);

                    for (int i = 0; i < settingsButton.Length; i++)
                    {
                        settingsButton[i].GetComponent<Button>().enabled = true;
                        settingsButton[i].gameObject.GetComponent<Image>().enabled = true;
                    }
                    eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(settingsButton[0].gameObject);

                    subSettingsMenuActive = false;
                    subMenuActive = true;
                    onSoundSettings = false;
                }
            }

        if (Input.GetAxisRaw("VerticalMenuMoveAlt") > 0)
        {

            if (eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().currentSelectedGameObject == effectsSlider && alreadySwap == false)
            {
                eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(musicSlider);
                alreadySwap = true;
            }
            else if (eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().currentSelectedGameObject == musicSlider && alreadySwap == false)
            {
                eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(masterSlider);
                alreadySwap = true;
            }
        }
        else if (Input.GetAxisRaw("VerticalMenuMoveAlt") < 0)
        {
            if (eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().currentSelectedGameObject == musicSlider && alreadySwap == false)
            {
                eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(effectsSlider);
                alreadySwap = true;
            }
            else if(eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().currentSelectedGameObject == masterSlider && alreadySwap == false)
            {
                eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(musicSlider);
                alreadySwap = true;
            }
        }
        
        if(alreadySwap == true) {

            StartCoroutine(ResetMenuMove());
        }
    }

    public IEnumerator ParallelUpdate()
    {

        if (Input.GetButtonDown("BackMenu"))
        {
            if (subMenuActive == true)
            {
                foreach (GameObject button in mainButtons)
                {
                    button.SetActive(true);
                }

                settingsMenu.SetActive(false);
                eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(mainButtons[0].gameObject);

                subMenuActive = false;
            }
            else if (subSettingsMenuActive == true)
            {
                soundSettings.SetActive(false);
                graphicSettings.SetActive(false);

                for (int i = 0; i < settingsButton.Length; i++)
                {
                    settingsButton[i].GetComponent<Button>().enabled = true;
                    settingsButton[i].gameObject.GetComponent<Image>().enabled = true;
                }
                eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(settingsButton[0].gameObject);

                subSettingsMenuActive = false;
                subMenuActive = true;
                onSoundSettings = false;
            }
        }

        if (Input.GetAxisRaw("VerticalMenuMoveAlt") > 0)
        {

            if (eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().currentSelectedGameObject == effectsSlider && alreadySwap == false)
            {
                eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(musicSlider);
                alreadySwap = true;
            }
            else if (eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().currentSelectedGameObject == musicSlider && alreadySwap == false)
            {
                eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(masterSlider);
                alreadySwap = true;
            }
        }
        else if (Input.GetAxisRaw("VerticalMenuMoveAlt") < 0)
        {
            if (eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().currentSelectedGameObject == musicSlider && alreadySwap == false)
            {
                eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(effectsSlider);
                alreadySwap = true;
            }
            else if (eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().currentSelectedGameObject == masterSlider && alreadySwap == false)
            {
                eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(musicSlider);
                alreadySwap = true;
            }
        }

        if (alreadySwap == true)
        {

            StartCoroutine(ResetMenuMove());
        }

        yield return new WaitForSecondsRealtime(0.0001f);
        if(Time.timeScale == 0)
        {
            StartCoroutine(ParallelUpdate());
        }        
    }







    public IEnumerator ResetMenuMove()
    {
        yield return new WaitForSeconds(0.0001f);
        alreadySwap = true;
    }
    public void GoBackToTheGame()
    {
        menu.SetActive(false);
        pauseMenuOn = false;
        hud.SetActive(true);
        Time.timeScale = 1;
    }

    public void OpenSetting()
    {
        foreach(GameObject button in mainButtons)
        {
            button.SetActive(false);            
        }

        settingsMenu.SetActive(true);
        subMenuActive = true;
        eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(settingsButton[0].gameObject);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void OpenGraphicsSettings()
    {
        soundSettings.SetActive(false);
        graphicSettings.SetActive(true);

        for (int i = 0; i < settingsButton.Length; i++)
        {
            settingsButton[i].GetComponent<Button>().enabled = false;
            settingsButton[i].gameObject.GetComponent<Image>().enabled = false;
        }
        eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(graphicOptions[0]);
        subMenuActive = false;
        subSettingsMenuActive = true;

    }

    public void OpenSoundSettings()
    {
        soundSettings.SetActive(true);
        graphicSettings.SetActive(false);

        for (int i = 0; i < settingsButton.Length; i++)
        {
            settingsButton[i].GetComponent<Button>().enabled = false;
        }

        eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(soundOption[0]);
        subMenuActive = false;
        subSettingsMenuActive = true;
        onSoundSettings = true;
    }
}
