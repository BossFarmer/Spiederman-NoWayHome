using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform playerBody;
    [SerializeField] private Transform playerHands;
    private float sensitivity = 50f;
    private float xDirection;
    private float yDirection;
    private float mouseInputX;
    private float mouseInputY;
    private float xRotation = 0f;

    private void Awake()
    {
        PlayerInputAction action = new PlayerInputAction();
        action.Player.Enable();
        action.Player.LookingX.performed += MouseInputX;
        action.Player.LookingY.performed += MouseInputY;
    }
    private void Start()
    {
        sensitivity = 50f;
    }
    private void MouseInputY(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        mouseInputY = obj.ReadValue<float>();
    }

    private void MouseInputX(UnityEngine.InputSystem.InputAction.CallbackContext obj)
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
        xDirection = mouseInputX * sensitivity * Time.deltaTime;
        yDirection = mouseInputY * sensitivity * Time.deltaTime;

        Cursor.lockState = CursorLockMode.Locked;
    }
    void MoveCamera()
    {
        playerBody.Rotate(Vector3.up * xDirection);
        xRotation -= yDirection ;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
