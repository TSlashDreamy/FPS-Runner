using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] RigidbodyFirstPersonController fpsController;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 20f;
    [SerializeField] float zoomedOutSensetivity = 2f;
    [SerializeField] float zoomedInSensetivity = .5f;

    bool isZoomed = false;

    void OnDisable()
    {
        ProcessZoomOut();
    }

    void Update()
    {
        ProcessZoom();
    }

    private void ProcessZoom()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (isZoomed == false)
            {
                ProcessZoomIn();
            }
            else
            {
                ProcessZoomOut();
            }
        }
    }

    private void ProcessZoomIn()
    {
        isZoomed = true;
        fpsCamera.fieldOfView = zoomedInFOV;
        fpsController.mouseLook.XSensitivity = zoomedInSensetivity;
        fpsController.mouseLook.YSensitivity = zoomedInSensetivity;
    }

    private void ProcessZoomOut()
    {
        isZoomed = false;
        fpsCamera.fieldOfView = zoomedOutFOV;
        fpsController.mouseLook.XSensitivity = zoomedOutSensetivity;
        fpsController.mouseLook.YSensitivity = zoomedOutSensetivity;
    }

}
