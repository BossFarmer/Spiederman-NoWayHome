using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController Controller;
    public HUDScript hudScript;
    public DashScript dashScript;
    public Transform GroundCheck;
    public float GroundCheckRadius = 0.4f;
    public LayerMask GroundMask;
    public GameObject currPowerUp;
    public Vector3 move;
    public Animator animator;

    [SerializeField] private float powerupRespawnTimer;
    [SerializeField] private float dashForce = 20f;
    [SerializeField] private PlayerInput playerInput;

    public int maxDash = 1;
    public int maxJumps = 1;
    public int currentJump;
    private Vector2 inputMovement;
    private bool inputJump;
    private float characterSpeed = 12f;
    private float gravity = -9.81f * 2;
    private float jumpHight = 3f;
    private bool isGrounded;
    private Vector3 velocity;
    public bool spaceInput;
    public float jumpTimer;


    private void Awake()
    {
        CheckPlayer();
    }

    private void JumpInput(InputAction.CallbackContext context)
    {
        if (context.performed && spaceInput == false)
        {
            spaceInput = true;
            animator.SetBool("isJump", true);
            CharacterJump();
            StartCoroutine("JumpTimer");
        }
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
    }

    private void CharacterJump()
    {
        if (currentJump > 0)
        {
            velocity.y = Mathf.Sqrt(jumpHight * -2 * gravity); //physicalformular for jumping
            Debug.Log(velocity.y);
            currentJump--;
        }
    }

    private void GroundChecked() //Simple Check if player is on the ground and resetting the gravitation
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundCheckRadius, GroundMask);

        if (isGrounded && velocity.y < 0)
        {
            spaceInput = false;
            velocity.y = -2f;
            animator.SetBool("isJump", false);
            if (maxJumps >= 2)
            {
                maxJumps = 2;
                if (currentJump == 0)
                    maxJumps--;
                currentJump = maxJumps;
            }
            else
            {
                currentJump = maxJumps;
            }

        }

        //if (currentJump == 0 && isGrounded)
        //{
        //    currentJump = maxJumps;
        //}

        //if (isGrounded && currentJump == 1)
        //{
        //    currentJump++;
        //}
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


    public void CheckPlayer()
    {
        PlayerInputAction action = new PlayerInputAction();
        if (this.gameObject.tag == "Player")
        {
            action.Player.Enable();
            action.Player.Movement.performed += MovePlayer;
            action.Player.Jump.performed += JumpInput;
            Debug.Log("is Player One Ready: " );
        }

        if (this.gameObject.tag == "Player2")
        {
            action.Player2.Enable();
            action.Player2.Movement.performed += MovePlayer;
            action.Player2.Jump.performed += JumpInput;
            Debug.Log("is Player Two Ready: ");
        }
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
                    //currPowerUp = other.gameObject;
                    //currPowerUp.SetActive(false);
                    //StartCoroutine("RespawnPowerups");
                    break;
                case PowerUpScript.EPowerups.plusDash:
                    DashScript.currentDashCounter++;
                    break;
                case PowerUpScript.EPowerups.plusAmmo:
                    //full ammo
                    break;
                case PowerUpScript.EPowerups.plusHealth:
                    if (this.gameObject.tag == "Player1")
                    {
                        HUDScript.CurrPlayer1HP += 50;
                        if (HUDScript.CurrPlayer1HP < 150)
                            HUDScript.CurrPlayer1HP = HUDScript.MaxPlayer1HP;
                    }
                    if (this.gameObject.tag == "Player2")
                    {
                        HUDScript.CurrPlayer2HP += 50;
                        if (HUDScript.CurrPlayer2HP < 150)
                            HUDScript.CurrPlayer2HP = HUDScript.MaxPlayer2HP;
                    }
                    break;
            }
        }
    }

    IEnumerator JumpTimer()
    {
        yield return new WaitForSeconds(jumpTimer);
        spaceInput = false;
    }
    //IEnumerator RespawnPowerups()
    //{
    //    yield return new WaitForSeconds(powerupRespawnTimer);
    //    currPowerUp.SetActive(true);
    //}
}
