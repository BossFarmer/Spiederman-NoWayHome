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
    // Start is called before the first frame update
    void Start()
    {
        CurrPlayer1HP = MaxPlayer1HP;
        CurrPlayer2HP = MaxPlayer2HP;
        Stats();
        Areas();
    }

    void Stats()
    {
        HPPlayer1.text = CurrPlayer1HP.ToString();
        HPPlayer2.text = CurrPlayer2HP.ToString();
    }

    void Ammunition()
    {
        //AmmoP1.text =
        //AmmoP2.text =
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
