using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController Controller;
    public Transform GroundCheck;
    public float GroundCheckRadius = 0.4f;
    public LayerMask GroundMask;
    public GameObject currPowerUp;

    [SerializeField]
    private float powerupRespawnTimer;

    public int maxDash = 1;
    public int maxJumps = 1;
    private float characterSpeed = 12f;
    private float gravity = -9.81f * 2;
    private float jumpHight = 3f;
    private bool isGrounded;
    private Vector3 velocity;
    
    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        GroundChecked();
        CharacterJump();
    }

    private void CharacterJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded | maxJumps == 2)
        {
            velocity.y = Mathf.Sqrt(jumpHight * -2 * gravity); //physicalformular for jumping
            maxJumps--;
            if (maxJumps < 1)
            {
                maxJumps = 1;
            }
        }
    }

    private void GroundChecked() //Simple Check if player is on the ground and resetting the gravitation
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundCheckRadius, GroundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }

    private void PlayerMove() 
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.TransformDirection(new Vector3(x, 0f, z)); //local movement by his camera 
        Controller.Move(move * characterSpeed * Time.deltaTime); 
        velocity.y += gravity * Time.deltaTime; //increasing the gravit by his velocity 
        Controller.Move(velocity * Time.deltaTime); //applying the velocity
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Items")
        {
            PowerUpScript PowerUp = other.GetComponent<PowerUpScript>();
            switch (PowerUp.PowerUpType)
            {
                case PowerUpScript.EPowerups.plusJump:
                    maxJumps++;
                    maxJumps++;
                    //currPowerUp = other.gameObject;
                    //currPowerUp.SetActive(false);
                    //StartCoroutine("RespawnPowerups");

                    break;
                case PowerUpScript.EPowerups.plusDash:
                    maxDash++;
                    maxDash++;
                    break;
                case PowerUpScript.EPowerups.plusAmmo:
                    //full ammo
                    break;
            }
        }
    }
    //IEnumerator RespawnPowerups()
    //{
    //    yield return new WaitForSeconds(powerupRespawnTimer);
    //    currPowerUp.SetActive(true);
    //}

}
