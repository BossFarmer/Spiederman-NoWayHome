using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneScript : MonoBehaviour
{
    private int healthP1 = 150;
    public static int currentHealthP1;
    public int deathScreem;
    public GameObject Sniper1, Pump1, Pistol1, M161, Deagle1, Autopump1, Ak471;
    // Start is called before the first frame update
    void Start()
    {
        currentHealthP1 = healthP1;
    }

    private void Update()
    {
        IsPlayerDead();
    }
    public void TakeDamagePlayer(int Damage)
    {
        currentHealthP1 -= Damage;
        Debug.Log("Player One health: " + currentHealthP1);
    }

    public void IsPlayerDead()
    {
        if (currentHealthP1 <= 0)
        {
            Debug.Log("Player One was killed!");
            Destroy(this.gameObject, 1f);
            //StartCoroutine;
        }
    }
    //IEnumerator DeathScreenTimer()
    //{
    //yield return new WaitForSeconds(deathScreen);

    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapons")
        {
            WeaponPickupScript Weapon = other.GetComponent<WeaponPickupScript>();
            switch (Weapon.WeaponType)
            {
                case WeaponPickupScript.EWeapons.Ak47:
                    Ak471.SetActive(true);
                    break;
                case WeaponPickupScript.EWeapons.AutoPump:
                    Autopump1.SetActive(true);
                    break;
                case WeaponPickupScript.EWeapons.Deagle:
                    Deagle1.SetActive(true);
                    break;
                case WeaponPickupScript.EWeapons.M16:
                    M161.SetActive(true);
                    break;
                case WeaponPickupScript.EWeapons.Pistol:
                    Pistol1.SetActive(true);
                    break;
                case WeaponPickupScript.EWeapons.Pump:
                    Pump1.SetActive(true);
                    break;
                case WeaponPickupScript.EWeapons.Sniper:
                    Sniper1.SetActive(true);
                    break;
                default:
                    break;
            }
        }
    }

}
