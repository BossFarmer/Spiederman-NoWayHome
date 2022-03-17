using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NextAreaCheck : MonoBehaviour
{
    public event Action<bool, int, GameObject> RespawnBarrier;
    public event Action<bool, int, GameObject> RespawnBarrier2;
    private PlayerOneScript pl1;
    private PlayerTwoScript pl2;
    public GameObject player1;
    public GameObject player2;
    public Camera mainCam;
    public Camera secondCam;
    private int dcp1;
    private int dcp2;


    private void Start()
    {
        pl1 = player1.GetComponent<PlayerOneScript>(); 
        pl2 = player2.GetComponent<PlayerTwoScript>();
    }

    private void Update()
    {
        dcp1 = pl1.deathCountPlayer1Barrierr;
        dcp2 = pl2.deathCountPlayer2Barrier;
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Player 1 passed thru");
            player1.GetComponent<CharacterController>().enabled = false;
            player1.transform.position = mainCam.transform.position + mainCam.transform.forward;
            player1.GetComponent<CharacterController>().enabled = true;
            RespawnBarrier?.Invoke(true,dcp1, this.gameObject);
        }

        if (other.gameObject.tag == "Player2")
        {
            Debug.Log("Player 2 passed thru");
            player2.GetComponent<CharacterController>().enabled = false;
            player2.transform.position = secondCam.transform.position + secondCam.transform.forward;
            player2.GetComponent<CharacterController>().enabled = true;
            RespawnBarrier2?.Invoke(true,dcp2, this.gameObject);
        }
    }
}
