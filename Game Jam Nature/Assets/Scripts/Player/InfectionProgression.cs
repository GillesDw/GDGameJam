using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class InfectionProgression : MonoBehaviour
{
    [SerializeField] float infectionTime = 1200; //20 min
    float firstLevelOfInfectionTime, //light border
          secondLevelOfInfectionTime, //medium border with a small cought
          thirdLevelOfInfectionTime, //large border with medium cought
          fourthLevelOfInfectionTime, //xl border with medium cought
          fifthLevelOfInfectionTime; //big cought and screen become blurry

    public void Start()
    {
        
        firstLevelOfInfectionTime = infectionTime / 5 * 4;
        secondLevelOfInfectionTime = infectionTime / 5 * 3;
        thirdLevelOfInfectionTime = infectionTime / 5 * 2;
        fourthLevelOfInfectionTime = infectionTime / 5;
        fifthLevelOfInfectionTime = infectionTime / 10;
    }

    public void Update()
    {
        infectionTime -= Time.deltaTime;
        if(infectionTime <= firstLevelOfInfectionTime && infectionTime > secondLevelOfInfectionTime)
        {
            
        }
        if(infectionTime <= secondLevelOfInfectionTime && infectionTime > thirdLevelOfInfectionTime)
        {
            
        }
        if(infectionTime <= thirdLevelOfInfectionTime && infectionTime > fourthLevelOfInfectionTime)
        {
            
        }
        if (infectionTime <= fourthLevelOfInfectionTime && infectionTime > fifthLevelOfInfectionTime)
        {
            
        }
        if (infectionTime <= fifthLevelOfInfectionTime && infectionTime >= 0)
        {
            
        }

        if(infectionTime <= 0)
        {
            GameManager.instance.GameOver();
        }
    }
}
