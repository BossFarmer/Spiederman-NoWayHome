using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    [SerializeField]
    private float powerupRespawnTimer;

    public GameObject thisPowerup;
    CharacterMovement characterMovement;

    [SerializeField]
    Collider m_collider;

    [SerializeField]
    MeshRenderer meshRenderer;

    private void Start()
    {
        m_collider = GetComponent<Collider>();
    }

    public enum EPowerups
    {
        plusJump,
        plusDash,
        plusAmmo,
    }
    public EPowerups PowerUpType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            thisPowerup = this.gameObject;
            StartCoroutine("RespawnPowerups");
        }
    }

    IEnumerator RespawnPowerups()
    {
        meshRenderer.enabled = false;
        m_collider.enabled = !m_collider.enabled;
        yield return new WaitForSeconds(2f);
        m_collider.enabled = !m_collider.enabled;
        meshRenderer.enabled = true;
    }

}
