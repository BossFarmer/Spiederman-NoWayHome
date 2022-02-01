using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private GameObject temp;
    private ConnectWeapon cws;
    private float bulletDamage;
    private float bulletSize;
    private float bulletSpeed;
    private void Awake()
    {
        temp = GameObject.FindGameObjectWithTag("Gun");
        cws = temp.GetComponent<ConnectWeapon>();
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        GetWeaponData();
        TransformBulletSize();
        AccelerateBullet();
    }

    private void TransformBulletSize()
    {
        Vector3 bulletScale = new Vector3(bulletSize,bulletSize,bulletSize);
        transform.localScale = bulletScale;
    }

    private void AccelerateBullet()
    {
        rb.AddForce(-temp.transform.up * bulletSpeed, ForceMode.Impulse);
    }
    private void GetWeaponData()
    {
        if (cws != null)
        {
            bulletDamage = cws.wDamage;
            bulletSize = cws.wBulletSize;
            bulletSpeed = cws.wBulletSpeed;
        }
        else
        {
            Debug.Log("Script nicht gefunden!");
        }
    }
}
