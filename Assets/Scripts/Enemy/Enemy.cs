using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int fireRate;
    public int bulletDmg;
    public int bulletSpeed;
    [Range(0, 1f)]
    public float recoil;
    public float range;
    public GameObject player;
    public GameObject explosionFX;
    public GameObject flamesFX;
    public ParticleSystem bulletImpactFX;
    PlayerController playerController;
    Vector3 playerPosition;
    int health;
    bool isAlive;
    void Awake()
    {
        health = 25;
        isAlive=true;
        playerController = player.GetComponent<PlayerController>();
        playerPosition = player.transform.position;
    }
    void EnemyDestroy()
    {
        explosionFX.SetActive(true);
        flamesFX.SetActive(true);
        StartCoroutine(Countdown());
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet" && isAlive)
        {
            other.gameObject.transform.Rotate(0, 180, 0, Space.World);
            other.gameObject.transform.Rotate(180, 0, 0, Space.Self);
            Instantiate(bulletImpactFX, other.gameObject.transform.position, other.gameObject.transform.rotation);
            if (health <= 0)
            {
                isAlive = false;
                EventManager.CallEnemyDestroyed();
                EnemyDestroy();
            }
            else
                health-=bulletDmg;
        }
    }
    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
