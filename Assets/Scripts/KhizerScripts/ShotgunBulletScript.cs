using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBulletScript : MonoBehaviour
{
    private Vector3 dir, dir2;
    private Camera cam, secondCam;
    private Rigidbody rb;
    private bool temp = true;
    private ConnectWeapon cws;
    private WeapoScript ws;
    void Start()
    {
        GameObject temp = GameObject.FindGameObjectWithTag("Gun");
        cws = temp.GetComponent<ConnectWeapon>();
        ws = temp.GetComponent<WeapoScript>();
        Debug.Log(" ShootgunSCript aufgerufen");
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        dir = Quaternion.Euler(Random.Range(-3,3), Random.Range(-3,3), 0) * cam.transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        if (temp)
        {
            RandomShots();
            temp = false;
        }
    }

    private void RandomShots()
    {
        rb.AddForce(dir * cws.WBulletSpeed, ForceMode.Impulse);
    }
}
