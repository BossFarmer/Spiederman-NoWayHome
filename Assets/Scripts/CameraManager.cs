using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform playerBody;
    [SerializeField] private Transform playerHands;
    private float sensitivity = 175f;
    private float xDirection;
    private float yDirection;
    private float xRotation = 0f;
    void Update()
    {
        GetMouseInput();
        MoveCamera();
    }
    void GetMouseInput()
    {
        xDirection = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        yDirection = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

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
