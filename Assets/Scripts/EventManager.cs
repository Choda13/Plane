using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    #region Gun & Ammo events
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
    #endregion

    #region PlaneMovement & Physics events
    public static event Action<float> OnSpeedChange;
    public static event Action<float> OnRealSpeedChange;
    public static void CallSpeedChange(float value)
    {
        if(OnSpeedChange != null)
            OnSpeedChange(value);
    }
    public static void CallRealSpeedChange(float value)
    {
        if(OnRealSpeedChange != null)
            OnRealSpeedChange(value);
    }
    
    #endregion

    #region Plane collision and damage events
    public static event Action OnDestroyed;
    public static event Action OnPlaneCrash;
    public static event Action OnAirDestroyed;
    public static void CallOnDestroyed()
    {
        if(OnDestroyed != null)
            OnDestroyed();
    }
    public static void CallOnCrash()
    {
        if(OnPlaneCrash != null)
            OnPlaneCrash();
        CallOnDestroyed();
    }
    #endregion
}
