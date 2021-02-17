using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    Animator anim;

    bool isDead = false;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        
        if(hitPoints != 0)
        {
            hitPoints -= damage;
        }
        if(hitPoints <= 0)
        {
            if(!isDead)
            {
                Die();
            }
            
        }
    }

    private void Die()
    {
        isDead = true;
        anim.SetTrigger("die");
        Destroy(gameObject, 5f);
    }

    public bool GetIsDead()
    {
        return isDead;
    }
}
