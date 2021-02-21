using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float lightDecay = 0.1f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minimumAngle = 40f;

    Light mylight;
    void Start()
    {
        mylight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }

    void DecreaseLightAngle()
    {
        mylight.spotAngle -= angleDecay * Time.deltaTime;
    }
    void DecreaseLightIntensity()
    {
        mylight.intensity -= lightDecay * Time.deltaTime;
    }
    public void RestoreLightAngle(float restoreAngle)
    {
        mylight.spotAngle = restoreAngle;
    }
    public void RestoreLightIntensity(float lightIntensity)
    {
        mylight.intensity += lightIntensity;
    }
}
