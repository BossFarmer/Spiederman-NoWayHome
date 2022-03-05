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
        SemiAssaultRifle,
        Sniper,
        Speical,
        AutoShotgun
    }

    public EweaponClass EWeaponClass;
    public string WeaponName;
    public int BulletDamage;
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
                        WeaponShootDelay = 0.3f;
                        BulletDamage = 20;
                    }
                    break;
                case EweaponClass.Shotgun:
                    {
                        BulletSize = 0.5f;
                        BulletSpeed = 50f;
                        WeaponMagazineSize = 5;
                        WeaponShootDelay = 0.8f;
                        BulletDamage = 45;
                    }
                    break;
                case EweaponClass.AssaultRifle:
                    {
                        BulletSize = 0.20f;
                        BulletSpeed = 120f;
                        WeaponMagazineSize = 30;
                        WeaponShootDelay = 0.28f;
                        BulletDamage = 28;

                    }
                    break;
                case EweaponClass.Sniper:
                    {
                        BulletSize = 0.10f;
                        BulletSpeed = 190f;
                        WeaponMagazineSize = 2;
                        WeaponShootDelay = 1.5f;
                        BulletDamage = 90;
                    }
                    break;
                case EweaponClass.Speical:
                    {
                        BulletSize = 0.10f;
                        BulletSpeed = 300f;
                        WeaponMagazineSize = 1;
                        WeaponShootDelay = 1.5f;
                        BulletDamage = 300;
                    }
                    break;
                case EweaponClass.AutoShotgun:
                    {
                        BulletSize = 0.5f;
                        BulletSpeed = 50f;
                        WeaponMagazineSize = 5;
                        WeaponShootDelay = 0.4f;
                        BulletDamage = 30;
                    }
                    break;
                case EweaponClass.SemiAssaultRifle:
                    {
                        BulletSize = 0.20f;
                        BulletSpeed = 120f;
                        WeaponMagazineSize = 30;
                        WeaponShootDelay = 0.18f;
                        BulletDamage = 21;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
