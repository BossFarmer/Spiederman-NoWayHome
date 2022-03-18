using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneScript : MonoBehaviour
{
    private int healthP1 = 150;
    public int currentHealthP1;
    public int deathCountPlayer1Spawn;
    public int deathCountPlayer1Barrierr;
    private PlayerTwoScript plTwoScript;
    private Transform animationBody;
    private Animator bodyAnimator;
    public WeaponPickupScript weaponPickupScript;

    public event Action<int> OnPlayerOneDeathBarrier;
    public event Action<int, GameObject> OnPlayer1DeathSpawn;
    public event Action OnPlayerOneKilled;
    public event Action<bool> OnDeathTurnOffFPS;
    public GameObject currentWeapon;

    public List<GameObject> Inventar;
    public int sizeOfList;
    public GameObject PrimaryWeapon;
    public GameObject SekundaryWeapon;
    public EquipmentScript equipmentScript;
    private PlayerDeathScript plDeathScript;

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
        GetAnimationBody();
        bodyAnimator = animationBody.GetComponent<Animator>();
        plDeathScript = animationBody.GetComponent<PlayerDeathScript>();
        plDeathScript.OnDeath += OnPlayerOneDeath;
        plTwoScript = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerTwoScript>();
        plTwoScript.OnPlayer2Killed += PlayerTwoKilled;
    }

    private void OnPlayerOneDeath()
    {
        OnDeathAnimation();
    }

    private void PlayerTwoKilled()
    {
        deathCountPlayer1Spawn--;

        if (deathCountPlayer1Spawn < -2)
        {
            deathCountPlayer1Spawn = -2;
        }else if(deathCountPlayer1Spawn > 3)
        {
            deathCountPlayer1Spawn = 3;
        }

        deathCountPlayer1Barrierr--;

        if (deathCountPlayer1Barrierr < -2)
        {
            deathCountPlayer1Barrierr = -2;
        }
        else if (deathCountPlayer1Barrierr > 3)
        {
            deathCountPlayer1Barrierr = 3;
        }
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
    private void GetAnimationBody()
    {
        animationBody = transform.GetChild(0);
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
            bodyAnimator.SetTrigger("triggerDeath");
            OnDeathTurnOffFPS.Invoke(true);
            ResetHealth();

        }
    }

    public void OnDeathAnimation()
    {
        OnPlayerOneDeathBarrier?.Invoke(deathCountPlayer1Barrierr);
        OnPlayer1DeathSpawn?.Invoke(deathCountPlayer1Spawn, this.gameObject);
        OnPlayerOneKilled?.Invoke();
        OnDeathTurnOffFPS?.Invoke(false);
        bodyAnimator.SetBool("isDeath", false);
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
        if (other.gameObject.tag == "Weapons")
        {
            if (Inventar.Count <= 2)
            {
                Debug.Log("Moin");
                if (PrimaryWeapon == null)
                {
                    currentWeapon = other.gameObject;
                    AttachWeapon();
                    Debug.Log(other.gameObject.name);
                }
                Debug.Log(PrimaryWeapon.name + other.gameObject.name);
                if (SekundaryWeapon == null && PrimaryWeapon.name != other.gameObject.name)
                {
                    currentWeapon = other.gameObject;
                    AttachWeapon();
                    //Debug.Log(other.gameObject.name);
                }

            }

        }
    }

    private void AttachWeapon()
    {
        if (currentWeapon.gameObject.tag == "Weapons")
        {
            weaponPickupScript = currentWeapon.GetComponent<WeaponPickupScript>();
            switch (weaponPickupScript.WeaponType)
            {
                case WeaponPickupScript.EWeapons.Ak47:

                    switch (Inventar.Count)
                    {
                        case 0:
                            PrimaryWeapon = Ak47;
                            Inventar.Add(PrimaryWeapon);
                            break;
                        case 1:
                            SekundaryWeapon = Ak47;
                            Inventar.Add(SekundaryWeapon);
                            break;
                    }
                    break;
                case WeaponPickupScript.EWeapons.AutoPump:
                    switch (Inventar.Count)
                    {
                        case 0:
                            PrimaryWeapon = Autopump;
                            Inventar.Add(PrimaryWeapon);
                            break;
                        case 1:
                            SekundaryWeapon = Autopump;
                            Inventar.Add(SekundaryWeapon);
                            break;
                    }
                    break;
                case WeaponPickupScript.EWeapons.Deagle:
                    switch (Inventar.Count)
                    {
                        case 0:
                            PrimaryWeapon = Deagle;
                            Inventar.Add(PrimaryWeapon);
                            break;
                        case 1:
                            SekundaryWeapon = Deagle;
                            Inventar.Add(SekundaryWeapon);
                            break;
                    }
                    break;
                case WeaponPickupScript.EWeapons.M16:
                    switch (Inventar.Count)
                    {
                        case 0:
                            PrimaryWeapon = M16;
                            Inventar.Add(PrimaryWeapon);
                            break;
                        case 1:
                            SekundaryWeapon = M16;
                            Inventar.Add(SekundaryWeapon);
                            break;
                    }
                    break;
                case WeaponPickupScript.EWeapons.Pistol:
                    switch (Inventar.Count)
                    {
                        case 0:
                            PrimaryWeapon = Pistol;
                            Inventar.Add(PrimaryWeapon);
                            break;
                        case 1:
                            SekundaryWeapon = Pistol;
                            Inventar.Add(SekundaryWeapon);
                            break;
                    }
                    break;
                case WeaponPickupScript.EWeapons.Pump:
                    switch (Inventar.Count)
                    {
                        case 0:
                            PrimaryWeapon = Pump;
                            Inventar.Add(PrimaryWeapon);
                            break;
                        case 1:
                            SekundaryWeapon = Pump;
                            Inventar.Add(SekundaryWeapon);
                            break;
                    }
                    break;
                case WeaponPickupScript.EWeapons.Sniper:
                    switch (Inventar.Count)
                    {
                        case 0:
                            PrimaryWeapon = Sniper;
                            Inventar.Add(PrimaryWeapon);
                            break;
                        case 1:
                            SekundaryWeapon = Sniper;
                            Inventar.Add(SekundaryWeapon);
                            break;
                    }
                    break;
                default:
                    break;
            }

        }
    }
}
