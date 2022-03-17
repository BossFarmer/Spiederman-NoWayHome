using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerDeathScript : MonoBehaviour
{
    public event Action OnDeath;
    [SerializeField] private GameObject Hitbox;

    private void Update()
    {
        transform.position = Hitbox.transform.position + new Vector3(0,-1.5f,0);
    }
    private void OnDeathAnimation()
    {
        OnDeath?.Invoke();
    }
}
