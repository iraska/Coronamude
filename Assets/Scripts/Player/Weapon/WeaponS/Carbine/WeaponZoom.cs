using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera; //drag the main cam
    [SerializeField] RigidbodyFirstPersonController fpsController; //drag the player
    [SerializeField] float zoomedOutFov = 60f;
    [SerializeField] float zoomedInFov = 20f;
    [SerializeField] float zoomOutSensitivity = 2f;
    [SerializeField] float zoomInSensitivity = 0.5f;

    bool zoomedInToggle = false;

    void OnDisable() 
    {
        ZoomOut(); //For bug: when we change the weapon zoom toggle still enable
    }

    void Update() 
    {
        if (Input.GetMouseButtonDown(1))    //right mouse click
        {
            if (zoomedInToggle == false)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }
    }

    void ZoomIn()
    {
        zoomedInToggle = true;
        fpsCamera.fieldOfView = zoomedInFov;
        fpsController.mouseLook.XSensitivity = zoomInSensitivity; //look at the inspector: player>rigidBodyFFPSController script>mouse look>x sensivity
        fpsController.mouseLook.YSensitivity = zoomInSensitivity;
    }

    void ZoomOut()
    {
        zoomedInToggle = false;
        fpsCamera.fieldOfView = zoomedOutFov;
        fpsController.mouseLook.XSensitivity = zoomOutSensitivity;
        fpsController.mouseLook.YSensitivity = zoomOutSensitivity;
    }
}
