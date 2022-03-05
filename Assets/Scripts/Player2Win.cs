using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player2Win : MonoBehaviour
{
    public Text WinnerText;
    public GameObject WinningScreen;
    public AllMenuScript allMenuScript;
    public GameObject ripPauseMenu;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerTwo")
        {
            WinnerText.text = "Player Two has won the Game!";
            allMenuScript.escapeInput = true;
            Time.timeScale = 0f;
            WinningScreen.SetActive(true);
            Destroy(ripPauseMenu);

        }
        if(other.gameObject.tag == "Player")
        {
            WinnerText.text = "Player One has won the Game!";
            allMenuScript.escapeInput = true;
            Time.timeScale = 0f;
            WinningScreen.SetActive(true);
            Destroy(ripPauseMenu);
        }
    }
}
