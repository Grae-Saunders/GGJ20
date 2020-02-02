using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


namespace SubStandardAssets
{
    public class SubmarineDriveController : MonoBehaviour
    {
        [HideInInspector]
        public Rigidbody2D SubmarineRigidbody;
        public float SubSpeed = 5f;

        public float fuelAmount;
        public float maxFuel;
        public float refuelAmount;
        public float fuelConsumptiopnRate;

        public PlayerControlling playerControlling;

        public float subLevelingOut = 2.5f;

        void Awake()
        {
            SubmarineRigidbody = GetComponent<Rigidbody2D>();
        }
        void Update()
        {
            if (playerControlling == PlayerControlling.None)
                return;
            if (fuelAmount <= 0)
                return;
            MoveSubmarine();
            FuelConsumption();
        }

        void MoveSubmarine()
        {
            float h, j;
            if (playerControlling == PlayerControlling.Player1)
            {
                h = Mathf.Clamp01(CrossPlatformInputManager.GetAxis("J1Horizontal"));
                j = CrossPlatformInputManager.GetAxis("J1Vertical"); 
            }
            else
            {
                h = Mathf.Clamp01(CrossPlatformInputManager.GetAxis("J2Horizontal"));
                j = CrossPlatformInputManager.GetAxis("J2Vertical");
            }

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 1, -j*5),Time.deltaTime * subLevelingOut);

            SubmarineRigidbody.velocity = new Vector2(h, -j) * SubSpeed;
        }
        void FuelConsumption()
        {
            fuelAmount -= Time.deltaTime * fuelConsumptiopnRate;
            if (fuelAmount < 0)
                fuelAmount = 0;
        }

        public void AddFuel()
        {
            fuelAmount += refuelAmount;
            if (fuelAmount > maxFuel)
                fuelAmount = maxFuel;
        }
        public void SetPlayerController(int playerID)
        {
            if (playerID == 1)
                playerControlling = PlayerControlling.Player1;

            else if (playerID == 2)
                playerControlling = PlayerControlling.Player2;
            else
            {
                playerControlling = PlayerControlling.None;
                SubmarineRigidbody.velocity = Vector2.zero;
            }
        }
    }
    public enum PlayerControlling
    {
        None,
        Player1,
        Player2
    }
}
