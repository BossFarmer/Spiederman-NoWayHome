using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentScript : MonoBehaviour
{
    private int currentWeapon = 0;
    private int nextWeapon;
    private void Start()
    {
        ChoseWeapon();
    }
    private void Update()
    {
        ChangeWeapon();
    }

    void ChoseWeapon()
    {
        int index = 0;
        foreach (Transform weapon in transform)
        {
            if (index == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            index++;
        }
    }
    void ChangeWeapon()
    {
        nextWeapon = currentWeapon;
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (currentWeapon >= transform.childCount -1)
            {
                currentWeapon = 0;
            }
            else
            {
                currentWeapon++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (currentWeapon <= 0 )
            {
                currentWeapon = transform.childCount - 1;
            }
            else
            {
                currentWeapon--;
            }
        }
        if (nextWeapon!= currentWeapon)
        {
            ChoseWeapon();
        }
    }
}
