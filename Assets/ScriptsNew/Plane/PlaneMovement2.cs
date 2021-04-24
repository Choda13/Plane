using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement2 : MonoBehaviour, IPlaneController
{
    [SerializeField] GameObject leftRollForcePoint;
    [SerializeField] GameObject rightRollForcePoint;
    [SerializeField] GameObject pitchForcePoint;
    [SerializeField] GameObject yawForcePoint;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] float pitchForceModifier;
    [SerializeField] float rollForceModifier;
    [SerializeField] float yawForceModifier;
    [SerializeField] float liftForceModifier;
    [SerializeField] float maxSpeed;
    [SerializeField] float minSpeed;
    [SerializeField] float collisionSpeedLimit;
    float speed;
    float realSpeed;
    Rigidbody Rigidbody;
    public float Speed { get => speed; }
    public float RealSpeed { get => speed; }
    void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        MoveForward();
    }
    void MoveForward()
    {
        /* Calculating force that is needed to be applied to achive wanted speed
         and calculating lift force of the plane */
        var force = speed * Rigidbody.mass * Rigidbody.drag;
        var liftForce = transform.InverseTransformDirection(Rigidbody.velocity).z * liftForceModifier;

        Rigidbody.AddForce(transform.forward * force);
        Rigidbody.AddForce(transform.up * liftForce);
    }
    public void SpeedUp(int value)
    {
        speed += value;
        if (speed > maxSpeed)        // Making sure we dont exceed maxSpeed
            speed = maxSpeed;
    }
    public void SlowDown(int value)
    {
        speed -= value;
        if (speed < minSpeed)       // Making sure we dont go below the minSpeed
            speed = minSpeed;
    }
    public void Pitch(float value)
    {
        var force = value * pitchForceModifier;
        Rigidbody.AddForceAtPosition(-transform.up * force, pitchForcePoint.transform.position, ForceMode.Impulse);
    }
    public void Roll(float value)
    {
        var force =  value * rollForceModifier;
        // Applying force to both roll force point a.k.a wing at the opposite direction
        Rigidbody.AddForceAtPosition(-transform.up * force, rightRollForcePoint.transform.position, ForceMode.Impulse); 
        Rigidbody.AddForceAtPosition(transform.up * force, leftRollForcePoint.transform.position, ForceMode.Impulse);
    }
    public void Yaw(float value)
    {
        var force = value * yawForceModifier;
        Rigidbody.AddForceAtPosition(-transform.right * force, yawForcePoint.transform.position, ForceMode.Impulse);
    }
}
