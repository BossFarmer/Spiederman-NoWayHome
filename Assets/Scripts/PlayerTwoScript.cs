using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoScript : MonoBehaviour
{
    private int healthP2 = 150;
    public static int currentHealthP2;
    public GameObject DeatScreenP2;
    [SerializeField]
    public int deathScreen;

    public GameObject Sniper2, Pump2, Pistol2, M162, Deagle2, Autopump2, Ak472;

    // Start is called before the first frame update
    void Start()
    {
        currentHealthP2 = healthP2;
    }

    private void Update()
    {
        IsPlayer2Dead();
    }
    public void TakeDamagePlayer2(int Damage)
    {
        currentHealthP2 -= Damage;
        Debug.Log("Player Two health: "+currentHealthP2);
    }

    public void IsPlayer2Dead()
    {
        if (currentHealthP2 <= 0)
        {
            Debug.Log("Player 2 was Killed");
            Destroy(this.gameObject, 1f);
            DeatScreenP2.SetActive(true);
            StartCoroutine("DeathScreenTimer");

        }

    }
    IEnumerator DeathScreenTimer()
    {
        yield return new WaitForSeconds(deathScreen);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapons")
        {
            WeaponPickupScript Weapon = other.GetComponent<WeaponPickupScript>();
            switch (Weapon.WeaponType)
            {
                case WeaponPickupScript.EWeapons.Ak47:
                    Ak472.SetActive(true);
                    break;
                case WeaponPickupScript.EWeapons.AutoPump:
                    Autopump2.SetActive(true);
                    break;
                case WeaponPickupScript.EWeapons.Deagle:
                    Deagle2.SetActive(true);
                    break;
                case WeaponPickupScript.EWeapons.M16:
                    M162.SetActive(true);
                    break;
                case WeaponPickupScript.EWeapons.Pistol:
                    Pistol2.SetActive(true);
                    break;
                case WeaponPickupScript.EWeapons.Pump:
                    Pump2.SetActive(true);
                    break;
                case WeaponPickupScript.EWeapons.Sniper:
                    Sniper2.SetActive(true);
                    break;
                default:
                    break;
            }
        }
    }

}
