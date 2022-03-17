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
    [SerializeField]
    private PlayerOneScript Pl1Script;
    [SerializeField]
    private PlayerTwoScript Pl2Script;
    private WeapoScript weapoScript1, weapoScript2;
    private int magSize1, magSize2, magSize3, magSize4;
    public GameObject currWeapon;
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
        Debug.Log("Magazin Größe"+ HUDScript.P1Mag);

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
        PlayerInputActions action = new PlayerInputActions();
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
    public void WaffenZuweisung()
    {
    }

    void ChangeWeapon()
    {
        nextWeapon = currentWeapon;
        if (mouseInput > 0 || controllerInput > 0)
        {
            primaryWeapon = true;
            sekundaryWeapon = false;
            currWeapon = Pl1Script.PrimaryWeapon;
            Pl1Script.PrimaryWeapon.SetActive(true);
            Pl1Script.SekundaryWeapon.SetActive(false);
            Pl2Script.PrimaryWeapon.SetActive(true);
            Pl2Script.SekundaryWeapon.SetActive(false);
        }
        if (mouseInput < 0 || controllerInput < 0)
        {
            primaryWeapon = false;
            sekundaryWeapon = true;
            currWeapon = Pl1Script.SekundaryWeapon;
            Pl1Script.PrimaryWeapon.SetActive(false);
            Pl1Script.SekundaryWeapon.SetActive(true);
            Pl2Script.PrimaryWeapon.SetActive(false);
            Pl2Script.SekundaryWeapon.SetActive(true);
        }
        if (nextWeapon != currentWeapon)
        {
            ChoseWeapon();
        }
    }
}
