using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerTwoScript : MonoBehaviour
{
    private int healthP2 = 150;
    public int currentHealthP2;
    public int deathCountPlayer2Barrier;
    public int deathCountPlayer2Spawn;
    private bool temp = true;
    public int sizeOfList;


    private PlayerOneScript plOneScript;
    public WeaponPickupScript weaponPickupScript;
    private Animator bodyAnimator;
    private Transform animationBody;
    private PlayerDeathScript plDeathScript;

    public event Action<int> OnPlayer2DeathBarrier;
    public event Action<int, GameObject> OnPlayer2DeathSpawn;
    public event Action OnPlayer2Killed;
    public event Action <bool> OnDeathTurnOffCamera;

    public List<GameObject> Inventar;
    public GameObject PrimaryWeapon;
    public GameObject SekundaryWeapon;
    public GameObject currentWeapon;

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
        animationBody = transform.GetChild(0);
        bodyAnimator = animationBody.GetComponent<Animator>();
        plDeathScript = animationBody.GetComponent<PlayerDeathScript>();
        plOneScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerOneScript>();
        plOneScript.OnPlayerOneKilled += PlayerOneKilled;
        plDeathScript.OnDeath += PlayerDeath;
    }

    private void PlayerDeath()
    {
        OnDeathAnimation();
    }

    private void PlayerOneKilled()
    {
        deathCountPlayer2Spawn--;
        if (deathCountPlayer2Spawn < -2)
        {
            deathCountPlayer2Spawn = -2;
        }
        else if (deathCountPlayer2Spawn > 3)
        {
            deathCountPlayer2Spawn = 3;
        }

        deathCountPlayer2Barrier--;
        if (deathCountPlayer2Barrier < -2)
        {
            deathCountPlayer2Barrier = -2;
        }
        else if (deathCountPlayer2Barrier > 3)
        {
            deathCountPlayer2Barrier = 3;
        }
    }

    private void OnPlayerOneKilled()
    {
        deathCountPlayer2Spawn--;
        deathCountPlayer2Barrier--;
    }

    void Start()
    {
        ResetHealth();
        deathCountPlayer2Barrier = 0;
        deathCountPlayer2Spawn = 0;
        Inventar = new List<GameObject>(2);
    }

    private void Update()
    {
        IsPlayer2Dead();
    }
    public void TakeDamagePlayer2(int Damage)
    {
        currentHealthP2 -= Damage;
        Debug.Log("Player Two health: " + currentHealthP2);
    }

    public void IsPlayer2Dead()
    {
        if (currentHealthP2 <= 0)
        {
            deathCountPlayer2Barrier++;
            deathCountPlayer2Spawn++;
            bodyAnimator.SetTrigger("triggerDeath2");
            OnDeathTurnOffCamera?.Invoke(true);
            ResetHealth();
        }
    }
     void OnDeathAnimation()
    {
        OnPlayer2DeathBarrier?.Invoke(deathCountPlayer2Barrier);
        OnPlayer2DeathSpawn?.Invoke(deathCountPlayer2Spawn, this.gameObject);
        OnPlayer2Killed?.Invoke();
    }

    public void ResetHealth()
    {
        currentHealthP2 = healthP2;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapons")
        {
            if (Inventar.Count <= 2)
            {
                if (PrimaryWeapon == null)
                {
                    currentWeapon = other.gameObject;
                    AttachWeapon(currentWeapon);
                }
                if (SekundaryWeapon == null && PrimaryWeapon.name != other.gameObject.name)
                {
                    currentWeapon = other.gameObject;
                    AttachWeapon(currentWeapon);
                }
            }
        }
    }

    private void AttachWeapon(GameObject currWea)
    {
        weaponPickupScript = currWea.GetComponent<WeaponPickupScript>();
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
                    case 2:
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
                    case 2:
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
                    case 2:
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
                    case 2:
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
                    case 2:
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
                    case 2:
                        break;
                }
                break;
            default:
                break;
        }


    }
}
