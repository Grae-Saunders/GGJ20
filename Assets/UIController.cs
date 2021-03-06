﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SubStandardAssets;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public Text scoreField;
    public Text fuelField;
    public Text shipCondition;
    public Transform submarine;
    public SubmarineDriveController subDriveControl;
    public ProblemSpawner probSpawner;


    // Update is called once per frame
    void Update()
    {
        var distanceTraveled = (int)submarine.position.x;
        scoreField.text = $"Distance Traveled: {distanceTraveled}";

        var fuelRemaining = (int)subDriveControl.fuelAmount;
        fuelField.text = $"Fuel {fuelRemaining}";

        var timeToCrash = (int)((probSpawner.timeToEnd /500f )*100f);
        shipCondition.text = $"Damaged {timeToCrash}%";

        if (timeToCrash >105)
            SceneManager.LoadScene(0);


        if (CrossPlatformInputManager.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
