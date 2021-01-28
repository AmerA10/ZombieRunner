using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerHealth target;
    [SerializeField] int damage = 40;
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    public void AttackHitEvent()//do damage to target
    {
        if(target == null)
        {
            Debug.LogWarning("Target is null..");
            return;

        }
        else
        {
            target.TakeDamage(damage);
        }
    }
}
