using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneScript : MonoBehaviour
{
    private int healthP1 = 150;
    public int currentHealthP1;
    private SpawnScript spawnScript;
    private int deathCountPlayer1;
    private PlayerTwoScript plTwoScript;
    // Start is called before the first frame update

    public event Action<int> OnPlayer1Death;
    public event Action<int, GameObject > OnPlayer1DeathSpawn;
    public event Action OnPlayerOneKilled;

    void Awake()
    {
        plTwoScript = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerTwoScript>();
        plTwoScript.OnPlayerTwoKilled += OnPlayerTwoKilled;
    }

    private void OnPlayerTwoKilled()
    {
        deathCountPlayer1--;
        Debug.Log("Player Two was slayed! " + "deathCount of Player 1 " + deathCountPlayer1);

    }

    void Start()
    {
        ResetHealth();
        spawnScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<SpawnScript>();
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
            Debug.Log("PlayerOne Spawnpoint: " + deathCountPlayer1);
            deathCountPlayer1++;
            OnPlayerOneKilled?.Invoke();
            Debug.Log("PlayerOne Spawnpoint: " + deathCountPlayer1);
            OnPlayer1Death?.Invoke(deathCountPlayer1);
            OnPlayer1DeathSpawn?.Invoke(deathCountPlayer1, this.gameObject);
            ResetHealth();

        }
    }

    public void ResetHealth()
    {
        currentHealthP1 = healthP1;
    }
}
