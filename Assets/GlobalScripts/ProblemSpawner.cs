using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemSpawner : MonoBehaviour
{
    public GameObject ProblemPrefab;
    public List<Transform> ProblemLocations;

    private System.Random randLocation;

    int currentProblem;

    public float approxTimeToNextSpawn;
    public float randomTimeVariation;

    float currentTimeToNextSpawn;
    float currentTime;

    public void Start()
    {
        randLocation = new System.Random(1); //add seed here
        RandomiseProblems();
        currentTimeToNextSpawn = Random.Range(approxTimeToNextSpawn - randomTimeVariation, approxTimeToNextSpawn + randomTimeVariation);
    }

    private void Update()
    {
        if (currentTime > currentTimeToNextSpawn)
            SpawnProblem();
        currentTime += Time.deltaTime;
    }


    private void SpawnProblem()
    {
        if (currentProblem >= ProblemLocations.Count)
            return;
        var go = Instantiate(ProblemPrefab, ProblemLocations[currentProblem].position, Quaternion.identity, ProblemLocations[currentProblem]);
        currentProblem++;
        currentTimeToNextSpawn = Random.Range(approxTimeToNextSpawn - randomTimeVariation, approxTimeToNextSpawn + randomTimeVariation);
        currentTime = 0;
    }


    private void RandomiseProblems()
    {
        var tempList = new List<Transform>(ProblemLocations);
        ProblemLocations.Clear();
        while (tempList.Count > 0)
        {
            var nextLoc = randLocation.Next(0, tempList.Count);
            ProblemLocations.Add(tempList[nextLoc]);

            tempList.RemoveAt(nextLoc);
        }
    }
}
