using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int health = 100;
    DeathHandle deathHandle;
    void Start()
    {
        deathHandle = GetComponent<DeathHandle>();
    }

    public void TakeDamage(int damage)
    {
        
        if(health >= 0)
        {
            health -= damage;
        }
        if(health <= 0)
        {
            playerDeath();
        }
    }

    private void playerDeath()
    {
        deathHandle.HandleDeath();
        Debug.Log("YOu are dead");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
