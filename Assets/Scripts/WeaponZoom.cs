using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Camera playerCamera;
    [SerializeField] float zoomOutFOV = 60f;
    [SerializeField] float zoomInFOV = 20f;
    RigidbodyFirstPersonController firstPersonController;
    [SerializeField] float zoomOutSens = 2f;
    [SerializeField] float zoomInSens = 0.5f;



    bool zoomedInToggle = false;
    void Start()
    {
        firstPersonController = GetComponentInParent<RigidbodyFirstPersonController>();
  
    
    }

    void Zoom()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if(!zoomedInToggle)
            {
                zoomedInToggle = true;
                playerCamera.fieldOfView = zoomInFOV;
                firstPersonController.mouseLook.XSensitivity = zoomInSens;
                firstPersonController.mouseLook.YSensitivity = zoomInSens;
            }
            else
            {
                zoomedInToggle = false;
                playerCamera.fieldOfView = zoomOutFOV;
                firstPersonController.mouseLook.XSensitivity = zoomOutSens;
                firstPersonController.mouseLook.YSensitivity = zoomOutSens;
            }

        }
      
    }

    // Update is called once per frame
    void Update()
    {
        Zoom();
    }
}
