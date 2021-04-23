using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public ParticleSystem bulletImpactFX;

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            other.gameObject.transform.Rotate(0,180,0,Space.World);
            other.gameObject.transform.Rotate(180,0,0,Space.Self);
            Instantiate(bulletImpactFX, other.gameObject.transform.position, other.gameObject.transform.rotation);
        }
    }
}
