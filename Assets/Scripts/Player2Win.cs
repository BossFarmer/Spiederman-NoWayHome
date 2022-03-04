using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player2Win : MonoBehaviour
{
    public Text WinnerText;
    public GameObject WinningScreen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerTwo")
        {
            WinnerText.text = "Player two has Won the Game!";
            WinningScreen.SetActive(true);
        }
    }
}
