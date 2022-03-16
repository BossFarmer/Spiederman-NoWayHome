using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickupScript : MonoBehaviour
{
    [SerializeField]
    private float weaponRespawnTimer;
    public GameObject thisWeapon;
    CharacterMovement characterMovement;

    [SerializeField]
    Collider m_collider;

    [SerializeField]
    MeshRenderer meshRenderer;

    // Start is called before the first frame update
    private void Start()
    {
        m_collider = GetComponent<Collider>();
    }

    public enum EWeapons
    {
        Ak47,
        AutoPump,
        Deagle,
        M16,
        Pistol,
        Pump,
        Sniper,
    }
    public EWeapons WeaponType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            thisWeapon = this.gameObject;
            StartCoroutine("RespawnWeapons");
        }

        if (other.gameObject.tag == "Player2")
        {
            thisWeapon = this.gameObject;
            StartCoroutine("RespawnWeapons");
        }
    }

    IEnumerator RespawnWeapons()
    {
        meshRenderer.enabled = false;
        m_collider.enabled = !m_collider.enabled;
        yield return new WaitForSeconds(2f);
        m_collider.enabled = !m_collider.enabled;
        meshRenderer.enabled = true;
    }
}
