﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public Button[] mainButtons;
    public Button[] settingsButton;

    public GameObject optionMenu;
    public GameObject graphicSettings;
    public GameObject soundSettings;
    public GameObject[] graphicOptions;
    public GameObject[] soundOption;
    public GameObject eventSystem;

    public bool subMenuActive = false;
    public bool subSettingsMenuActive = false;
    public bool onSoundSettings = false;

    private void Update()
    {
        if (Input.GetButtonDown("BackMenu"))
        {
            if (subMenuActive == true)
            {
                for (int i = 0; i < mainButtons.Length; i++)
                {
                    mainButtons[i].GetComponent<Button>().enabled = true;
                }

                optionMenu.SetActive(false);
                eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(mainButtons[0].gameObject);

                subMenuActive = false;
            }
            else if(subSettingsMenuActive == true)
            {
                soundSettings.SetActive(false);
                graphicSettings.SetActive(false);

                for (int i = 0; i < settingsButton.Length; i++)
                {
                    settingsButton[i].GetComponent<Button>().enabled = true;
                }
                eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(settingsButton[0].gameObject);

                subSettingsMenuActive = false;
                subMenuActive = true;
                onSoundSettings = false;
            }
        }
    }


    public void LaunchTheGame()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToCredits()
    {
        SceneManager.LoadScene(2);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void OpenSettings()
    {
        for (int i = 0; i < mainButtons.Length; i++)
        {
            mainButtons[i].GetComponent<Button>().enabled = false;
        }

        optionMenu.SetActive(true);
        eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(settingsButton[0].gameObject);
        subMenuActive = true;
    }

    public void OpenGraphicsSettings()
    {
        soundSettings.SetActive(false);
        graphicSettings.SetActive(true);

        for (int i = 0; i < settingsButton.Length; i++)
        {
            settingsButton[i].GetComponent<Button>().enabled = false;
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
