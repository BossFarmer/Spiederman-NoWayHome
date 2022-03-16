using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerTwoScript : MonoBehaviour
{
    private int healthP2 = 150;
    public int currentHealthP2;
    private int deathCountPlayer2;
    private SpawnScript spawnScript;
    private bool temp = true;
    private PlayerOneScript plOneScript;

    public event Action<int> OnPlayer2Death;
    public event Action<int, GameObject> OnPlayer2DeathSpawn;
    public event Action OnPlayerTwoKilled;

    void Awake()
    {
        plOneScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerOneScript>();
        plOneScript.OnPlayerOneKilled += OnPlayerOneKilled;

    }

    private void OnPlayerOneKilled()
    {
        deathCountPlayer2--;
        Debug.Log("Player One was slayed! " + "deathCount of Player 2 "+ deathCountPlayer2);
    }

    void Start()
    {
        ResetHealth();
        deathCountPlayer2 = BarrierScript.P2DeathCount;
        Debug.Log("PlayerTwo Spawnpoint: "+deathCountPlayer2);
        spawnScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<SpawnScript>();
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
            Debug.Log("PlayerTwo Spawnpoint: " + deathCountPlayer2);
            deathCountPlayer2++;
            OnPlayerTwoKilled?.Invoke();
            Debug.Log("PlayerTwo Spawnpoint: " + deathCountPlayer2);
            OnPlayer2Death?.Invoke(deathCountPlayer2);
            OnPlayer2DeathSpawn?.Invoke(deathCountPlayer2, this.gameObject);
            Debug.Log("Player 2 was Killed");
            ResetHealth();
        }
    }

    public void ResetHealth()
    {
        currentHealthP2 = healthP2;
    }
}
