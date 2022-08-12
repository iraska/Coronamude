using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{
    [SerializeField] float lightDecay = .1f; //how much is the light kind of fading over time
    [SerializeField] float angleDecay = 1f; //spot angle
    [SerializeField] float minimumAngle = 40f; //min spot angle variable

    Light myLight; //flashlight' component

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

    public void AddLightIntensity(float intensityAmount)
    {
        myLight.intensity += intensityAmount;
    }

    void DecreaseLightAngle()
    {
        if (myLight.spotAngle <= minimumAngle) return;
        else
        {
            myLight.spotAngle -= angleDecay * Time.deltaTime;
        }
    }

    void DecreaseLightIntensity()
    {
        myLight.intensity -= lightDecay * Time.deltaTime;
    }
}
