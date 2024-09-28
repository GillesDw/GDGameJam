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
    [SerializeField] Camera camera;
    [SerializeField] GameObject handle;
    [SerializeField] float rotationSpeed;
    private void Awake()
    {
        flashlightBatteryTimeLeft = maxFlashlightBatteryTime;
    }

    private void Start()
    {
        flashlight.SetActive(false);
    }

    float timer = 0;

    private void Update()
    {
        if (flashlightBatteryTimeLeft > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (flashlightTurnOn != true)
                {
                    GameManager.instance.FlashlightOn();
                    flashlight.SetActive(true);
                    flashlightTurnOn = true;
                }
                else
                {
                    GameManager.instance.FlashlightOff();
                    flashlight.SetActive(false);
                    flashlightTurnOn = false;
                }
            }
        }

        if(flashlightTurnOn == true)
        {
            flashlightBatteryTimeLeft -= Time.deltaTime;

           Ray r = new Ray(camera.transform.position, camera.transform.forward);
           if (Physics.Raycast(r, out RaycastHit hitInfo, 100))
           {
                if(hitInfo.transform.CompareTag("Stalker")) {
                    //StalkerScript.HitByLight = true;
                    Debug.Log("hit by light");
                }
           }
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
            handle.transform.Rotate(0, rotationSpeed, 0);
            if(timer <= 0.02)
            {
                GameManager.instance.FlashlightRecharge();
            }
            if(timer >= 2.1f)
            {
                timer = 0;
            }
            Debug.Log(timer);
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
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
