using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProblemControl : MonoBehaviour
{
    //public Light roomLight;
    public GameObject goodLight;
    public GameObject badLight;
    public ParticleSystem particles;

    public AudioController audioController;
    
    public bool isTriggered;

    public RoomName thisRoom;

    private void Start()
    {
        goodLight.SetActive(true);
        badLight.SetActive(false);
    }

    public void TriggerProblem()
    {
        isTriggered = true;
        //roomLight.color = badLight;
        goodLight.SetActive(false);
        badLight.SetActive(true);
        if (particles != null)
            particles.Play();

        switch (thisRoom)
        {
            case ProblemControl.RoomName.Control:
                audioController.controlRoom.EventInstance.setVolume(1);
                audioController.controlRoom.SetParameter("Broken", 0);


                break;
            case ProblemControl.RoomName.Engine:
                audioController.engineRoom.EventInstance.setVolume(1);
                audioController.engineRoom.SetParameter("Broken",0);

                break;
            case ProblemControl.RoomName.Sonar:
                audioController.sonarRoom.EventInstance.setVolume(1);
                audioController.sonarRoom.SetParameter("Broken", 0);

                break;
            case ProblemControl.RoomName.Fuel:
                audioController.fuelRoom.EventInstance.setVolume(1);
                audioController.fuelRoom.SetParameter("Broken", 0);

                break;
        }
    }
    public void FixProblem()
    {
        isTriggered = false;

        goodLight.SetActive(true);
        badLight.SetActive(false);

        switch (thisRoom)
        {
            case ProblemControl.RoomName.Control:
                audioController.controlRoom.SetParameter("Broken", 2) ;

                break;
            case ProblemControl.RoomName.Engine:
                audioController.engineRoom.SetParameter("Broken", 2);

                break;
            case ProblemControl.RoomName.Sonar:
                audioController.sonarRoom.SetParameter("Broken", 2);

                break;
            case ProblemControl.RoomName.Fuel:
                audioController.fuelRoom.SetParameter("Broken", 2);

                break;
        }
    }
    public enum RoomName
    {
        Control,
        Fuel,
        Sonar,
        Engine
    }
}
