using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    public static event Action<int> OnGunShoot;
    public static event Action<int> OnAmmoPickup;
    public static event Action<int,int> OnGunAwake;
    public static event Action<Type> OnGunChange;
    public static void CallGunShot(int value)
    {
        if(OnGunShoot != null)
            OnGunShoot(value);
    }
    public static void CallAmmoPickup(int value)
    {
        if(OnAmmoPickup != null)
            OnAmmoPickup(value);
    }
    public static void CallGunAwake(int ammo, int maxAmmo)
    {
        if(OnGunAwake != null)
            OnGunAwake(ammo, maxAmmo);
    }
    public static void CallGunChange(Type gunType)
    {
        if(OnGunChange != null)
            OnGunChange(gunType);
    }
}
