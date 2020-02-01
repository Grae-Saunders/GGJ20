using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public PlayerSpawner masterSpawner;
    public bool hasFuel;
    void Update()
    {
        if (transform.position.y < 0)
            masterSpawner.RespawnPlayer(gameObject);
        
    }
}
