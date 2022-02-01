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
    #region private Variables
    public string wClass;
    public string wName;
    public float wDamage;
    public float wBulletSize;
    public float wBulletSpeed;
    public int wMagazineSize;
    #endregion

    void Start()
    {
        weapon.CheckWeaponClass();
        GetWeaponStats();
        Debug.Log("Klasse : " +wClass +" Name: " + wName + " Damage: " + wDamage + " BulletSize: " + wBulletSize + " BulletSpeed: " + wBulletSpeed + " Magazine: " + wMagazineSize);
    }

    void GetWeaponStats()
    {
        wClass = weapon.eWeaponClass.ToString();
        wName = weapon.weaponName;
        wDamage = weapon.weaponDamage;
        wMagazineSize = weapon.weaponMagazineSize;
        wBulletSize = weapon.bulletSize;
        wBulletSpeed = weapon.bulletSpeed;
    }
}
