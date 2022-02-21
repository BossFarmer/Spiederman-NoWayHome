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

    [SerializeField] private float powerupRespawnTimer;
    [SerializeField] private float dashForce = 20f;

    public int maxDash = 1;
    public int maxJumps = 2;
    public int currentJump; 
    private float characterSpeed = 12f;
    private float gravity = -9.81f * 2;
    private float jumpHight = 3f;
    private bool isGrounded;
    private Vector3 velocity;
    public Vector3 move;

    private void Start()
    {
        maxJumps = 0;
        currentJump = maxJumps;
    }
    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        GroundChecked();
        CharacterJump();
        
    }

    private void CharacterJump()
    {
        if (Input.GetButtonDown("Jump") &&  currentJump >= 0)
        {
            velocity.y = Mathf.Sqrt(jumpHight * -2 * gravity); //physicalformular for jumping
            currentJump--;
        }
    }

    private void GroundChecked() //Simple Check if player is on the ground and resetting the gravitation
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundCheckRadius, GroundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            currentJump = maxJumps;
        }
    }

    private void PlayerMove() 
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        move = transform.TransformDirection(new Vector3(x, 0f, z)); //local movement by his camera 
        Controller.Move(move * characterSpeed * Time.deltaTime); //moving the player with his characterspeed
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
