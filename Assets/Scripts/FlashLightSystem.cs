using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{
    [SerializeField] float lightDecay = .05f;
    [SerializeField] float angleDecay = .02f;
    [SerializeField] float minAngleDecay = 40f;

    Light myLight;

    void Start()
    {
        myLight = GetComponent<Light>();
    }


    void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }

    public void RestoreLightAngle(float restoreAngle)
    {
        myLight.spotAngle = restoreAngle;
    }

    public void AddLightIntensity(float addIntensity)
    {
        myLight.intensity += addIntensity;
    }

    private void DecreaseLightAngle()
    {
        if (myLight.spotAngle <= minAngleDecay) return;
        myLight.spotAngle -= angleDecay * Time.deltaTime;
    }

    private void DecreaseLightIntensity()
    {
        if (myLight.intensity <= 0) return;
        myLight.intensity -= lightDecay * Time.deltaTime;
    }

}
