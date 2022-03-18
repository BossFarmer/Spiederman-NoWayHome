using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashScript : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private CharacterMovement moveScript;
    [SerializeField] private float dashForce = 500f;
    private bool canDash = true;
    [SerializeField] private float dashCooldown = 2f;
    private float currentDashCooldown = 0f;
    private int totalDashCounter = 2;
    public static int currentDashCounter;

    private void Awake()
    {
        CheckPlayer(); 
    }

    private void DashInput(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (obj.performed)
        {
            MyInput();// Get every Input in the Update
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveScript = GetComponent<CharacterMovement>();
        currentDashCounter = totalDashCounter;
        currentDashCooldown = dashCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        DashCooldown();
    }

    void Dash()
    {
        moveScript.Controller.Move(moveScript.move * dashForce * Time.deltaTime);//ueses the characterController movementscriot for applying the dashforce
        currentDashCounter--;
        if (currentDashCounter <= 0)
        {
            Debug.Log("Dash wird aufgeladen");
            canDash = false;
        }
    }

    private void CheckPlayer()
    {
        PlayerInputAction action = new PlayerInputAction();
        if (this.gameObject.tag == "Player")
        {
            action.Player.Enable();
            action.Player.Dash.performed += DashInput;
        }

        if (this.gameObject.tag == "Player2")
        {
            action.Player2.Enable();
            action.Player2.Dash.performed += DashInput;
        }
    }
    void MyInput()
    {
        if (canDash && currentDashCounter >= 0) //checks if player can dash and the dashcounter is above 0 
        {
            Dash();
        }
        else
        {
            Debug.Log("Dash noch nicht aufgeladen");
        }

    }

    void DashCooldown()
    {
        if (!canDash)
        {
            //float nextDash = Time.time + dashCooldown;
            currentDashCooldown -= Time.deltaTime;
            if (currentDashCooldown <= 0) // check if the cooldown is ending
            {
                Debug.Log("Dash wurde aufgeladen!");
                currentDashCounter = totalDashCounter; // current dashes gets fully charged again
                canDash = true;// if cooldown ended the player can dash again
                currentDashCooldown = dashCooldown;
            }

        }
    }
}
