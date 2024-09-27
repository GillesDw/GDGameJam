using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Torch : MonoBehaviour
{
    [SerializeField] GameObject flashlight;
    private bool flashlightTurnOn = false;
    [SerializeField] List<GameObject> flashlightBattery;
    private float flashlightBatteryTimeLeft;
    
    [SerializeField] private float maxFlashlightBatteryTime = 10;
    [SerializeField] private float flashlightBatteryTimeRecharge1Bar = 1;
    float currentReloadingTime = 0;
    private void Awake()
    {
        flashlightBatteryTimeLeft = maxFlashlightBatteryTime;
    }

    private void Start()
    {
        flashlight.SetActive(false);
    }

    private void Update()
    {
        if (flashlightBatteryTimeLeft > 0)
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

        if(flashlightTurnOn == true)
        {
            flashlightBatteryTimeLeft -= Time.deltaTime;
        }

        //Flashlight time life
        if(flashlightBatteryTimeLeft <= 0)
        {
            flashlight.SetActive(false);
            flashlightTurnOn = false;
        }

        UIBattery();

        if (Input.GetKey(KeyCode.R)) 
        {
            RechargeFlashlight();
        }
    }

    public void UIBattery()
    {
        if (flashlightBatteryTimeLeft >= maxFlashlightBatteryTime/4*3)
        {
            for (int i = 0; i < flashlightBattery.Count; i++)
            {
                flashlightBattery[i].SetActive(true);
            }
        }
        if (flashlightBatteryTimeLeft < maxFlashlightBatteryTime / 4 * 3 && flashlightBatteryTimeLeft >= maxFlashlightBatteryTime/2)
        {
            flashlightBattery[0].SetActive(true);
            flashlightBattery[1].SetActive(true);
            flashlightBattery[2].SetActive(true);
            flashlightBattery[3].SetActive(false);
        }
        if (flashlightBatteryTimeLeft < maxFlashlightBatteryTime / 2 && flashlightBatteryTimeLeft >= maxFlashlightBatteryTime / 4)
        {
            flashlightBattery[0].SetActive(true);
            flashlightBattery[1].SetActive(true);
            flashlightBattery[2].SetActive(false);
            flashlightBattery[3].SetActive(false);
        }
        if (flashlightBatteryTimeLeft < maxFlashlightBatteryTime / 4 && flashlightBatteryTimeLeft > 0)
        {
            flashlightBattery[0].SetActive(true);
            flashlightBattery[1].SetActive(false);
            flashlightBattery[2].SetActive(false);
            flashlightBattery[3].SetActive(false);
        }
        if (flashlightBatteryTimeLeft <= 0.1f)
        {
            for (int i = 0; i < flashlightBattery.Count; i++)
            {
                flashlightBattery[i].SetActive(false);
            }
        }
    }

    public void RechargeFlashlight()
    { 
        currentReloadingTime += Time.deltaTime;
        if (flashlightBatteryTimeLeft < maxFlashlightBatteryTime)
        {
            if (currentReloadingTime >= flashlightBatteryTimeRecharge1Bar)
            {
                flashlightBatteryTimeLeft += maxFlashlightBatteryTime / 4;
                currentReloadingTime = 0;
            }
        }
    }
}
