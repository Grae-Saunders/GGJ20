using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets._2D;


public class PlayerEnvironmentInteraction : MonoBehaviour
{
    public PlayerStats playerStats;
    public GameManager gameManager;
    public PlatformerCharacter2D playerControls;
    
    public void OnTriggerStay2D(Collider2D collision)
    {
        var interaction = "J1Interact";
        if (gameObject.tag == "Player2")
            interaction = "J2Interact";
        if (CrossPlatformInputManager.GetButtonDown(interaction))
        {
            if (gameObject.tag == "Player1" && gameManager.subController.playerControlling == SubStandardAssets.PlayerControlling.Player1)
            {
                playerControls.LockMovement = false;
                gameManager.subController.SetPlayerController(0);
                return;
            }
            if (gameObject.tag == "Player2" && gameManager.subController.playerControlling == SubStandardAssets.PlayerControlling.Player2)
            {
                playerControls.LockMovement = false;
                gameManager.subController.SetPlayerController(0);

                return;
            }
            if (collision.tag == "Fixable")
            {
                collision.GetComponent<ProblemControl>().FixProblem();
                return;

            }
            if (collision.tag == "PilotSeat" )
            {
                // Switch to ship pilot mode
                if (gameManager.subController.playerControlling == SubStandardAssets.PlayerControlling.None)
                {
                    playerControls.LockMovement = true;
                    if (gameObject.tag == "Player1")
                        gameManager.subController.SetPlayerController(1);
                    else
                        gameManager.subController.SetPlayerController(2);

                }
                return;

            }
            if (collision.tag == "FuelPickup")
            {
                // if empty hands then switch to having fuel
                if (!playerStats.hasFuel)
                    playerStats.hasFuel = true;
                return;

            }
            if (collision.tag == "FuelDelivery")
            {
                // if has fuel drop and increment fuel drop fuel
                if (playerStats.hasFuel)
                {
                    playerStats.hasFuel = false;
                    gameManager.subController.AddFuel();

                }
                return;

            }

        }
    }
}
