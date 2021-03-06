using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform playerBody;
    [SerializeField] private Transform playerHands;
    [SerializeField] private float mouseSensitivity = 25f;
    [SerializeField] private float controllerSensitivity = 50f;
    private float xDirection;
    private float yDirection;
    private float mouseInputX;
    private float mouseInputY;
    private float xRotation = 0f;
    public bool isPlayerOne, isPlayerTwo;



    private void Awake()
    {
        CheckPlayer();
    }
    private void MouseInputY(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        mouseInputY = obj.ReadValue<float>();
    }

    private void MouseInputX(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        mouseInputX = obj.ReadValue<float>();
    }

    private void ControllerInputY(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        mouseInputY = obj.ReadValue<float>();
    }

    private void ControllerInputX(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        mouseInputX = obj.ReadValue<float>();
    }

    void Update()
    {
        GetMouseInput();
        MoveCamera();
    }
    void GetMouseInput()
    {
        xDirection = mouseInputX * mouseSensitivity * Time.deltaTime;
        yDirection = mouseInputY * mouseSensitivity * Time.deltaTime;

        Cursor.lockState = CursorLockMode.Locked;
    }
    void MoveCamera()
    {
        playerBody.Rotate(Vector3.up * xDirection);
        xRotation -= yDirection ;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
    private void CheckPlayer()
    {
        PlayerInputAction action = new PlayerInputAction();
        if (transform.parent.tag == "Player")
        {
            action.Player.Enable();
            action.Player.LookingX.performed += MouseInputX;
            action.Player.LookingY.performed += MouseInputY;
            isPlayerOne = true; 
        }

        if (transform.parent.tag == "Player2")
        {
            action.Player2.Enable();
            action.Player2.LookingX.performed += ControllerInputX;
            action.Player2.LookingY.performed += ControllerInputY;
            isPlayerTwo = true;
        }
    }
}
