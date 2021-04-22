using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletColliding : MonoBehaviour
{
    public ParticleSystem groundFX;
    public Quaternion rotation;

    void Awake()
    {

    }
    void OnCollisionEnter(Collision other)
    {
        transform.Rotate(0,180,0,Space.World);
        transform.Rotate(180,0,0,Space.Self);
        if(other.gameObject.name == "Ground")
        {
            Instantiate(groundFX, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        
    }
}
