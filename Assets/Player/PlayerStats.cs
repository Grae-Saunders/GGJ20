using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public PlayerSpawner masterSpawner;

    void Update()
    {
        if (transform.position.y < 0)
            masterSpawner.RespawnPlayer(gameObject);
        
    }
}
