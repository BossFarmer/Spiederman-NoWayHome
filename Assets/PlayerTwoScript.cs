using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerTwoScript : MonoBehaviour
{
    private int healthP2 = 150;
    public int currentHealthP2;
    [SerializeField] private int deathCountPlayer2Barrier;
    [SerializeField] private int deathCountPlayer2Spawn;
    private bool temp = true;
    private PlayerOneScript plOneScript;
    public WeaponPickupScript weaponPickupScript;
    public event Action<int> OnPlayer2DeathBarrier;
    public event Action<int, GameObject> OnPlayer2DeathSpawn;
    public event Action OnPlayer2Killed;
    public int sizeOfList;
    public List<GameObject> Inventar;
    public GameObject PrimaryWeapon;
    public GameObject SekundaryWeapon;

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
        plOneScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerOneScript>();
        plOneScript.OnPlayerOneKilled += PlayerOneKilled;
    }

    private void PlayerOneKilled()
    {
        deathCountPlayer2Spawn--;
        if (deathCountPlayer2Spawn < -2)
        {
            deathCountPlayer2Spawn = -2;
        }

        deathCountPlayer2Barrier--;

        if (deathCountPlayer2Barrier < -2)
        {
            deathCountPlayer2Barrier = -2;
        }


        Debug.Log("spawncount player2 : " + deathCountPlayer2Spawn);
        Inventar = new List<GameObject>(1);

    }

    private void OnPlayerOneKilled()
    {
        deathCountPlayer2Barrier--;
        Debug.Log("Player One was slayed! " + "deathCount of Player 2 "+ deathCountPlayer2Barrier);
    }

    void Start()
    {
        ResetHealth();
        deathCountPlayer2Barrier = 0;
        deathCountPlayer2Spawn = 0;
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
            Debug.Log("PlayerTwo Spawnpoint: " + deathCountPlayer2Barrier);
            deathCountPlayer2Barrier++;
            deathCountPlayer2Spawn++;
            Debug.Log("PlayerTwo Spawnpoint: " + deathCountPlayer2Barrier);
            OnPlayer2DeathBarrier?.Invoke(deathCountPlayer2Barrier);
            OnPlayer2DeathSpawn?.Invoke(deathCountPlayer2Spawn, this.gameObject);
            OnPlayer2Killed?.Invoke();
            Debug.Log("Player 2 was Killed");
            ResetHealth();
        }
    }

    
    public void ResetHealth()
    {
        currentHealthP2 = healthP2;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapons")
        {
            weaponPickupScript = other.GetComponent<WeaponPickupScript>();
            switch (weaponPickupScript.WeaponType)
            {
                case WeaponPickupScript.EWeapons.Ak47:
                    if(Inventar.Count == 0)
                    {
                        PrimaryWeapon = Ak47;
                    }
                    else
                    {
                        SekundaryWeapon = Ak47;
                    }
                    break;
                case WeaponPickupScript.EWeapons.AutoPump:
                    if (Inventar.Count == 0)
                    {
                        PrimaryWeapon = Autopump;
                    }
                    else
                    {
                        SekundaryWeapon = Autopump;
                    }
                    break;
                case WeaponPickupScript.EWeapons.Deagle:
                    if (Inventar.Count == 0)
                    {
                        PrimaryWeapon = Deagle;
                    }
                    else
                    {
                        SekundaryWeapon = Deagle;
                    }
                    break;
                case WeaponPickupScript.EWeapons.M16:
                    if (Inventar.Count == 0)
                    {
                        PrimaryWeapon = M16;
                    }
                    else
                    {
                        SekundaryWeapon = M16;
                    }
                    break;
                case WeaponPickupScript.EWeapons.Pistol:
                    if (Inventar.Count == 0)
                    {
                        PrimaryWeapon = Pistol;
                    }
                    else
                    {
                        SekundaryWeapon = Pistol;
                    }
                    break;
                case WeaponPickupScript.EWeapons.Pump:
                    if (Inventar.Count == 0)
                    {
                        PrimaryWeapon = Pump;
                    }
                    else
                    {
                        SekundaryWeapon = Pump;
                    }
                    break;
                case WeaponPickupScript.EWeapons.Sniper:
                    if (Inventar.Count == 0)
                    {
                        PrimaryWeapon = Sniper;
                    }
                    else
                    {
                        SekundaryWeapon = Sniper;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
