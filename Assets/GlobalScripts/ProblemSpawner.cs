using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemSpawner : MonoBehaviour
{
    public GameObject ProblemPrefab;
    public List<ProblemControl> ProblemLocations;

    public AudioController audioController;

    private System.Random randLocation;

    int currentProblem;

    public float approxTimeToNextTrigger;
    public float randomTimeVariation;

    float currentTimeToNextTrigger;
    float currentTime;
        
    public void Start()
    {
        randLocation = new System.Random(1); //add seed here
        RandomiseProblems();
        currentTimeToNextTrigger = Random.Range(approxTimeToNextTrigger - randomTimeVariation, approxTimeToNextTrigger + randomTimeVariation);
    }

    private void Update()
    {
        if (currentTime > currentTimeToNextTrigger)
            TriggerProblem();
        currentTime += Time.deltaTime;
    }


    private void TriggerProblem()
    {
        //if (currentProblem >= ProblemLocations.Count)
        //    return;
        //var go = Instantiate(ProblemPrefab, ProblemLocations[currentProblem].position, Quaternion.identity, ProblemLocations[currentProblem]);
        currentProblem++;
        currentTimeToNextTrigger = Random.Range(approxTimeToNextTrigger - randomTimeVariation, approxTimeToNextTrigger + randomTimeVariation);
        currentTime = 0;
        var nextLoc = randLocation.Next(0, ProblemLocations.Count);
        ProblemLocations[nextLoc].TriggerProblem();
    }


    private void RandomiseProblems()
    {
        //var tempList = new List<Transform>(ProblemLocations);
        //ProblemLocations.Clear();
        //while (tempList.Count > 0)
        //{
        //    var nextLoc = randLocation.Next(0, tempList.Count);
        //    ProblemLocations.Add(tempList[nextLoc]);

        //    tempList.RemoveAt(nextLoc);
        //}
    }
}
