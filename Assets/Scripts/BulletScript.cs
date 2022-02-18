using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private GameObject temp;
    private ConnectWeapon cws;
    private WeapoScript ws;
    private float bulletDamage;
    private float bulletSize;
    private float bulletSpeed;
    private void Awake()
    {
        temp = GameObject.FindGameObjectWithTag("Gun");
        cws = temp.GetComponent<ConnectWeapon>();
        ws = temp.GetComponent<WeapoScript>();
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
        rb.AddForce(ws.spawnPoint.up * bulletSpeed, ForceMode.Impulse);
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
