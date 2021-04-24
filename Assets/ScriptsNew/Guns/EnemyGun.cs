using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour, IGun
{
    int fireRate;
    int firePower;
    public int FireRate
    {
        get => fireRate;
        set
        {
            fireRate = value;
        }
    }
    public int FirePower
    {
        get => firePower;
        set
        {
            firePower = value;
        }
    }
    public void Shoot()
    {
        //Shoots
    }
    public void Reload()
    {
        //Reloads
    }
}
