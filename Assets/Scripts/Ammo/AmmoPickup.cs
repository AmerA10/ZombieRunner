using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AmmoType ammoType;
    [SerializeField] int ammoAmount = 5;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Player Picked up ammo");
            FindObjectOfType<Ammo>().IncreaseAmmo(ammoType, ammoAmount);
            Destroy(gameObject);
       
        }
    }
}
