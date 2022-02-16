using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierScript : MonoBehaviour
{
    public int KillDeathCount;
    //public int killDeathCount2;
    public GameObject Barrier1;//P1Barriere1;
    public GameObject Barrier11;//P2Barriere1;
    public GameObject Barrier2;
    public GameObject Barrier22;
    public GameObject Barrier3;
    public GameObject Barrier33;

    // Start is called before the first frame update
    private void Start()
    {
       
    }

    private void Update()
    {
        SetBarrier();
    }

    public void SetBarrier()
    {
        switch (KillDeathCount)
        {
            case 0:
                if (KillDeathCount == 0)
                {
                    Barrier1.SetActive(true);
                    Barrier11.SetActive(true);
                }
                break;
            case 1:
                if (KillDeathCount == 1)
                {
                    Barrier1.SetActive(false);
                    Barrier2.SetActive(true);
                }
                break;
            case 2:
                if (KillDeathCount == 2)
                {
                    Barrier2.SetActive(false);
                    Barrier3.SetActive(true);
                    Barrier1.SetActive(true);
                }
                break;
            case 3:
                if (KillDeathCount == 3)
                {
                    Barrier3.SetActive(false);
                    Barrier2.SetActive(true);
                }
                break;
            case -1:
                if (KillDeathCount == -1)
                {
                    Barrier11.SetActive(false);
                    Barrier22.SetActive(true);
                }
                break;
            case -2:
                if (KillDeathCount == -2)
                {
                    Barrier22.SetActive(false);
                    Barrier33.SetActive(true);
                }
                break;
            case -3:
                if (KillDeathCount == -3)
                {
                    Barrier33.SetActive(false);
                }
                break;

            default:
                break;
        }
    }
}
