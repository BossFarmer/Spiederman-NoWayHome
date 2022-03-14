using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{

    public BarrierScript barrierScript;
    int randomSpawnPointPlayer1, randomSpawnPointPlayer2;
    [SerializeField]
    Transform[] spawnPointsPlayer1Area0, spawnPointsPlayer1Area1, spawnPointsPlayer1Area2, spawnPointsPlayer1Area3, spawnPointsPlayer1EnemyArea1, spawnPointsPlayer1EnemyArea2, spawnPointsPlayer2EnemyArea1, spawnPointsPlayer2EnemyArea2;

    [SerializeField]
    Transform[] spawnPointsPlayer2Area0, spawnPointsPlayer2Area1, spawnPointsPlayer2Area2, spawnPointsPlayer2Area3;

    public GameObject Player1;
    public GameObject Player2;
    private int p1Death;
    private int p2Death;
    private PlayerOneScript playerOneScript;
    private PlayerTwoScript playerTwoScript;
    private void Start()
    {
        p1Death = BarrierScript.deathCount;
        p2Death = BarrierScript.P2DeathCount;
        playerOneScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerOneScript>();
        playerTwoScript = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerTwoScript>();
        playerOneScript.OnPlayer1DeathSpawn += PlayerNewSpawnDeath;
        playerTwoScript.OnPlayer2DeathSpawn += PlayerNewSpawnDeath2;
       
    }
    private void PlayerNewSpawnDeath(int obj, GameObject player)
    {
        Debug.Log("SpawnScript: DeathCOuntPlayerOne: " + obj);
        SpawnPlayerOne(obj,player);
    }
    private void PlayerNewSpawnDeath2(int obj, GameObject player)
    {
        Debug.Log("SpawnScript: DeathCOuntPlayerOne: " + obj);
        SpawnPlayerTwo(obj,player);
    }

    private void Update()
    {
        
    }


    public void SpawnPlayerOne(int deathCount, GameObject player)
    {
        Vector3 tempDir;
        switch (deathCount)
        {
            case -2:
                randomSpawnPointPlayer1 = Random.Range(0, spawnPointsPlayer1EnemyArea2.Length);
                tempDir = spawnPointsPlayer1EnemyArea2[randomSpawnPointPlayer1].transform.position;
                player.GetComponent<CharacterController>().enabled = false;
                player.transform.position = tempDir;
                player.GetComponent<CharacterController>().enabled = true;
                break;
            case -1:
                randomSpawnPointPlayer1 = Random.Range(0, spawnPointsPlayer1EnemyArea1.Length);
                tempDir = spawnPointsPlayer1EnemyArea1[randomSpawnPointPlayer1].transform.position;
                player.GetComponent<CharacterController>().enabled = false;
                player.transform.position = tempDir;
                player.GetComponent<CharacterController>().enabled = true;
                break;
            case 0:
                randomSpawnPointPlayer1 = Random.Range(0, spawnPointsPlayer1Area0.Length);
                tempDir = spawnPointsPlayer1Area0[randomSpawnPointPlayer1].transform.position;
                player.GetComponent<CharacterController>().enabled = false;
                player.transform.position = tempDir;
                player.GetComponent<CharacterController>().enabled = true;
                break;
            case 1:
                randomSpawnPointPlayer1 = Random.Range(0, spawnPointsPlayer1Area1.Length);
                tempDir = spawnPointsPlayer1Area1[randomSpawnPointPlayer1].transform.position;
                player.GetComponent<CharacterController>().enabled = false;
                player.transform.position = tempDir;
                player.GetComponent<CharacterController>().enabled = true;                
                break;
            case 2:
                randomSpawnPointPlayer1 = Random.Range(0, spawnPointsPlayer1Area2.Length);
                tempDir = spawnPointsPlayer1Area2[randomSpawnPointPlayer1].transform.position;
                player.GetComponent<CharacterController>().enabled = false;
                player.transform.position = tempDir;
                player.GetComponent<CharacterController>().enabled = true;
                break;
            case 3:
                randomSpawnPointPlayer1 = Random.Range(0, spawnPointsPlayer1Area3.Length);
                tempDir = spawnPointsPlayer1Area3[randomSpawnPointPlayer1].transform.position;
                player.GetComponent<CharacterController>().enabled = false;
                player.transform.position = tempDir;
                player.GetComponent<CharacterController>().enabled = true;
                break;
            default:
                break;
        }
    }
    public void SpawnPlayerTwo(int deathCount,GameObject player)
    {
        Vector3 tempDir;
        switch (deathCount)
        {
            case -2:
                randomSpawnPointPlayer2 = Random.Range(0, spawnPointsPlayer2EnemyArea2.Length);
                tempDir = spawnPointsPlayer1EnemyArea2[randomSpawnPointPlayer2].position;
                player.GetComponent<CharacterController>().enabled = false;
                player.transform.position = tempDir;
                player.GetComponent<CharacterController>().enabled = true;
                break;
            case -1:
                randomSpawnPointPlayer2 = Random.Range(0, spawnPointsPlayer2EnemyArea1.Length);
                tempDir = spawnPointsPlayer1EnemyArea1[randomSpawnPointPlayer2].position;
                player.GetComponent<CharacterController>().enabled = false;
                player.transform.position = tempDir;
                player.GetComponent<CharacterController>().enabled = true;
                break;
            case 0:
                randomSpawnPointPlayer2 = Random.Range(0, spawnPointsPlayer2Area0.Length);
                tempDir = spawnPointsPlayer2Area0[randomSpawnPointPlayer2].position;
                player.GetComponent<CharacterController>().enabled = false;
                player.transform.position = tempDir;
                player.GetComponent<CharacterController>().enabled = true;
                break;
            case 1:
                randomSpawnPointPlayer2 = Random.Range(0, spawnPointsPlayer2Area1.Length);
                tempDir = spawnPointsPlayer2Area1[randomSpawnPointPlayer2].position;
                player.GetComponent<CharacterController>().enabled = false;
                player.transform.position = tempDir;
                player.GetComponent<CharacterController>().enabled = true;
                break;
            case 2:
                randomSpawnPointPlayer2 = Random.Range(0, spawnPointsPlayer2Area2.Length);
                tempDir = spawnPointsPlayer2Area2[randomSpawnPointPlayer2].position;
                player.GetComponent<CharacterController>().enabled = false;
                player.transform.position = tempDir;
                player.GetComponent<CharacterController>().enabled = true;
                break;
            case 3:
                randomSpawnPointPlayer2 = Random.Range(0, spawnPointsPlayer2Area3.Length);
                tempDir = spawnPointsPlayer2Area3[randomSpawnPointPlayer2].position;
                player.GetComponent<CharacterController>().enabled = false;
                player.transform.position = tempDir;
                player.GetComponent<CharacterController>().enabled = true;
                break;
            default:
                break;
        }
    }
}

