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

        void Awake()
        {
            SubmarineRigidbody = GetComponent<Rigidbody2D>();
        }
        void Update()
        {
            MoveSubmarine();
        }

        public void MoveSubmarine()
        {
            float h = Mathf.Clamp01(CrossPlatformInputManager.GetAxis("Player2Horizontal"));
            float j = CrossPlatformInputManager.GetAxis("Player2Vertical");

            transform.rotation = Quaternion.Euler(0,1,j);

            SubmarineRigidbody.velocity = new Vector2(h, j) * SubSpeed;
        }
    }
}
