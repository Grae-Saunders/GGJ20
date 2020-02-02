using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD;
using FMODUnity;


public class AudioController : MonoBehaviour
{
    //Sound reference
    public StudioEventEmitter ambience;
    public StudioEventEmitter controlRoom;
    public StudioEventEmitter fuelRoom;
    public StudioEventEmitter sonarRoom;
    public StudioEventEmitter engineRoom;


    private void Start()
    {
        controlRoom.EventInstance.setVolume(0);
        fuelRoom.EventInstance.setVolume(0);
        sonarRoom.EventInstance.setVolume(0);
        engineRoom.EventInstance.setVolume(0);
    }

}
