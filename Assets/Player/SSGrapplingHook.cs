using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;
using UnityStandardAssets.CrossPlatformInput;


public class SSGrapplingHook : MonoBehaviour
{
    public float MaxGrapplingHookLength = 15f;
    public float MaxGraplingShootSpeed;
    public float MaxGraplingRetractSpeed;
    public float GrappleProximity = 0.2f;

    public Transform grappleLaunch;

    public LayerMask GroundLayer;

    public GameObject GrapplingHook;
    public LineRenderer GrappleTether;

    bool grappleShot;
    bool grappleHit;

    PlatformerCharacter2D moveController;
    Rigidbody2D playerRigidbody;
    HingeJoint2D hingeSwing;

    Vector3 launchDirection;

    void Awake()
    {
        grappleHit = false;
        grappleShot = false;
        GrapplingHook.SetActive(false);
        GrappleTether = GrapplingHook.GetComponent<LineRenderer>();
        moveController = GetComponent<PlatformerCharacter2D>();
        hingeSwing = GrapplingHook.GetComponent<HingeJoint2D>();
        hingeSwing.enabled = false;
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var button = "J1Fire1";
        if (gameObject.tag == "Player2")
            button = "J2Fire1";
        if (!grappleShot && CrossPlatformInputManager.GetButtonDown(button))
        {
            grappleShot = true;
            GrapplingHook.transform.position = grappleLaunch.position;
            GrapplingHook.SetActive(true);
            launchDirection = (transform.localScale.x > 0 ? Vector3.right : Vector3.left) + Vector3.up;
        }
        if (grappleShot && !grappleHit)
        {
            
            GrapplingHook.transform.position = Vector2.Lerp(GrapplingHook.transform.position, GrapplingHook.transform.position + launchDirection, Time.deltaTime * MaxGraplingShootSpeed);
            if (Vector2.Distance(GrapplingHook.transform.position, transform.position) > MaxGrapplingHookLength)
            {
                DespawnHook();
            }
            if (Physics2D.OverlapCircle(GrapplingHook.transform.position, GrappleProximity, GroundLayer))
            {
                Debug.Log("Hit");
                grappleHit = true;
                moveController.LockMovement = true;
                hingeSwing.enabled = true;

                hingeSwing.connectedBody = playerRigidbody;
                playerRigidbody.constraints = RigidbodyConstraints2D.None;
            }
            
            UpdateTetherPosition();
        }
        if (grappleHit)
        {
            if (CrossPlatformInputManager.GetButtonDown(button))
            {
                DespawnHook();
            }
            transform.position = Vector2.MoveTowards(transform.position, GrapplingHook.transform.position, MaxGraplingRetractSpeed);

            UpdateTetherPosition();
        }
    }
    void LateUpdate()
    {
        if (grappleHit)
            transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void DespawnHook()
    {
        grappleHit = false;
        grappleShot = false;
        GrapplingHook.SetActive(false);
        moveController.LockMovement = false;
        hingeSwing.connectedBody = null;
        hingeSwing.enabled = false;
        playerRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    private void UpdateTetherPosition()
    {
        GrappleTether.SetPosition(0, grappleLaunch.position);
        GrappleTether.SetPosition(1, GrapplingHook.transform.position);
    }
}
