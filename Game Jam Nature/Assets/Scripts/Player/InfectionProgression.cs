using NUnit.Framework;
using UnityEngine;

public class InfectionProgression : MonoBehaviour
{
    [SerializeField] float maxInfectionTime = 1200; //20 min
    [SerializeField] float firstLevelOfInfectionTime, //light border
                           secondLevelOfInfectionTime, //medium border with a small cought
                           thirdLevelOfInfectionTime, //large border with medium cought
                           fourthLevelOfInfectionTime, //xl border with medium cought
                           fifthtLevelOfInfectionTime; //big cought and screen become blurry



}
