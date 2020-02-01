using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    ProblemSpawner problemSpawner;

    // Start is called before the first frame update
    void Start()
    {
        problemSpawner = GetComponent<ProblemSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
