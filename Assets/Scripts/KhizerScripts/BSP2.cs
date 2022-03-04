using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSP2 : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject temp;
    private CWSP2 cws;
    private WeapoScript ws;
    private float bulletDamage;
    private float bulletSize;
    private float bulletSpeed;
    private Camera cam, secondCam;
    private bool tempBool1;
    private void Awake()
    {
        temp = GameObject.FindGameObjectWithTag("Gun2");
        cws = temp.GetComponent<CWSP2>();
        ws = temp.GetComponent<WeapoScript>();
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
    }
    void Start()
    {
        GetWeaponData();
        TransformBulletSize();
        tempBool1 = true;
    }
    private void Update()
    {
        if (secondCam == null)
        {
            secondCam = GameObject.FindGameObjectWithTag("SecondCamera").GetComponent<Camera>();
        }

        if (tempBool1)
        {
            AccelerateBullet();
            tempBool1 = false;
        }
    }
    private void TransformBulletSize()
    {
        Vector3 bulletScale = new Vector3(bulletSize, bulletSize, bulletSize);
        transform.localScale = bulletScale;
    }

    public void AccelerateBullet()
    {
        rb.AddForce(secondCam.transform.forward * bulletSpeed, ForceMode.Impulse);
    }
    private void GetWeaponData()
    {
        if (cws != null)
        {
            bulletDamage = cws.WDamage;
            bulletSize = cws.WBulletSize;
            bulletSpeed = cws.WBulletSpeed;
        }
        else
        {
            Debug.Log("Script nicht gefunden!");
        }
    }
}
