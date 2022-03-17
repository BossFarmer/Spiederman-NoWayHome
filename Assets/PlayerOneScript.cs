using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneScript : MonoBehaviour
{
    private int healthP1 = 150;
    public int currentHealthP1;
    [SerializeField] private int deathCountPlayer1Spawn;
    [SerializeField] private int deathCountPlayer1Barrierr;
    private PlayerTwoScript plTwoScript;
    // Start is called before the first frame update

    public event Action<int> OnPlayerOneDeathBarrier;
    public event Action<int, GameObject> OnPlayer1DeathSpawn;
    public event Action OnPlayerOneKilled;

    void Awake()
    {
        plTwoScript = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerTwoScript>();
        plTwoScript.OnPlayer2Killed += PlayerTwoKilled;
    }

    private void PlayerTwoKilled()
    {
        deathCountPlayer1Spawn--;
        if (deathCountPlayer1Spawn < -2)
        {
            deathCountPlayer1Spawn = -2;
        }

        deathCountPlayer1Barrierr--;

        if (deathCountPlayer1Barrierr < -2)
        {
            deathCountPlayer1Barrierr = -2;
        }
        Debug.Log("spawncount player one: " + deathCountPlayer1Spawn);
    }

    void Start()
    {
        ResetHealth();
        deathCountPlayer1Barrierr = 0;
        deathCountPlayer1Spawn = 0;
    }

    void Update()
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
            Debug.Log("PlayerOne Spawnpoint: " + deathCountPlayer1Barrierr);
            deathCountPlayer1Barrierr++;
            deathCountPlayer1Spawn++;
            Debug.Log("PlayerOne Spawnpoint: " + deathCountPlayer1Barrierr);
            OnPlayerOneDeathBarrier?.Invoke(deathCountPlayer1Barrierr);
            OnPlayer1DeathSpawn?.Invoke(deathCountPlayer1Spawn, this.gameObject);
            OnPlayerOneKilled?.Invoke();
            ResetHealth();

        }
    }

    public void ResetHealth()
    {
        currentHealthP1 = healthP1;
    }
}
