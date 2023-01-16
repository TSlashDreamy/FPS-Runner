using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{

    [SerializeField] float lightIntensityToAdd = 1f;
    [SerializeField] float lightAngleToRestore = 90f;
    
    FlashLightSystem playerFlashLight;


    private void OnTriggerEnter(Collider other)
    {
        playerFlashLight = other.GetComponentInChildren<FlashLightSystem>();
        ChangeFlashlightBattery();
    }

    private void ChangeFlashlightBattery()
    {
        playerFlashLight.AddLightIntensity(lightIntensityToAdd);
        playerFlashLight.RestoreLightAngle(lightAngleToRestore);
        Destroy(gameObject);
    }

}
