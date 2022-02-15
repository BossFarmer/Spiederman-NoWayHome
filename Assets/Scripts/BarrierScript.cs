using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierScript : MonoBehaviour
{
    public int killDeathCount;
    public GameObject Barrier1;
    public GameObject Barrier11;
    public GameObject Barrier2;
    public GameObject Barrier22;
    public GameObject Barrier3;
    public GameObject Barrier33;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void Update()
    {
        SetBarrier();

        void SetBarrier()
        {
            switch (killDeathCount)
            {
                case 0:
                    if (killDeathCount == 0)
                    {
                        Barrier1.SetActive(true);
                        Barrier11.SetActive(true);
                    }
                    break;
                case 1:
                    if (killDeathCount == 1)
                    {
                        Barrier1.SetActive(false);
                        Barrier2.SetActive(true);
                    }
                    break;
                case 2:
                    if (killDeathCount == 2)
                    {
                        Barrier2.SetActive(false);
                        Barrier3.SetActive(true);
                        Barrier1.SetActive(true);
                    }
                    break;
                case 3:
                    if (killDeathCount == 3)
                    {
                        Barrier3.SetActive(false);
                        Barrier2.SetActive(true);
                    }
                    break;
                case 4:
                    if (killDeathCount == -1)
                    {
                        Barrier11.SetActive(false);
                        Barrier22.SetActive(true);
                    }
                    break;
                case 5:
                    if (killDeathCount == -2)
                    {
                        Barrier22.SetActive(false);
                        Barrier33.SetActive(true);
                    }
                    break;
                case 6:
                    if (killDeathCount == -2)
                    {
                        Barrier33.SetActive(false);
                    }
                    break;

                default:
                    break;
            }
        }
    }
}
