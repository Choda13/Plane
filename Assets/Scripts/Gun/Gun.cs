using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public static int ammunition;
    public static int maxAmmunition;
    public static float recoil;
    public ParticleSystem muzzleFX;
    public float fireRate;
    public float bulletSpeed;
    public float offset;
    bool canShoot=true;
    void Awake()
    {
        EventManager.CallGunAwake(ammunition, maxAmmunition);
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && canShoot && ammunition>0)
        {
            Shoot();
            ammunition--;
            if(!muzzleFX.isPlaying)
                muzzleFX.Play();
        }
        else if(!Input.GetKey(KeyCode.Space) && muzzleFX.isPlaying)
            muzzleFX.Stop();
    }
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(1/fireRate);
        canShoot=true;
    }
    void Shoot()
    {   
        Vector3 rotateBy = new Vector3();
        rotateBy.x = Random.Range(-recoil, recoil);
        rotateBy.y = Random.Range(-recoil, recoil);
        rotateBy.z = Random.Range(-recoil, recoil);
        var bulletObject = Instantiate(bullet, transform.position - transform.up * 0.5f + transform.forward*4f, transform.rotation, transform);
        bulletObject.transform.Rotate(rotateBy, Space.Self);
        bulletObject.GetComponent<BulletMovement>().speed = Random.Range(bulletSpeed-offset, bulletSpeed);
        bulletObject.GetComponent<BulletMovement>().Shoot();
        EventManager.CallGunShot(ammunition);
        StartCoroutine(Cooldown());
        canShoot=false;
    }
}
