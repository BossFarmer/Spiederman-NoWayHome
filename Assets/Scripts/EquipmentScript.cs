using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class EquipmentScript : MonoBehaviour
{
    private int currentWeapon = 0;
    private int nextWeapon;
    private float mouseInput;
    private float controllerInput = 0f;

    private void Awake()
    {
        PlayerInputAction action = new PlayerInputAction();
        action.Player.Enable();
        action.Player.ChangeWeaponsMouse.performed += MouseInputScroll;
        action.Player.ChangeWeaponsControllerRight.performed += ControllerInput;
        action.Player.ChangeWeaponsControllerLeft.performed += ControllerInputLeft; ;

    }

    private void ControllerInputLeft(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        var controll = obj.control;
        var button = controll as ButtonControl;
        if (button.wasPressedThisFrame)
        {
            controllerInput -= obj.ReadValue<float>();
        }
        Debug.Log( "left schoulder was pressed: "+controllerInput);
    }

    private void ControllerInput(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        var controll = obj.control;
        var button = controll as ButtonControl;
        if (button.wasPressedThisFrame)
        {
            controllerInput = obj.ReadValue<float>();
        }
        Debug.Log("right schoulder was pressed: " + controllerInput);

    }

    private void MouseInputScroll(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        mouseInput = obj.ReadValue<float>();
    }

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
        if (mouseInput > 0 || controllerInput > 0)
        {
            controllerInput = 0;
            if (currentWeapon >= transform.childCount -1)
            {
                currentWeapon = 0;
            }
            else
            {
                currentWeapon++;
            }
        }
        if (mouseInput < 0 || controllerInput < 0)
        {
            controllerInput = 0;
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
