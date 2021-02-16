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
    [SerializeField] AmmoType ammoType;
    [SerializeField] float timeBetweenShots = 0.5f;
    bool canShoot = true;

    private void OnEnable()
    {
        canShoot = true;
    }




    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            if (ammoSlot.GetAmmo(ammoType) > 0)
            {
                StartCoroutine(Shoot());

            }
        }
    }
    private IEnumerator Shoot()
    {
        canShoot = false;//stops more coroutines from adding
        PlayMuzzleFlash();
        ProcessRayCast();
        ammoSlot.ReduceAmmo(ammoType);
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }
    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, shootingRange))
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
