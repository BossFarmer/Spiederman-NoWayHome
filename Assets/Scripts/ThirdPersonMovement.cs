using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController Controller;
    public Transform Cam;
    public float Speed = 6f;
    public float TurnSmoothTime = 0.1f;
    public float TurnSmoothVelocity;

    // Update is called once per frame
    void Update()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(Horizontal,0,Vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg + Cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref TurnSmoothVelocity, TurnSmoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            Vector3 MoveDirection = Quaternion.Euler(0f, targetAngle,0f) * Vector3.forward;
            Controller.Move(MoveDirection.normalized * Speed * Time.deltaTime);
        }
    }
}
