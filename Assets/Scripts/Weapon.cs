using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float shootingRange = 100f;
    [SerializeField] float damage = 30f;
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) {
            Shoot();
        }
        

        
    }
    private void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit))
        {
            Debug.Log("Hit: " + hit.transform.name + " Type: ");
            //ToDo: add some hit effect for visual players
          /*  if (hit.transform.TryGetComponent<EnemyHealth>(out EnemyHealth enemyHealth)) can use this as well 
            {
                Debug.Log("Hit enemy: " + enemyHealth.transform.name);
            }*/
            EnemyHealth targetHealth = hit.transform.GetComponent<EnemyHealth>();
            if (targetHealth == null) return;//returns null if not found
            targetHealth.TakeDamage(damage);
            //call a method on EnemyHealth that decreases the enemy health
        }
        else
        {
            return;
        }
    }
}
