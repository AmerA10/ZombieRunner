using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float shootingRange = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) {
            if(ammoSlot.GetAmmo() > 0)
            {
                Shoot();
                
            }
          
        }

    }
    private void Shoot()
    {
        PlayMuzzleFlash();
        ProcessRayCast();
        ammoSlot.ReduceAmmo();
    }
    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit))
        {
            Debug.Log("Hit: " + hit.transform.name + " Type: ");
            CreateHitImpact(hit);
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

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject createdEffect = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(createdEffect, .15f);
    }
}
