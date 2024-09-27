using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Torch : MonoBehaviour
{
    [SerializeField] GameObject flashlight;
    private bool flashlightTurnOn = false;
    [SerializeField] List<GameObject> flashlightBattery;

    private void Start()
    {
        flashlight.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (flashlightTurnOn != true)
            {
                flashlight.SetActive(true);
                flashlightTurnOn = true;
            }
            else
            {
                flashlight.SetActive(false);
                flashlightTurnOn = false;
            }
        }
    }
}
