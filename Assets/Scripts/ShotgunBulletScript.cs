using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBulletScript : MonoBehaviour
{
    private Vector3 dir;
    private Camera cam;
    private Rigidbody rb;
    private bool temp = true;
    private ConnectWeapon cws;
    void Start()
    {
        GameObject temp = GameObject.FindGameObjectWithTag("Gun");
        cws = temp.GetComponent<ConnectWeapon>();
        Debug.Log("Dieses Script aufgerufen");
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
        Debug.Log("Random wird hinzugefügt");
        rb.AddForce(dir * cws.WBulletSpeed, ForceMode.Impulse);
    }
}
