using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextAreaCheck : MonoBehaviour
{
    
    public GameObject WinningScreen;

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "NextArea")
        {
            //respawn
        }
    }
}
