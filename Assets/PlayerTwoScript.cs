using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoScript : MonoBehaviour
{
    private int healthP2 = 150;
    public int currentHealthP2;
    // Start is called before the first frame update
    void Start()
    {
        currentHealthP2 = healthP2;
    }

    private void Update()
    {
        IsPlayer2Dead();
    }
    public void TakeDamagePlayer2(int Damage)
    {
        currentHealthP2 -= Damage;
        Debug.Log("Player Two health: "+currentHealthP2);
    }

    public void IsPlayer2Dead()
    {
        if (currentHealthP2 <= 0)
        {
            Debug.Log("Player 2 was Killed");
            Destroy(this.gameObject, 1f);
        }

    }


}
