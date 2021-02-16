using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Camera playerCamera;
    [SerializeField] RigidbodyFirstPersonController firstPersonController;
    [SerializeField] float zoomOutFOV = 60f;
    [SerializeField] float zoomInFOV = 20f;
    [SerializeField] float zoomOutSens = 2f;
    [SerializeField] float zoomInSens = 0.5f;



    bool zoomedInToggle = false;

    private void OnDisable()
    {
        ZoomOut();
    }
    void Zoom()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if(!zoomedInToggle)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }
    }

    private void ZoomOut()
    {
        zoomedInToggle = false;
        playerCamera.fieldOfView = zoomOutFOV;
        firstPersonController.mouseLook.XSensitivity = zoomOutSens;
        firstPersonController.mouseLook.YSensitivity = zoomOutSens;
    }

    private void ZoomIn()
    {
        zoomedInToggle = true;
        playerCamera.fieldOfView = zoomInFOV;
        firstPersonController.mouseLook.XSensitivity = zoomInSens;
        firstPersonController.mouseLook.YSensitivity = zoomInSens;
    }

    // Update is called once per frame
    void Update()
    {
        Zoom();
    }
}
