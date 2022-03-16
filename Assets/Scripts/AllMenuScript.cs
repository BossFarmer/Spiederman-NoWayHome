using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;

public class AllMenuScript : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public bool buttonPressed = false;
    public bool escapeInput;

    // Update is called once per frame

    private void Awake()
    {
        PlayerInputActions action = new PlayerInputActions();
        action.Enable();
        action.Player.MenuPopUp.performed += MenuPopUpInput;
    }

    private void MenuPopUpInput(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        var controll = obj.control;
        var button = controll as ButtonControl;
        escapeInput = true;
        PauseMenu();
    }

    void PauseMenu()
    {
        if (GameIsPaused)
        {
            Resume();
            buttonPressed = false;
        }
        else
        {
            Pause();
            escapeInput = false;
        }
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void BeginGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SceneBack()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
