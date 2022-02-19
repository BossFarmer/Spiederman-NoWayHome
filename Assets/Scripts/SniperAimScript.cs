using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperAimScript : MonoBehaviour
{
    [SerializeField] private Animator phAnimator;
    private bool isScoped = false;
    [SerializeField] private GameObject snipeAim;
    private MeshRenderer msr;
    private Camera cam;
    [SerializeField] private float ScopeZoom = 15f;
    private float tempFOV;
    // Start is called before the first frame update
    void Start()
    {
        GameObject temp = GameObject.FindGameObjectWithTag("PlayerHands");
        phAnimator = temp.GetComponent<Animator>();
        msr = GetComponent<MeshRenderer>();
        cam = Camera.main;
        tempFOV = cam.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        SniperAiming();
    }

    void SniperAiming()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            isScoped = !isScoped;
            phAnimator.SetBool("IsScoping", isScoped);
        }

        if (isScoped)
        {
            StartCoroutine(SnipeOverlayEnable());
        }
        else
        {
            SnipeOverlayDisable();
        }
    }

    IEnumerator SnipeOverlayEnable()
    {
        yield return new WaitForSeconds(0.15f);

        msr.enabled = false;
        snipeAim.SetActive(true);
        cam.fieldOfView = ScopeZoom;
    }
    void SnipeOverlayDisable()
    {
        snipeAim.SetActive(false);
        msr.enabled = true;
        cam.fieldOfView = tempFOV;
    }
}
