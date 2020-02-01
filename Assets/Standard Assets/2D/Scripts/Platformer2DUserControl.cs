using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof(PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;


        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        public void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                if (gameObject.tag == "Player1")
                {
                    
                    m_Jump = CrossPlatformInputManager.GetButtonDown("J1Jump");

                    Debug.Log($"P1 {m_Jump}");
                }
                if (gameObject.tag == "Player2")
                {
                    m_Jump = CrossPlatformInputManager.GetButtonDown("J2Jump");

                }
            }
        }

        private void FixedUpdate()
        {
            // Read the inputs.
            //bool crouch = Input.GetKey(KeyCode.LeftControl);
            if (gameObject.tag == "Player1")
            {
                float h = CrossPlatformInputManager.GetAxis("J1Horizontal");
                // Pass all parameters to the character control script.
                m_Character.Move(h, m_Jump);
                m_Jump = false;

            }
            if (gameObject.tag == "Player2")

            {
                float h = CrossPlatformInputManager.GetAxis("J2Horizontal");
                // Pass all parameters to the character control script.

                m_Character.Move(h, m_Jump);
                m_Jump = false;
            }

        }
    }
}
