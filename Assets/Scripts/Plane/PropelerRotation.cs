using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropelerRotation : MonoBehaviour
{
    /* TODO: Remove ths script and create animaion controller for propeler which rotation speed
        will be depented on wanted speed of plane. */
    public float rotationSpeedModifier;
    float speed;
    float rotSpeed;
    float fps;
    void Awake()
    {
        EventManager.OnSpeedChange+=GetSpeed;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
            rotationSpeedModifier--;
            if(Input.GetKeyDown(KeyCode.L))
            rotationSpeedModifier++;
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeedModifier*360);
    }
    void GetSpeed(float speed)
    {
        this.speed=speed;
    }
}
