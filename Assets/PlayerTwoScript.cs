using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerTwoScript : MonoBehaviour
{
    private int healthP2 = 150;
    public int currentHealthP2;
    private int deathCountPlayer2Barrier;
    private int deathCountPlayer2Spawn;
    private bool temp = true;
    private PlayerOneScript plOneScript;

    public event Action<int> OnPlayer2DeathBarrier;
    public event Action<int, GameObject> OnPlayer2DeathSpawn;
    public event Action OnPlayer2Killed;

    void Awake()
    {
        plOneScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerOneScript>();
        plOneScript.OnPlayerOneKilled += PlayerOneKilled;
    }

    private void PlayerOneKilled()
    {
        deathCountPlayer2Spawn--;
        deathCountPlayer2Barrier--;
        Debug.Log("spawncount player2 : " + deathCountPlayer2Spawn);
    }

    private void OnPlayerOneKilled()
    {
        deathCountPlayer2Barrier--;
        Debug.Log("Player One was slayed! " + "deathCount of Player 2 "+ deathCountPlayer2Barrier);
    }

    void Start()
    {
        ResetHealth();
        deathCountPlayer2Barrier = 0;
        deathCountPlayer2Spawn = 0;
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
            Debug.Log("PlayerTwo Spawnpoint: " + deathCountPlayer2Barrier);
            deathCountPlayer2Barrier++;
            deathCountPlayer2Spawn++;
            Debug.Log("PlayerTwo Spawnpoint: " + deathCountPlayer2Barrier);
            OnPlayer2DeathBarrier?.Invoke(deathCountPlayer2Barrier);
            OnPlayer2DeathSpawn?.Invoke(deathCountPlayer2Spawn, this.gameObject);
            OnPlayer2Killed?.Invoke();
            Debug.Log("Player 2 was Killed");
            ResetHealth();
        }
    }

    public void ResetHealth()
    {
        currentHealthP2 = healthP2;
    }
}
