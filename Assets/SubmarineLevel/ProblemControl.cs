using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemControl : MonoBehaviour
{
    public Light roomLight;
    public ParticleSystem particles;

    public Color goodLight;
    public Color badLight;

    public bool isTriggered;

    public void TriggerProblem()
    {
        roomLight.color = badLight;
        if (particles != null)
            particles.Play();
    }
    public void FixProblem()
    {
        roomLight.color = goodLight;
    }
}
