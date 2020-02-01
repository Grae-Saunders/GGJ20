using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject Player1Controller;
    public Transform respawnLocation;


    public void RespawnPlayer(GameObject playerToRespawn)
    {
        playerToRespawn.transform.position = respawnLocation.position;
    }
}
