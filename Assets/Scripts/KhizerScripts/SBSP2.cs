using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBSP2 : MonoBehaviour
{
    private Vector3 dir, dir2;
    private Camera secondCam;
    private Rigidbody rb;
    private bool temp = true;
    private CWSP2 cws;
    private WeapoScript ws;
    void Start()
    {
        GameObject temp = GameObject.FindGameObjectWithTag("Gun2");
        cws = temp.GetComponent<CWSP2>();
        ws = temp.GetComponent<WeapoScript>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (secondCam == null)
        {
            secondCam = GameObject.FindGameObjectWithTag("Player2").transform.Find("SecondCamera").GetComponent<Camera>();
        }
        if (secondCam != null)
        {
            Debug.Log("Cam wurde gefunden");
            dir2 = Quaternion.Euler(Random.Range(-3, 3), Random.Range(-3, 3), 0) * secondCam.transform.forward;
        }
        if (temp)
        {
            RandomShots();
            temp = false;
        }
    }

    private void RandomShots()
    {
        rb.AddForce(dir2 * cws.WBulletSpeed, ForceMode.Impulse);
    }
}
