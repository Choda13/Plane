using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public GameObject leftGun;
    public GameObject rightGun;
    public int maxAmmo;
    public int ammo;
    void Start()
    {
        Gun.ammunition = ammo;
        Gun.maxAmmunition = maxAmmo;
        leftGun.SetActive(true);
        rightGun.SetActive(true);
    }
}