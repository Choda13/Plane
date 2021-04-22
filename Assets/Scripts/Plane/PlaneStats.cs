using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneStats : MonoBehaviour
{
    public GameObject leftGun;
    public GameObject rightGun;
    public int maxAmmo;
    public int ammo;
    [Range(0,1f)]
    public float recoil;
    void Start()
    {
        Gun.ammunition = ammo;
        Gun.maxAmmunition = maxAmmo;
        Gun.recoil = recoil;
        leftGun.SetActive(true);
        rightGun.SetActive(true);
    }
    void Update()
    {
        Gun.recoil = recoil;
    }
}