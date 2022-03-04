//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.InputSystem.Controls;

//public class SniperAimScript : MonoBehaviour
//{
//    [SerializeField] private Animator phAnimator;
//    private bool isScoped = false;
//    [SerializeField] private GameObject snipeAim;
//    private MeshRenderer msr;
//    private Camera cam;
//    [SerializeField] private float ScopeZoom = 15f;
//    private float tempFOV;
//    private bool aimInputP1, aimInputP2;
//    // Start is called before the first frame update
//    private void Awake()
//    {
//        CheckPlayer();
//    }

//    private void AimingInput(UnityEngine.InputSystem.InputAction.CallbackContext obj)
//    {
//        var controll = obj.control;
//        var button = controll as ButtonControl;
//        if (transform.root.tag == "Player")
//        {
//            aimInputP1 = button.wasPressedThisFrame;
//        }
//        else if (transform.root.tag == "Player2")
//        {
//            aimInputP2 = button.wasPressedThisFrame;
//            Debug.Log("left trigger was pressed");
//        }

//    }

//    void Start()
//    {
//        GameObject temp = GameObject.FindGameObjectWithTag("PlayerHands");
//        phAnimator = temp.GetComponent<Animator>();
//        msr = GetComponent<MeshRenderer>();
//        cam = Camera.main;
//        tempFOV = cam.fieldOfView;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        SniperAiming();
//        SniperAimingP2();
//    }

//    void SniperAiming()
//    {
//        if (aimInputP1)
//        {
//            isScoped = !isScoped;
//            phAnimator.SetBool("IsScoping", isScoped);
//            aimInputP1 = false;
//        }

//        if (isScoped)
//        {
//            StartCoroutine(SnipeOverlayEnable());
//        }
//        else
//        {
//            SnipeOverlayDisable();
//        }
//    }
//    void SniperAimingP2()
//    {
//        if (aimInputP2)
//        {
//            isScoped = !isScoped;
//            phAnimator.SetBool("IsScoping", isScoped);
//            aimInputP2 = false;
//        }

//        if (isScoped)
//        {
//            StartCoroutine(SnipeOverlayEnable());
//        }
//        else
//        {
//            SnipeOverlayDisable();
//        }
//    }

//    //IEnumerator SnipeOverlayEnable()
//    //{
//    //    yield return new WaitForSeconds(0.15f);

//    //    msr.enabled = false;
//    //    snipeAim.SetActive(true);
//    //    cam.fieldOfView = ScopeZoom;
//    //}
//    //void SnipeOverlayDisable()
//    //{
//    //    snipeAim.SetActive(false);
//    //    msr.enabled = true;
//    //    cam.fieldOfView = tempFOV;
//    //}

//    public void CheckPlayer()
//    {
//        PlayerInputAction action = new PlayerInputAction();
//        if (transform.root.gameObject.tag == "Player")
//        {
//            action.Player.Enable();
//            action.Player.Aiming.performed += AimingInput;
//        }

//        if (transform.root.gameObject.tag == "Player2")
//        {
//            action.Player2.Enable();
//            action.Player2.Aiming.performed += AimingInput;
//        }
//    }
//}
