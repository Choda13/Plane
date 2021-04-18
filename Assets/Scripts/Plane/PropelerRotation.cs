using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropelerRotation : MonoBehaviour
{
    /* TODO: Remove ths script and create animaion controller for propeler which rotation speed
        will be depented on wanted speed of plane. */
    public float rotationSpeed;
    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
    }
}
