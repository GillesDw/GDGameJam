using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InfectionProgression : MonoBehaviour
{
    [SerializeField] float infectionTime = 1200; //20 min
    [SerializeField] Material infectionVignette;
    float firstLevelOfInfectionTime, //light border
          secondLevelOfInfectionTime, //medium border with a small cought
          thirdLevelOfInfectionTime, //large border with medium cought
          fourthLevelOfInfectionTime, //xl border with medium cought
          fifthLevelOfInfectionTime; //big cought and screen become blurry
    private Renderer rend;

    public void Start()
    {
        rend = GetComponent<Renderer>();

        infectionVignette.SetFloat("_Vignette_Radius", 1f);
        infectionVignette.SetFloat("_Vignette_Darkening", 0.5f);
        infectionVignette.SetFloat("_Blur", 0f);
        infectionVignette.SetFloat("_Vignette_Blur", 0f);
        infectionVignette.SetFloat("_Vignette_Speed", 2f);






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
            infectionVignette.SetFloat("_Vignette_Radius", Mathf.Lerp(1f,0.8f,2));
            infectionVignette.SetFloat("_Vignette_Darkening", Mathf.Lerp(0.5f, 0.1f, 2));

        }
        if(infectionTime <= secondLevelOfInfectionTime && infectionTime > thirdLevelOfInfectionTime)
        {
            infectionVignette.SetFloat("_Vignette_Radius", Mathf.Lerp(0.8f, 0.6f, 2));
            infectionVignette.SetFloat("_Vignette_Darkening", 0.5f);
            infectionVignette.SetFloat("_Vignette_Speed", 4f);

        }
        if (infectionTime <= thirdLevelOfInfectionTime && infectionTime > fourthLevelOfInfectionTime)
        {
            infectionVignette.SetFloat("_Vignette_Radius", Mathf.Lerp(0.6f, 0.4f, 2));
            infectionVignette.SetFloat("_Vignette_Speed", 6f);

        }
        if (infectionTime <= fourthLevelOfInfectionTime && infectionTime > fifthLevelOfInfectionTime)
        {
            infectionVignette.SetFloat("_Vignette_Radius", Mathf.Lerp(0.4f, 0.3f, 2));
            infectionVignette.SetFloat("_Vignette_Speed", 8f);


        }
        if (infectionTime <= fifthLevelOfInfectionTime && infectionTime >= 0)
        {
            infectionVignette.SetFloat("_Blur", Mathf.Lerp(0f, 1f, 2));
            infectionVignette.SetFloat("_Vignette_Blur", Mathf.Lerp(0f, 6f, 2));
            infectionVignette.SetFloat("_Vignette_Speed", 10f);


        }

        if (infectionTime <= 0)
        {
            GameManager.instance.GameOver();
        }
    }
}
