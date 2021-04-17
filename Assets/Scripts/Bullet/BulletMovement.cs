using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BulletMovement : MonoBehaviour
{
    public float speed;
    public float ttl;
    public Vector3 velocity;
    Rigidbody Rigidbody;
    void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        velocity = transform.InverseTransformDirection(Rigidbody.velocity);
    }
    public void Shoot()
    {
        Rigidbody.AddForce(transform.forward * speed, ForceMode.Impulse);
        StartCoroutine(TimeToLive());
    }
    IEnumerator TimeToLive()
    {
        yield return new WaitForSeconds(ttl);
        Destroy(gameObject);
    }
}
