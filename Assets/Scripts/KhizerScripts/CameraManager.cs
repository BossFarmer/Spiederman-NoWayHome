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
    private PlayerOneScript ploS;
    private bool isCameraFrezeMouse, isCameraFrezeController;



    private void Awake()
    {
        isCameraFrezeMouse = false;
        isCameraFrezeController = false;
        CheckPlayer();
    }

    private void TurnOffFPSCamera(bool obj)
    {
        isCameraFrezeMouse = obj;
    }
    private void TurnOffCameraController(bool cameraOn)
    {
        Debug.Log("camerafrezzecontroller:"+cameraOn);
        isCameraFrezeController = cameraOn;
    }

    private void MouseInputY(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (!isCameraFrezeMouse)
        {
            mouseInputY = obj.ReadValue<float>();
        }
        else
        {
            mouseInputY = 0;
        }
    }

    private void MouseInputX(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (!isCameraFrezeMouse)
        {
            mouseInputX = obj.ReadValue<float>();
        }
        else
        {
            mouseInputX = 0;
        }

    }

    private void ControllerInputY(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (!isCameraFrezeController)
        {
            mouseInputY = obj.ReadValue<float>();
        }
        else
        {
            mouseInputY = 0;
        }
    }

    private void ControllerInputX(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (!isCameraFrezeController)
        {
            mouseInputX = obj.ReadValue<float>();
        }
        else
        {
            mouseInputX = 0;
        }
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
        xRotation -= yDirection;
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
            ploS = transform.parent.GetComponent<PlayerOneScript>();
            ploS.OnDeathTurnOffFPS += TurnOffFPSCamera;
            ploS.OnDeathTurnOffFPSController += TurnOffCameraController;
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
