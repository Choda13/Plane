using System.Collections;   
using UnityEngine;
public class PlayerGun : MonoBehaviour, IGun
{
    int fireRate;
    int firePower;
    int ammo;
    int magazineSize;
    bool canShoot;
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
    public int Ammo
    {
        get => ammo;
        set
        {
            ammo = value;
        }
    }
    public int MagazineSize
    {
        get => magazineSize;
        set
        {
            magazineSize = value;
        }
    }
    void Awake()
    {
        canShoot=true;
    }
    public void Reload()
    {
        ammo = magazineSize;
    }
    public void Reload(int ammount)
    {
        ammo+=ammount;
        if(ammo > magazineSize)
            ammo = magazineSize;
    }
    public void Shoot()
    {
        if(canShoot)
        {
            //TODO:Shoot()
            canShoot=false;
            StartCoroutine(Cooldown());
        }
    }
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(1/fireRate);
        canShoot=true;
    }
}
