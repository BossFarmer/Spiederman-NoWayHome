using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController Controller;
    public Transform GroundCheck;
    public float GroundCheckRadius = 0.4f;
    public LayerMask GroundMask;
    public GameObject currPowerUp;
    public Vector3 move;

    [SerializeField] private float powerupRespawnTimer;
    [SerializeField] private float dashForce = 20f;
    [SerializeField] private PlayerInput playerInput;

    public int maxDash = 1;
    public int maxJumps = 2;
    public int currentJump;
    private Vector2 inputMovement;
    private bool inputJump;
    private float characterSpeed = 12f;
    private float gravity = -9.81f * 2;
    private float jumpHight = 3f;
    private bool isGrounded;
    private Vector3 velocity;

    private void Awake()
    {
        PlayerInputAction action = new PlayerInputAction();
        action.Player.Enable();
        action.Player.Movement.performed += MovePlayer;
        action.Player.Jump.performed += JumpInput;
    }

    private void JumpInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            CharacterJump();
        }
        //inputJump = context.ReadValueAsButton();
        //Debug.Log(inputJump);
    }

    private void MovePlayer(InputAction.CallbackContext context)
    {
        inputMovement = context.ReadValue<Vector2>();
    }

    private void Start()
    {
        maxJumps = 1;
        currentJump = maxJumps;
    }
    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        GroundChecked();
        //CharacterJump();

    }

    private void CharacterJump()
    {
        if (currentJump >= 0)
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

    public void PlayerMove()
    {
        float x = inputMovement.x; //Input.GetAxis("Horizontal");
        float z = inputMovement.y; //Input.GetAxis("Vertical");

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
