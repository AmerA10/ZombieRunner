using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float intensityRestoreAmt = 4f;
    [SerializeField] float angleRestoreAmt = 70f;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Player"))
        {
            other.GetComponentInChildren<FlashLightSystem>().RestoreLightAngle(angleRestoreAmt);
            other.GetComponentInChildren<FlashLightSystem>().RestoreLightIntensity(intensityRestoreAmt);
            Destroy(this.gameObject, 0.01f);

        }
    }
}
