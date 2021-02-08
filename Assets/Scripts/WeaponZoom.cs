using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Camera playerCamera;
    [SerializeField] float zoomFOV;
    [SerializeField] RigidbodyFirstPersonController firstPersonController;
    [SerializeField] float zoomOutSens = 2f;
    [SerializeField] float zoomInSens = 0.5f;
    float defaultFOV;


    bool zoomedInToggle = false;
    void Start()
    {
        firstPersonController = GetComponent<RigidbodyFirstPersonController>();
        defaultFOV = playerCamera.fieldOfView;
    
    }

    void Zoom()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if(!zoomedInToggle)
            {
                zoomedInToggle = true;
                playerCamera.fieldOfView = zoomFOV;
                firstPersonController.mouseLook.XSensitivity = zoomInSens;
                firstPersonController.mouseLook.YSensitivity = zoomInSens;
            }
            else
            {
                zoomedInToggle = false;
                playerCamera.fieldOfView = defaultFOV;
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
