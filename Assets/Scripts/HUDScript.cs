using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour
{
    public BarrierScript barrierScript;

    public static int MaxPlayer2HP = 150, MaxPlayer1HP = 150;
    public static int CurrPlayer2HP, CurrPlayer1HP;
    public Text HPPlayer1;
    public Text HPPlayer2;
    public Text Area;
    public Text AmmoP1;
    public Text AmmoP2;
    //public WeapoScript weapoScript;
    public ConnectWeapon connectWeapon;
    public CWSP2 cwsp2;
    public GameObject ph1;
    public GameObject ph2;
    public GameObject activeWeapon;
    public WeapoScript weapoScript;
    public GameObject ActiveWeaponP2;
    public GameObject ActiveWeaponP1;
    public int P1Mag;
    public int P2Mag;
    public int currMagSizeP1;
    public int currMagSizeP2;
    // Start is called before the first frame update
    void Start()
    {
        CurrPlayer1HP = MaxPlayer1HP;
        CurrPlayer2HP = MaxPlayer2HP;
        Stats();
        Areas();
    }

    void Update()
    {
        Areas();
        CurrentWeapon();
        Ammunition();
    }

    void CurrentWeapon()
    {
        GameObject ph1 = null;
        var Player1 = GameObject.FindGameObjectWithTag("Player");
        if(Player1 != null)
        foreach (Transform child in Player1.transform)
        {
            if (child.gameObject.tag == "MainCamera")
            {
                var cam = child.gameObject;
                foreach (Transform child2 in cam.transform)
                {
                    if (child2.gameObject.tag == "PlayerHands")
                    {
                        ph1 = child2.gameObject;
                    }
                }
            }
        }
        var Player2 = GameObject.FindGameObjectWithTag("Player2");
        GameObject ph2 = null;
        if(Player2 != null)
        foreach (Transform child in Player2.transform)
        {
            if (child.gameObject.tag == "SecondCamera")
            {
                var cam = child.gameObject;
                foreach (Transform child2 in cam.transform)
                {
                    if (child2.gameObject.tag == "PlayerHands2")
                    {
                        ph2 = child2.gameObject;
                    }
                }
            }
        }
        if (ph2 != null)
            for (int i = 0; i < ph2.transform.childCount; i++)
            {
                if (ph2.transform.GetChild(i).gameObject.activeSelf == true)
                {
                    ActiveWeaponP2 = ph2.transform.GetChild(i).gameObject;
                    P2Mag = ActiveWeaponP2.GetComponent<WeapoScript>().currenMagP2;
                    //currMagSizeP2 = ActiveWeaponP2.GetComponent<CWSP2>().WMagazineSize;
                }
            }
        if (ph1 != null)
            for (int i = 0; i < ph1.transform.childCount; i++)
            {
                if (ph1.transform.GetChild(i).gameObject.activeSelf == true)
                {
                    ActiveWeaponP1 = ph1.transform.GetChild(i).gameObject;
                    P1Mag = ActiveWeaponP1.GetComponent<WeapoScript>().currenMag;
                    //currMagSizeP1 = ActiveWeaponP1.GetComponent<ConnectWeapon>().WMagazineSize;
                }
            }
    }

    public void Reload()
    {
        //P1Mag = currMagSizeP1;
        //P2Mag = currMagSizeP2;
    }

    void Stats()
    {
        HPPlayer1.text = CurrPlayer1HP.ToString();
        HPPlayer2.text = CurrPlayer2HP.ToString();
    }

    void Ammunition()
    {
        AmmoP1.text = P1Mag.ToString();
        AmmoP2.text = P2Mag.ToString();
    }

    void Areas()
    {
        //switch (BarrierScript.deathCount)
        //{
        //    case 0:
        //        Area.text = "Area 0";
        //        break;
        //    case 1:
        //        Area.text = "P1 Area 1";
        //        break;
        //    case 2:
        //        Area.text = "P1 Area2";
        //        break;
        //    case 3:
        //        Area.text = "P1 Last Area!";
        //        break;
        //}

        //switch (BarrierScript.P2DeathCount)
        //{
        //    case 0:
        //        Area.text = "Area 0";
        //        break;
        //    case 1:
        //        Area.text = "P2 Area 1";
        //        break;
        //    case 2:
        //        Area.text = "P2 Area2";
        //        break;
        //    case 3:
        //        Area.text = "P2 Last Area!";
        //        break;
        //}
    }
}
