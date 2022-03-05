using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject temp;
    private ConnectWeapon cws;
    private WeapoScript ws;
    private int bulletDamage;
    private float bulletSize;
    private float bulletSpeed;
    private Camera cam;
    [SerializeField] private LayerMask targetMask; 
    private void Awake()
    {
        temp = GameObject.FindGameObjectWithTag("Gun");
        cws = temp.GetComponent<ConnectWeapon>();
        ws = temp.GetComponent<WeapoScript>();
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
    }
    void Start()
    {
        GetWeaponData();
        TransformBulletSize();
        AccelerateBullet();
    }
    private void TransformBulletSize()
    {
        Vector3 bulletScale = new Vector3(bulletSize, bulletSize, bulletSize);
        transform.localScale = bulletScale;
    }

    public void AccelerateBullet()
    {
        rb.AddForce(cam.transform.forward * bulletSpeed , ForceMode.Impulse);
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player2")
        {
            PlayerTwoScript target = collision.transform.root.GetComponent<PlayerTwoScript>();
            if (target != null)
            {
                target.TakeDamagePlayer2(bulletDamage);
            }
        }
        Destroy(this.gameObject);
    }

}
