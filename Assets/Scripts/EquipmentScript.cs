using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentScript : MonoBehaviour
{
    [SerializeField] private Transform playerHands;
    private bool weaponEquipt = false;
    private ConnectWeapon cws;
    private Vector3 weaponRotation;
    private GameObject gun;
    void Update()
    {
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Gun" && !weaponEquipt)
        {
            Debug.Log("Die Waffe wird berührt!");
            gun = collision.gameObject;
            if (gun.GetComponent<ConnectWeapon>())
            {
                cws = gun.GetComponent<ConnectWeapon>();
            }
            PickUpWeapon();
        }
    }
    void PickUpWeapon()
    {
        if (gun != null)
        {
            weaponEquipt = true;
            gun.transform.parent = playerHands.transform;
            //gun.transform.position = new Vector3(0,0,0);
        }
    }

}
