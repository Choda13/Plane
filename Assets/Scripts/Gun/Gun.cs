using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public static int ammunition=5000;
    public const int maxAmmunition=5000;
    public ParticleSystem muzzleFX;
    public float fireRate;
    public float bulletSpeed;
    public float offset;
    bool canShoot=true;
    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && canShoot && ammunition>0)
        {
            Shoot();
            ammunition--;
            GameData.manager.UpdateAmmo(ammunition);
            StartCoroutine(Cooldown());
            if(!muzzleFX.isPlaying)
                muzzleFX.Play();
        }
        else if(!Input.GetKey(KeyCode.Space))
            muzzleFX.Stop();
    }
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(1/fireRate);
        canShoot=true;
    }
    void Shoot()
    {   
        var bulletObject = Instantiate(bullet, transform.position - transform.up * 0.5f + transform.forward*4f, transform.rotation, transform);
        bulletObject.GetComponent<BulletMovement>().speed = Random.Range(bulletSpeed-offset, bulletSpeed);
        bulletObject.GetComponent<BulletMovement>().Shoot();
        canShoot=false;
    }
}
