using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierScript : MonoBehaviour
{
    public int P1DeathCount;
    public int P2DeathCount;
    //public int killDeathCount2;
    public GameObject Barrier1;//P1Barriere1;
    public GameObject Barrier11;//P2Barriere1;
    public GameObject Barrier2;
    public GameObject Barrier22;
    public GameObject Barrier3;
    public GameObject Barrier33;
    public float CurrTime = 0f;

    [SerializeField]
    public bool PlayerDead;

    [SerializeField]
    public float BarrierSpawnTimer = 3f;

    private void Awake()
    {
        
    }

    private void Start()
    {
        CurrTime = BarrierSpawnTimer;
    }

    private void Update()
    {
        SetBarrier();
    }

    public void SetBarrier()
    {

        //CurrTime = BarrierSpawnTimer;
        //CurrTime -= 1 * Time.deltaTime;

        if (PlayerDead)
        {
            StartCoroutine(Timer());
            #region OldSwitch

            //switch (P2DeathCount)
            //{

            //    case 0:
            //        if (P2DeathCount == 0)
            //        {
            //            StartCoroutine("Timer");
            //            Barrier1.SetActive(true);
            //            Barrier11.SetActive(true);
            //        }
            //        break;
            //    case 1:
            //        if (P2DeathCount == 1)
            //        {
            //            Barrier1.SetActive(false);
            //            StartCoroutine("Timer");
            //            Barrier2.SetActive(true);
            //        }
            //        break;
            //    case 2:
            //        if (P2DeathCount == 2)
            //        {
            //            Barrier2.SetActive(false);
            //            StartCoroutine("Timer");
            //            Barrier3.SetActive(true);
            //            Barrier1.SetActive(true);
            //        }
            //        break;
            //    case 3:
            //        if (P2DeathCount == 3)
            //        {
            //            Barrier3.SetActive(false);
            //            StartCoroutine("Timer");
            //            Barrier2.SetActive(true);
            //        }
            //        break;
            //}

            //switch (P1DeathCount)
            //{
            //    case 1:
            //        if (P1DeathCount == 1)
            //        {
            //            Barrier11.SetActive(false);
            //            //BarrierTimer();
            //            if (CurrTime <= 0)
            //            {
            //                Barrier22.SetActive(true);
            //            }
            //        }
            //        break;
            //    case 2:
            //        if (P1DeathCount == 2)
            //        {
            //            Barrier22.SetActive(false);
            //            //BarrierTimer();
            //            if (CurrTime <= 0)
            //            {
            //                Barrier33.SetActive(true);
            //                Barrier1.SetActive(true);
            //            }
            //        }
            //        break;
            //    case 3:
            //        if (P1DeathCount == 3)
            //        {
            //            Barrier33.SetActive(false);
            //        }
            //        break;
            //}
            #endregion
        }

    }
    #region OldTimer
    //void BarrierTimer()
    //{
    //    CurrTime -= Time.deltaTime;
    //    Debug.Log(CurrTime);

    //    if(CurrTime <= 0)
    //    {
    //        Debug.Log("Timer zu ende");
    //        CurrTime = BarrierSpawnTimer;
    //        return;
    //    }

    //}
    #endregion

    IEnumerator Timer()
    {
        Debug.Log(CurrTime);
        yield return new WaitForSeconds(CurrTime);

        switch (P2DeathCount)
        {

            case 0:
                if (P2DeathCount == 0)
                {
                    //StartCoroutine("Timer");
                    Barrier1.SetActive(true);
                    Barrier11.SetActive(true);
                }
                break;
            case 1:
                if (P2DeathCount == 1)
                {
                    Barrier1.SetActive(false);
                    //StartCoroutine("Timer");
                    Barrier2.SetActive(true);
                }
                break;
            case 2:
                if (P2DeathCount == 2)
                {
                    Barrier2.SetActive(false);
                    //StartCoroutine("Timer");
                    Barrier3.SetActive(true);
                    Barrier1.SetActive(true);
                }
                break;
            case 3:
                if (P2DeathCount == 3)
                {
                    Barrier3.SetActive(false);
                    //StartCoroutine("Timer");
                    Barrier2.SetActive(true);
                }
                break;
        }

        switch (P1DeathCount)
        {
            case 1:
                if (P1DeathCount == 1)
                {
                    Barrier11.SetActive(false);
                    //BarrierTimer();
                    if (CurrTime <= 0)
                    {
                        Barrier22.SetActive(true);
                    }
                }
                break;
            case 2:
                if (P1DeathCount == 2)
                {
                    Barrier22.SetActive(false);
                    //BarrierTimer();
                    Barrier33.SetActive(true);
                    Barrier1.SetActive(true);

                }
                break;
            case 3:
                if (P1DeathCount == 3)
                {
                    Barrier33.SetActive(false);
                    Barrier22.SetActive(true);
                }
                break;
        }
    }

}
