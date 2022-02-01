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

    public EweaponClass eWeaponClass;
    public string weaponName;
    public float weaponDamage;
    public int weaponMagazineSize;
    public float bulletSize;
    public float bulletSpeed;

    public void CheckWeaponClass()
    {
        if (eWeaponClass != null) {
            switch (eWeaponClass)
            {
                case EweaponClass.Pistol:
                    {
                        bulletSize = 0.25f;
                        bulletSpeed = 70f;
                        weaponMagazineSize = 11;
                    }
                    break;
                case EweaponClass.Shotgun:
                    {
                        bulletSize = 0.7f;
                        bulletSpeed = 50f;
                        weaponMagazineSize = 5;
                    }
                    break;
                case EweaponClass.AssaultRifle:
                    {
                        bulletSize = 0.20f;
                        bulletSpeed = 120f;
                        weaponMagazineSize = 30;
                    }
                    break;
                case EweaponClass.Sniper:
                    {
                        bulletSize = 0.10f;
                        bulletSpeed = 300f;
                        weaponMagazineSize = 3;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
