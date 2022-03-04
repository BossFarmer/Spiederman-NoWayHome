using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{

    public BarrierScript barrierScript;
    int randomSpawnPointPlayer1, randomSpawnPointPlayer2;
    [SerializeField]
    Transform[] spawnPointsPlayer1Area0, spawnPointsPlayer1Area1, spawnPointsPlayer1Area2, spawnPointsPlayer1Area3,spawnPointsPlayer1EnemyArea1, spawnPointsPlayer1EnemyArea2, spawnPointsPlayer2EnemyArea1, spawnPointsPlayer2EnemyArea2;

    [SerializeField]
    Transform[] spawnPointsPlayer2Area0, spawnPointsPlayer2Area1, spawnPointsPlayer2Area2, spawnPointsPlayer2Area3;

    public GameObject Player1;
    public GameObject Player2;

    private void Update()
    {
        SpawnPlayerOne();
    }

    void SpawnPlayerOne()
    {
        switch (barrierScript.P1DeathCount)
        {
            case -2:
                randomSpawnPointPlayer1 = Random.Range(0, spawnPointsPlayer1EnemyArea2.Length);
                Instantiate(Player2, spawnPointsPlayer1EnemyArea2[randomSpawnPointPlayer1].position, Quaternion.identity);
                break;
            case -1:
                randomSpawnPointPlayer1 = Random.Range(0, spawnPointsPlayer1EnemyArea1.Length);
                Instantiate(Player2, spawnPointsPlayer1EnemyArea1[randomSpawnPointPlayer1].position, Quaternion.identity);
                break;
            case 0:
                randomSpawnPointPlayer1 = Random.Range(0, spawnPointsPlayer1Area0.Length);
                Instantiate(Player1, spawnPointsPlayer1Area0 [randomSpawnPointPlayer1].position, Quaternion.identity);
                break;
            case 1:
                randomSpawnPointPlayer1 = Random.Range(0, spawnPointsPlayer1Area1.Length);
                Instantiate(Player1, spawnPointsPlayer1Area1[randomSpawnPointPlayer1].position, Quaternion.identity);
                break;
            case 2:
                randomSpawnPointPlayer1 = Random.Range(0, spawnPointsPlayer1Area2.Length);
                Instantiate(Player1, spawnPointsPlayer1Area2[randomSpawnPointPlayer1].position, Quaternion.identity);
                break;
            case 3:
                randomSpawnPointPlayer1 = Random.Range(0, spawnPointsPlayer1Area3.Length);
                Instantiate(Player1, spawnPointsPlayer1Area3[randomSpawnPointPlayer1].position, Quaternion.identity);
                break;
            default:
                break;
        }

        switch (barrierScript.P2DeathCount)
        {
            case -2:
                randomSpawnPointPlayer2 = Random.Range(0, spawnPointsPlayer2EnemyArea2.Length);
                Instantiate(Player2, spawnPointsPlayer1EnemyArea2[randomSpawnPointPlayer2].position, Quaternion.identity);
                break;
            case -1:
                randomSpawnPointPlayer2 = Random.Range(0, spawnPointsPlayer2EnemyArea1.Length);
                Instantiate(Player2, spawnPointsPlayer1EnemyArea1[randomSpawnPointPlayer2].position, Quaternion.identity);
                break;
            case 0:
                randomSpawnPointPlayer2 = Random.Range(0, spawnPointsPlayer2Area0.Length);
                Instantiate(Player2, spawnPointsPlayer2Area0[randomSpawnPointPlayer2].position, Quaternion.identity);
                break;
            case 1:
                randomSpawnPointPlayer2 = Random.Range(0, spawnPointsPlayer2Area1.Length);
                Instantiate(Player2, spawnPointsPlayer2Area1[randomSpawnPointPlayer2].position, Quaternion.identity);
                break;
            case 2:
                randomSpawnPointPlayer2 = Random.Range(0, spawnPointsPlayer2Area2.Length);
                Instantiate(Player2, spawnPointsPlayer2Area2[randomSpawnPointPlayer2].position, Quaternion.identity);
                break;
            case 3:
                randomSpawnPointPlayer2 = Random.Range(0, spawnPointsPlayer2Area3.Length);
                Instantiate(Player2, spawnPointsPlayer2Area3[randomSpawnPointPlayer2].position, Quaternion.identity);
                break;
            default:
                break;
        }
    }
}
