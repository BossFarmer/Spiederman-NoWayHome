using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentScript : MonoBehaviour
{
    [SerializeField] private Transform playerHands;
    private bool weaponEquipt = true;
    private ConnectWeapon cws;
    private Vector3 handsPosition;
    void Update()
    {
        handsPosition = playerHands.position; 
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Gun")
        {
            Debug.Log("Die Waffe wird berührt!");
            GameObject gun = collision.gameObject;
            if (gun.GetComponent<ConnectWeapon>())
            {
                cws = gun.GetComponent<ConnectWeapon>();
            }
            //Die Waffe wird aufgehoben
        }
    }

}
