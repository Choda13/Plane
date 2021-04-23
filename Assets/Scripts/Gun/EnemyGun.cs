using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject bullet;
    static int fireRate;
    static int bulletSpeed;
    static float recoil;
    bool canShoot=true;
    int cooldown;
    void Awake()
    {
        cooldown = 1/fireRate;
    }
    void Shoot()
    {
        if(!canShoot)return; //Returns from method if canShoot is false
        Vector3 rotateBy = new Vector3();
        rotateBy.x = Random.Range(-recoil, recoil);
        rotateBy.y = Random.Range(-recoil, recoil);
        rotateBy.z = Random.Range(-recoil, recoil);
        var bulletObject = Instantiate(bullet, transform.position - transform.up * 0.5f + transform.forward*4f, transform.rotation, transform);
        bulletObject.transform.Rotate(rotateBy, Space.Self);
        bulletObject.GetComponent<BulletMovement>().Shoot();
        StartCoroutine(Cooldown());
        canShoot=false;
    }
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown);
        canShoot=true;
    }
}
