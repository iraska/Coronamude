using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] float zoomedOutFov = 60f;
    [SerializeField] float zoomedInFov = 20f;
    [SerializeField] float zoomOutSensitivity = 2f;
    [SerializeField] float zoomInSensitivity = 0.5f;

    RigidbodyFirstPersonController fpsController;

    bool zoomedInToggle = false;

    void Start() 
    {
        fpsController = GetComponent<RigidbodyFirstPersonController>();
    }

    void Update() 
    {
        if (Input.GetMouseButtonDown(1))    //right mouse click
        {
            if (zoomedInToggle == false)
            {
                zoomedInToggle = true;
                fpsCamera.fieldOfView = zoomedInFov;
                fpsController.mouseLook.XSensitivity = zoomInSensitivity; //look at the inspector: player>rigidBodyFFPSController script>mouse look>x sensivity
                fpsController.mouseLook.YSensitivity = zoomInSensitivity;
            }
            else
            {
                zoomedInToggle = false;
                fpsCamera.fieldOfView = zoomedOutFov;
                fpsController.mouseLook.XSensitivity = zoomOutSensitivity;
                fpsController.mouseLook.YSensitivity = zoomOutSensitivity;
            }
        }
    }
}
