using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class PlayerItemPickup : MonoBehaviour
//{
//    GameObject thePlayer = GameObject.Find("FPSPlayer");
//    CharacterMovement characterMovement  thePlayer.GetComponent<CharacterMovement>();
//    private void Start()
//    {
//        GameObject thePlayer = GameObject.Find("FPSPlayer");
//        CharacterMovement characterMovement  thePlayer.GetComponent<CharacterMovement>();
//    }


//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.gameObject.tag == "Items")
//        {
//            PowerUpScript PowerUp = other.GetComponent<PowerUpScript>();
//            switch (PowerUp.PowerUpType)
//            {
//                case PowerUpScript.EPowerups.plusJump:
//                    characterMovement.maxJumps++;
//                    Destroy(other.gameObject);
//                    break;
//                case PowerUpScript.EPowerups.plusDash:
//                    characterMovement.maxDash++;
//                    break;
//                case PowerUpScript.EPowerups.plusAmmo:
//                    //full ammo
//                    break;
//            }
//        }
//    }

//}
