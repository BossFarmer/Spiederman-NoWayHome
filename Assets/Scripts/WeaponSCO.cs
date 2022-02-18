using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Weapon", menuName = "Weapon")]
public class WeaponSCO : ScriptableObject
{
    public enum EweaponClass
    {
        Pistol,
        Shotgun,
        AssaultRifle,
        Sniper
    }

    public EweaponClass EWeaponClass;
    public string WeaponName;
    public float WeaponDamage;
    public int WeaponMagazineSize;
    public float BulletSize;
    public float BulletSpeed;
    public int IndexWeapon;
    public float WeaponShootDelay;

    public void CheckWeaponClass()
    {
        if (EWeaponClass != null) {
            switch (EWeaponClass)
            {
                case EweaponClass.Pistol:
                    {
                        BulletSize = 0.25f;
                        BulletSpeed = 70f;
                        WeaponMagazineSize = 11;
                        WeaponShootDelay = 0.1f;
                    }
                    break;
                case EweaponClass.Shotgun:
                    {
                        BulletSize = 0.7f;
                        BulletSpeed = 50f;
                        WeaponMagazineSize = 5;
                        WeaponShootDelay = 0.5f;
                    }
                    break;
                case EweaponClass.AssaultRifle:
                    {
                        BulletSize = 0.20f;
                        BulletSpeed = 120f;
                        WeaponMagazineSize = 30;
                        WeaponShootDelay = 0.15f;

                    }
                    break;
                case EweaponClass.Sniper:
                    {
                        BulletSize = 0.10f;
                        BulletSpeed = 300f;
                        WeaponMagazineSize = 3;
                        WeaponShootDelay = 1.5f;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
