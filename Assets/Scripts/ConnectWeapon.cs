using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectWeapon : MonoBehaviour
{
    #region enum variables
    private enum Class
    {
        Pistol,
        Shotgun,
        AssaultRifle,
        Sniper
    }
    #endregion
    #region public variables
    public WeaponSCO weapon;
    #endregion
   
    public string WClass;
    public string WName;
    public float WDamage;
    public float WBulletSize;
    public float WBulletSpeed;
    public float WShootDelay;
    public int WMagazineSize;
    public int WIndex;

    void Start()
    {
        weapon.CheckWeaponClass();
        GetWeaponStats();
        Debug.Log("Klasse : " +WClass +" Name: " + WName + " Damage: " + WDamage + " BulletSize: " + WBulletSize + " BulletSpeed: " + WBulletSpeed + " Magazine: " + WMagazineSize + " ShootDelay: "+ WShootDelay);
    }

    void GetWeaponStats()
    {
        WClass = weapon.EWeaponClass.ToString();
        WName = weapon.WeaponName;
        WDamage = weapon.WeaponDamage;
        WMagazineSize = weapon.WeaponMagazineSize;
        WBulletSize = weapon.BulletSize;
        WBulletSpeed = weapon.BulletSpeed;
        WIndex = weapon.IndexWeapon;
        WShootDelay = weapon.WeaponShootDelay;
    }
}