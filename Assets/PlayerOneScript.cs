using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneScript : MonoBehaviour
{
    private int healthP1 = 150;
    public int currentHealthP1;
    private int deathCountPlayer1Spawn;
    private int deathCountPlayer1Barrierr;
    private PlayerTwoScript plTwoScript;
    public WeaponPickupScript weaponPickupScript;
    public event Action<int> OnPlayerOneDeathBarrier;
    public event Action<int, GameObject> OnPlayer1DeathSpawn;
    public event Action OnPlayerOneKilled;
    public List<GameObject> Inventar;
    public int sizeOfList;
    public GameObject PrimaryWeapon;
    public GameObject SekundaryWeapon;
    public EquipmentScript equipmentScript;

    #region Waffenliste
    public GameObject Pistol;
    public GameObject Ak47;
    public GameObject Autopump;
    public GameObject Deagle;
    public GameObject M16;
    public GameObject Pump;
    public GameObject Sniper;

    #endregion


    void Awake()
    {
        plTwoScript = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerTwoScript>();
        plTwoScript.OnPlayer2Killed += PlayerTwoKilled;
    }

    private void PlayerTwoKilled()
    {
        deathCountPlayer1Spawn--;
        deathCountPlayer1Barrierr--;
        Debug.Log("spawncount player one: " + deathCountPlayer1Spawn);
    }

    void Start()
    {
        ResetHealth();
        deathCountPlayer1Barrierr = 0;
        deathCountPlayer1Spawn = 0;
        Inventar = new List<GameObject>(2);

    }

    void Update()
    {
        IsPlayerDead();
        WaffenInventar();
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
            Debug.Log("PlayerOne Spawnpoint: " + deathCountPlayer1Barrierr);
            deathCountPlayer1Barrierr++;
            deathCountPlayer1Spawn++;
            Debug.Log("PlayerOne Spawnpoint: " + deathCountPlayer1Barrierr);
            OnPlayerOneDeathBarrier?.Invoke(deathCountPlayer1Barrierr);
            OnPlayer1DeathSpawn?.Invoke(deathCountPlayer1Spawn, this.gameObject);
            OnPlayerOneKilled?.Invoke();
            ResetHealth();

        }
    }

    public void WaffenInventar()
    {

    }

    public void ResetHealth()
    {
        currentHealthP1 = healthP1;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (Inventar.Count <=2)
        {

            if (other.gameObject.tag == "Weapons")
            {
                weaponPickupScript = other.GetComponent<WeaponPickupScript>();
                switch (weaponPickupScript.WeaponType)
                {
                    case WeaponPickupScript.EWeapons.Ak47:
                        if (Inventar.Count == 0)
                        {
                            PrimaryWeapon = Ak47;
                            Inventar.Add(PrimaryWeapon);
                            equipmentScript.WaffenZuweisung();
                        }
                        else
                        {
                            SekundaryWeapon = Ak47;
                            Inventar.Add(SekundaryWeapon);
                            equipmentScript.WaffenZuweisung();
                        }
                        break;
                    case WeaponPickupScript.EWeapons.AutoPump:
                        if (Inventar.Count == 0)
                        {
                            PrimaryWeapon = Autopump;
                            Inventar.Add(PrimaryWeapon);
                            equipmentScript.WaffenZuweisung();
                        }
                        else
                        {
                            SekundaryWeapon = Autopump;
                            Inventar.Add(SekundaryWeapon);
                            equipmentScript.WaffenZuweisung();
                        }
                        break;
                    case WeaponPickupScript.EWeapons.Deagle:
                        if (Inventar.Count == 0)
                        {
                            PrimaryWeapon = Deagle;
                            Inventar.Add(PrimaryWeapon);
                            equipmentScript.WaffenZuweisung();
                        }
                        else
                        {
                            SekundaryWeapon = Deagle;
                            Inventar.Add(SekundaryWeapon);
                            equipmentScript.WaffenZuweisung();
                        }
                        break;
                    case WeaponPickupScript.EWeapons.M16:
                        if (Inventar.Count == 0)
                        {
                            PrimaryWeapon = M16;
                            Inventar.Add(PrimaryWeapon);
                            equipmentScript.WaffenZuweisung();
                        }
                        else
                        {
                            SekundaryWeapon = M16;
                            Inventar.Add(SekundaryWeapon);
                            equipmentScript.WaffenZuweisung();
                        }
                        break;
                    case WeaponPickupScript.EWeapons.Pistol:
                        if (Inventar.Count == 0)
                        {
                            PrimaryWeapon = Pistol;
                            Inventar.Add(PrimaryWeapon);
                            equipmentScript.WaffenZuweisung();
                        }
                        else
                        {
                            SekundaryWeapon = Pistol;
                            Inventar.Add(SekundaryWeapon);
                            equipmentScript.WaffenZuweisung();
                        }
                        break;
                    case WeaponPickupScript.EWeapons.Pump:
                        if (Inventar.Count == 0)
                        {
                            PrimaryWeapon = Pump;
                            Inventar.Add(PrimaryWeapon);
                            equipmentScript.WaffenZuweisung();
                        }
                        else
                        {
                            SekundaryWeapon = Pump;
                            Inventar.Add(SekundaryWeapon);
                            equipmentScript.WaffenZuweisung();
                        }
                        break;
                    case WeaponPickupScript.EWeapons.Sniper:
                        if (Inventar.Count == 0)
                        {
                            PrimaryWeapon = Sniper;
                            Inventar.Add(PrimaryWeapon);
                            equipmentScript.WaffenZuweisung();
                        }
                        else
                        {
                            SekundaryWeapon = Sniper;
                            Inventar.Add(SekundaryWeapon);
                            equipmentScript.WaffenZuweisung();
                        }
                        break;
                    default:
                        break;
                }

            }
        }
    }
}
