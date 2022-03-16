using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierScript : MonoBehaviour
{
    static public int P2DeathCount = 0;
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

    [SerializeField]
    public bool PlayerDead;

    [SerializeField]
    public float BarrierSpawnTimer = 3f;

    private void Awake()
    {
        plOneScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerOneScript>();
        plTwoScript = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerTwoScript>();
        plOneScript.OnPlayer1Death += PlayerOneDeathBarrier;
        plTwoScript.OnPlayer2Death += PlayerTwoDeathBarrier;
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

    IEnumerator SwitchBarrierPlayerTwo(int playerDeathCount)
    {
        yield return new WaitForSeconds(CurrTime);

        switch (playerDeathCount)
        {

            case 0:
                if (playerDeathCount == 0)
                {
                    //StartCoroutine("Timer");
                    Barrier1.SetActive(true);
                    Barrier11.SetActive(true);
                }
                break;
            case 1:
                if (playerDeathCount == 1)
                {
                    Barrier1.SetActive(false);
                    //StartCoroutine("Timer");
                    Barrier2.SetActive(true);
                }
                break;
            case 2:
                if (playerDeathCount == 2)
                {
                    Barrier2.SetActive(false);
                    //StartCoroutine("Timer");
                    Barrier3.SetActive(true);
                    Barrier1.SetActive(true);
                }
                break;
            case 3:
                if (playerDeathCount == 3)
                {
                    Barrier3.SetActive(false);
                    //StartCoroutine("Timer");
                    Barrier2.SetActive(true);
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
                    //BarrierTimer();
                    if (CurrTime <= 0)
                    {
                        Barrier22.SetActive(true);
                    }
                }
                break;
            case 2:
                if (playerDeathCount == 2)
                {
                    Barrier22.SetActive(false);
                    //BarrierTimer();
                    Barrier33.SetActive(true);
                    Barrier1.SetActive(true);

                }
                break;
            case 3:
                if (playerDeathCount == 3)
                {
                    Barrier33.SetActive(false);
                    Barrier22.SetActive(true);
                }
                break;
        }
    }

}
