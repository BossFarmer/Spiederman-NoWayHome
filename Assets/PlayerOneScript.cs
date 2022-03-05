using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneScript : MonoBehaviour
{
    private int healthP1 = 150;
    public int currentHealthP1;
    // Start is called before the first frame update
    void Start()
    {
        currentHealthP1 = healthP1;
    }

    private void Update()
    {
        IsPlayerDead();
    }
    public void TakeDamagePlayer(int Damage)
    {
        currentHealthP1 -= Damage;
        Debug.Log("Player One health: " + currentHealthP1);
    }

    public void IsPlayerDead()
    {
        if (currentHealthP1 <= 0)
        {
            Debug.Log("Player One was killed!");
            Destroy(this.gameObject, 1f);
        }
    }

}
