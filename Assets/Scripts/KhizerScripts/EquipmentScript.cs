using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class EquipmentScript : MonoBehaviour
{
    private int currentWeapon = 0;
    private int nextWeapon;
    private float mouseInput;
    private float controllerInputLeft = 0f, controllerInputRight = 0f;
    [SerializeField]
    private PlayerOneScript Pl1Script;
    [SerializeField]
    private PlayerTwoScript Pl2Script;
    private WeapoScript weapoScript1, weapoScript2;
    private int magSize1, magSize2, magSize3, magSize4;
    public GameObject currWeapon, currWeapon2;
    private bool primaryWeapon, sekundaryWeapon;


    private void Awake()
    {
        CheckPlayer();
    }

    private void ControllerInputLeft(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        var controll = obj.control;
        var button = controll as ButtonControl;
        if (button.wasPressedThisFrame)
        {
            controllerInputLeft = obj.ReadValue<float>();
            if (controllerInputLeft <= 1)
            {
                controllerInputLeft = -1;
            }
            if (Pl2Script.SekundaryWeapon != null)
            {
                ChangeWeaponPlayer2(controllerInputLeft);
            }

        }
    }

    private void ControllerInput(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        var controll = obj.control;
        var button = controll as ButtonControl;
        if (button.wasPressedThisFrame)
        {
            controllerInputRight = obj.ReadValue<float>();
            if (controllerInputRight > -1)
            {
                controllerInputRight = 1;
            }

            if (Pl2Script.PrimaryWeapon != null)
            {
                ChangeWeaponPlayer2(controllerInputRight);
            }
        }
        Debug.Log("right schoulder was pressed: " + controllerInputRight);

    }

    private void MouseInputScroll(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        mouseInput = obj.ReadValue<float>();

        if (Pl1Script.PrimaryWeapon != null)
        {
            ChangeWeaponPlayer1(mouseInput);
        }

    }

    private void Start()
    {
        ChoseWeapon();
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

    public void CheckWeapon()
    {
        if (primaryWeapon)
        {
            Pl1Script.Inventar.Remove(Pl1Script.PrimaryWeapon);
            Pl1Script.PrimaryWeapon.SetActive(false);
            Pl1Script.PrimaryWeapon = Pl1Script.SekundaryWeapon;
            Pl1Script.SekundaryWeapon = null;
            Pl2Script.Inventar.Remove(Pl2Script.PrimaryWeapon);
            Pl2Script.PrimaryWeapon.SetActive(false);
            Pl2Script.PrimaryWeapon = null;
        }

        if (sekundaryWeapon)
        {
            Pl1Script.Inventar.Remove(Pl1Script.SekundaryWeapon);
            Pl1Script.SekundaryWeapon.SetActive(false);
            Pl1Script.SekundaryWeapon = null;
            Pl2Script.Inventar.Remove(Pl2Script.SekundaryWeapon);
            Pl2Script.SekundaryWeapon.SetActive(false);
            Pl2Script.SekundaryWeapon = null;
        }
        //if (magSize2 >= 0)
        //{
        //    Pl2Script.Inventar.RemoveAt(1);
        //}
        //if (magSize3 >= 0)
        //{
        //    Pl1Script.Inventar.RemoveAt(2);
        //}
        //if (magSize4 >= 0)
        //{
        //    Pl2Script.Inventar.RemoveAt(2);
        //}
    }

    private void CheckPlayer()
    {
        PlayerInputAction action = new PlayerInputAction();
        if (transform.parent.tag == "MainCamera")
        {
            //Debug.Log("this Player one");
            action.Player.Enable();
            action.Player.ChangeWeaponsMouse.performed += MouseInputScroll;
            Pl1Script = transform.root.gameObject.GetComponent<PlayerOneScript>();
        }

        if (transform.parent.tag == "SecondCamera")
        {
            //Debug.Log("This Player Two");
            action.Player2.Enable();
            action.Player2.ChangeWeaponsControllerRight.performed += ControllerInput;
            action.Player2.ChangeWeaponsControllerLeft.performed += ControllerInputLeft;
            Pl2Script = transform.root.gameObject.GetComponent<PlayerTwoScript>();
        }
    }
    void ChangeWeaponPlayer1(float mouseInput)
    {
        nextWeapon = currentWeapon;
        if (mouseInput > 0)
        {
            primaryWeapon = true;
            sekundaryWeapon = false;
            currWeapon = Pl1Script.PrimaryWeapon;
            Pl1Script.PrimaryWeapon.SetActive(true);
            Pl1Script.SekundaryWeapon.SetActive(false);
        }
        if (mouseInput < 0)
        {
            primaryWeapon = false;
            sekundaryWeapon = true;
            currWeapon = Pl1Script.SekundaryWeapon;
            Pl1Script.PrimaryWeapon.SetActive(false);
            Pl1Script.SekundaryWeapon.SetActive(true);
        }
        if (nextWeapon != currentWeapon)
        {
            ChoseWeapon();
        }
    }

    void ChangeWeaponPlayer2(float controllerInput)
    {
        nextWeapon = currentWeapon;
        if (controllerInput > -1)
        {
            Debug.Log("Primary active");
            primaryWeapon = true;
            sekundaryWeapon = false;
            currWeapon2 = Pl2Script.PrimaryWeapon;
            Pl2Script.PrimaryWeapon.SetActive(true);
            Pl2Script.SekundaryWeapon.SetActive(false);
        }
        if (controllerInput < 1)
        {
            Debug.Log("Secondayr active");
            primaryWeapon = false;
            sekundaryWeapon = true;
            currWeapon2 = Pl2Script.SekundaryWeapon;
            Pl2Script.PrimaryWeapon.SetActive(false);
            Pl2Script.SekundaryWeapon.SetActive(true);
        }
        if (nextWeapon != currentWeapon)
        {
            ChoseWeapon();
        }
    }
}
