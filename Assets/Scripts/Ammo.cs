using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] int ammoAmount = 10;


    public int GetAmmo()
    {
        return ammoAmount;
    }

    public void reduceAmount(int amount)
    {
        ammoAmount -= amount;
    }

    public void ReduceAmmo()
    {
        ammoAmount--;
    }
}
