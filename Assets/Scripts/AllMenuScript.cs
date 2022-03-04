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
    private bool escapeInput;

    // Update is called once per frame
    private void Awake()
    {
        PlayerInputAction action = new PlayerInputAction();
        action.Enable();
        action.Player.MenuPopUp.performed += MenuPupupInput;

    }

    private void MenuPupupInput(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        var controll = obj.control;
        var button = controll as ButtonControl;
        escapeInput = obj.action.triggered;
    }

    void Update()
    {
        PauseMenu();
    }

    void PauseMenu()
    {
        if (escapeInput)
        {
            Debug.Log("Escape was pressed");
            if (GameIsPaused)
            {
                Resume();
                buttonPressed = false;
            }
            else
            {
                Pause();
            }
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
