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
    public GameObject currentWeaponP1;
    public GameObject currentWeaponP2;
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
        Stats();
    }

    void CurrentWeapon()
    {
        currentWeaponP1 = GameObject.Find("OriP1/Main Camera/PlayerHands/");
        currentWeaponP2 = GameObject.Find("OriP2/SecondCamera/PlayerHands2/");

        for (int i = 0; i < currentWeaponP2.transform.childCount; i++)
        {
            if (currentWeaponP2.transform.GetChild(i).gameObject.activeSelf == true)
            {
                ActiveWeaponP2 = currentWeaponP2.transform.GetChild(i).gameObject;
                P2Mag = ActiveWeaponP2.GetComponent<WeapoScript>().currenMagP2;
                currMagSizeP2 = ActiveWeaponP2.GetComponent<CWSP2>().WMagazineSize;
            }
        }

        for (int i = 0; i < currentWeaponP1.transform.childCount; i++)
        {
            if (currentWeaponP1.transform.GetChild(i).gameObject.activeSelf == true)
            {
                ActiveWeaponP1 = currentWeaponP1.transform.GetChild(i).gameObject;
                P1Mag = ActiveWeaponP1.GetComponent<WeapoScript>().currenMag;
                currMagSizeP1 = ActiveWeaponP1.GetComponent<ConnectWeapon>().WMagazineSize;
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
        HPPlayer1.text = PlayerOneScript.currentHealthP1.ToString();
        HPPlayer2.text = PlayerTwoScript.currentHealthP2.ToString();
    }

    void Ammunition()
    {
        AmmoP1.text = P1Mag.ToString();
        AmmoP2.text = P2Mag.ToString();
    }

    void Areas()
    {
        switch (barrierScript.P1DeathCount)
        {
            case 0:
                Area.text = "Area 0";
                break;
            case 1:
                Area.text = "P1 Area 1";
                break;
            case 2:
                Area.text = "P1 Area2";
                break;
            case 3:
                Area.text = "P1 Last Area!";
                break;
        }

        switch (barrierScript.P2DeathCount)
        {
            case 0:
                Area.text = "Area 0";
                break;
            case 1:
                Area.text = "P2 Area 1";
                break;
            case 2:
                Area.text = "P2 Area2";
                break;
            case 3:
                Area.text = "P2 Last Area!";
                break;
        }
    }
}
