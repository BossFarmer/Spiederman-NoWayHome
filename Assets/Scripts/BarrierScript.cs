using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierScript : MonoBehaviour
{
    //public int killDeathCount2;
    public GameObject Barrier1;//P1Barriere1;
    public GameObject Barrier11;//P2Barriere1;
    public GameObject Barrier2;
    public GameObject Barrier22;
    public GameObject Barrier3;
    public GameObject Barrier33;
    public float CurrTime = 0f;
    private PlayerOneScript plOneScript;
    private PlayerTwoScript plTwoScript;
    public GameObject[] BarrierChecks;
    [SerializeField]
    public bool isPlayerOneBehindeBarrier;
    public bool isPlayerTwoBehindeBarrier;

    [SerializeField]
    public float BarrierSpawnTimer = 3f;

    private void Awake()
    {
        plOneScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerOneScript>();
        plTwoScript = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerTwoScript>();
        plOneScript.OnPlayerOneDeathBarrier += PlayerOneDeathBarrier;
        plTwoScript.OnPlayer2DeathBarrier += PlayerTwoDeathBarrier;

        for (int i = 0; i < BarrierChecks.Length; i++)
        {
            BarrierChecks[i].GetComponent<NextAreaCheck>().RespawnBarrier += RespawnBarrierPlayerOne; ;
            BarrierChecks[i].GetComponent<NextAreaCheck>().RespawnBarrier2 += RespawnBarrierPlayerTwo; ;
        }
    }

    private void RespawnBarrierPlayerTwo(bool obj, int dcp, GameObject that)
    {
        switch (dcp)
        {
            case 2:
                if (dcp == 2)
                {
                    //wenn player erst die nextArea verlassen hat;
                    if (obj)
                    {
                        Barrier33.SetActive(true);
                    }

                }
                break;
            case 1:
                if (dcp == 1)
                {
                    if (obj)
                    {
                        Barrier22.SetActive(true);
                    }

                }
                break;
            case 0:
                if (dcp == 0)
                {
                    if (obj)
                    {
                        Barrier11.SetActive(true);
                    }

                }
                break;
            case -1:
                if (dcp == -1)
                {
                    if (obj)
                    {
                        Barrier1.SetActive(true);
                    }

                }
                break;
            case -2:
                if (dcp == -2)
                {
                    if (obj)
                    {
                        Barrier2.SetActive(true);
                    }

                }
                break;
            default:
                break;
        }
    }

    private void RespawnBarrierPlayerOne(bool obj, int dcp, GameObject that)
    {
        Debug.Log("the Barrier "+that.name);
        switch (dcp)
        {
            case 2:
                if (dcp == 2)
                {
                    //wenn player erst die nextArea verlassen hat;
                    if (obj)
                    {
                        Barrier3.SetActive(true);
                    }

                }
                break;
            case 1:
                if (dcp == 1)
                {
                    if (obj)
                    {
                        Barrier2.SetActive(true);
                    }

                }
                break;
            case 0:
                if (dcp == 0)
                {
                    if (obj)
                    {
                        Barrier1.SetActive(true);
                    }

                }
                break;
            case -1:
                if (dcp == -1)
                {
                    if (obj)
                    {
                        Barrier11.SetActive(true);
                    }

                }
                break;
            //case -2:
            //    if (dcp == -2)
            //    {
            //        if (obj)
            //        {
            //            Barrier22.SetActive(true);
            //        }

            //    }
            //    break;
            default:
                break;
        }
    }

    private void PlayerOneDeathBarrier(int obj)
    {
        StartCoroutine(SwitchBarrierPlayerTwo(obj));
    }
    private void PlayerTwoDeathBarrier(int obj)
    {
        StartCoroutine(SwitchBarrierPlayerOne(obj));
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

    IEnumerator SwitchBarrierPlayerTwo(int playerDeathCountBarrier)
    {
        yield return new WaitForSeconds(CurrTime);

        switch (playerDeathCountBarrier)
        {
            case 1:
                if (playerDeathCountBarrier == 1)
                {
                    Barrier1.SetActive(false);

                }
                break;
            case 2:
                if (playerDeathCountBarrier == 2)
                {
                    Barrier2.SetActive(false);
                }
                break;
            case 3:
                if (playerDeathCountBarrier == 3)
                {
                    Barrier3.SetActive(false);
                }
                break;
        }
    }
    IEnumerator SwitchBarrierPlayerOne(int playerDeathCount)
    {
        Debug.Log(CurrTime);
        yield return new WaitForSeconds(CurrTime);

        switch (playerDeathCount)
        {
            case 1:
                if (playerDeathCount == 1)
                {
                    Barrier11.SetActive(false);
                }
                break;
            case 2:
                if (playerDeathCount == 2)
                {
                    Barrier22.SetActive(false);

                }
                break;
            case 3:
                if (playerDeathCount == 3)
                {
                    Barrier33.SetActive(false);
                }
                break;
        }
    }
}
